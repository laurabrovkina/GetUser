using GetUser.Api.Auth;
using GetUser.Api.Options;

namespace GetUser.Api.UserHttpClient;

public static class UserClientExtensions
{
    public static void AddUserClient(this IServiceCollection services, Action<UserOptions>? configureOptions = null)
    {
        services.AddOptions<UserOptions>()
            .BindConfiguration(nameof(UserOptions))
            .ValidateOnStart();

        if (configureOptions != null)
        {
            services.Configure(configureOptions);
        }
        
        services.AddTransient<JwtTokenHandler>();
        services.AddHttpClient<IUserClient, UserClient>("UserClient",client =>
            {
                client.BaseAddress = new Uri("https://dummyjson.com/");
            })
            .AddHttpMessageHandler<JwtTokenHandler>();
    }
}