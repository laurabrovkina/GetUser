using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GetUser.Tests;

public static class JwtTokenHttpHandlerExtensions
{
    public static void AddJwtTokenHttpHandler(this IServiceCollection services, IConfigurationRoot configuration)
    {
        services.AddTransient<JwtTokenHttpHandler>();
        services.Configure<TokenOptions>(options => configuration.GetSection("TokenOptions").Bind(options));
    }
}