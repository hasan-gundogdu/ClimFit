namespace ClimFit.Abstractions.Services
{
    public interface IHttpRequestBase
    {
        Task<TResponse?> SendAsync<TResponse>(
            HttpMethod method,
            string url,
            object? content = null,
            string contentType = "application/json",
            Dictionary<string, string>? headers = null);
    }
}
