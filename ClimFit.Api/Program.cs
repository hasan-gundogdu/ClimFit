using ClimFit.Infrastructure;
using ClimFit.Business.DIExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBusinessAndDataAccessServices(builder.Configuration);
builder.Services.AddInfrastructureServices();

var app = builder.Build();

app.UseInfrastructureMiddleware(app.Environment.IsDevelopment(), true);

app.Run();