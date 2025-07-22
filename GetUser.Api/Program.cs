using GetUser.Api.AuthClient;
using GetUser.Api.Exceptions;
using GetUser.Api.Mappers;
using GetUser.Api.Services;
using GetUser.Api.UserHttpClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails(configure =>
{
    configure.CustomizeProblemDetails = context =>
    {
        context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);
    };
});
builder.Services.AddExceptionHandler<ValidationExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddScoped<MapperlyMapper>();
builder.Services.AddControllers();
builder.Services.AddSingleton<IUserClient, UserClient>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAuthClient();
builder.Services.AddUserClient();

var app = builder.Build();
app.UseHttpsRedirection();
app.MapControllers();
app.UseExceptionHandler();

app.Run();

