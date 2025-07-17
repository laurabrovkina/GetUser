using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GetUser.Tests;

public class TestFixture
{
    private readonly IConfigurationRoot _configurationBuilder;
    private Uri _microserviceUrl;

    public TestFixture()
    {
        _configurationBuilder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        _microserviceUrl = new Uri(_configurationBuilder.GetValue<string>("MicroserviceUrl") ?? string.Empty);
    }

    public HttpClient GetUserClientWithToken()
    {
        var services = new ServiceCollection();
        services.AddHttpClient("AuthClient");
        services.AddJwtTokenHttpHandler(_configurationBuilder);
        var httpClientBuilder = SetupHttpClient(_microserviceUrl, services);
        httpClientBuilder.AddHttpMessageHandler<JwtTokenHttpHandler>();
        var serviceProvider = services.BuildServiceProvider();
        var factory = serviceProvider.GetRequiredService<IHttpClientFactory>();
        var client = factory.CreateClient("TestClient");
        return client;
    }

    private static IHttpClientBuilder SetupHttpClient(Uri baseAddress, IServiceCollection services)
    {
        var httpClientBuilder = services.AddHttpClient("TestClient",
            client =>
            {
                client.BaseAddress = baseAddress;
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            })
            .ConfigurePrimaryHttpMessageHandler(() =>
                new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (_, _, _, _) => true
                });
        
        return httpClientBuilder;
    }
}