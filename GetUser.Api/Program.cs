using GetUser.Api.AuthClient;
using GetUser.Api.Options;
using GetUser.Api.Services;
using GetUser.Api.UserHttpClient;

var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();
builder.Services.AddSingleton<IUserClient, UserClient>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));

builder.Services.AddHttpClient<IUserClient, UserClient>("UserClient",client =>
{
    client.BaseAddress = new Uri("https://dummyjson.com/");
});

builder.Services.AddAuthClient();

var app = builder.Build();
app.MapControllers();
app.Run();