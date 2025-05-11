using ClimFit.Abstractions.Services;
using System.Text;
using System.Text.Json;

namespace ClimFit.Infrastructure.Services
{
    public class HttpRequestBase : IHttpRequestBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public HttpRequestBase(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            _httpClient = _httpClientFactory.CreateClient(); // Default HttpClient
        }

        public async Task<TResponse?> SendAsync<TResponse>(
            HttpMethod method,
            string url,
            object? content = null,
            string contentType = "application/json",
            Dictionary<string, string>? headers = null)
        {
            using var request = new HttpRequestMessage(method, url);

            // Process content
            if (content != null)
            {
                if (contentType == "application/json")
                {
                    var jsonContent = JsonSerializer.Serialize(content);
                    request.Content = new StringContent(jsonContent, Encoding.UTF8, contentType);
                }
                else if (contentType == "application/x-www-form-urlencoded")
                {
                    if (content is Dictionary<string, string> formContent)
                    {
                        request.Content = new FormUrlEncodedContent(formContent);
                    }
                    else
                    {
                        throw new ArgumentException("Form content must be a Dictionary<string, string>");
                    }
                }
                else
                {
                    throw new NotSupportedException($"Content type '{contentType}' is not supported.");
                }
            }

            // Add custom headers
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            try
            {
                // Send HTTP request
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();
                try
                {
                    // Attempt to deserialize the response string to TResponse
                    return JsonSerializer.Deserialize<TResponse>(responseString);
                }
                catch (JsonException)
                {
                    // If deserialization fails and TResponse is string, return the response string directly
                    if (typeof(TResponse) == typeof(string))
                    {
                        return (TResponse)(object)responseString;
                    }
                    throw;
                }
            }
            catch (Exception ex)
            {
                // Log exception (logging mechanism not shown here)
                throw new HttpRequestException("An error occurred while sending the HTTP request.", ex);
            }
        }
    }
}
