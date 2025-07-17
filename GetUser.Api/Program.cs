using GetUser.Api.AuthClient;
using GetUser.Api.Mappers;
using GetUser.Api.Services;
using GetUser.Api.UserHttpClient;

var builder = WebApplication.CreateBuilder();

builder.Services.AddScoped<MapperlyMapper>();
builder.Services.AddControllers();
builder.Services.AddSingleton<IUserClient, UserClient>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAuthClient();
builder.Services.AddUserClient();

var app = builder.Build();
app.MapControllers();
app.Run();

