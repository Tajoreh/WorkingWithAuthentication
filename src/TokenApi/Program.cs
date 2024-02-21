using Jwt_token_Generator;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using TokenApi.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    //.AddJwtBearer(o => o.TokenValidationParameters = new()
    //{
    //    ValidateIssuer = true,
    //    ValidIssuer = ""

    //});
    .AddJwtBearer();

builder.Services.ConfigureOptions<JwtOptionsSetup>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.MapGet("/getToken", ([FromQuery]string userName,[FromQuery]string password, IJwtProvider jwtProvider) =>
{
    var token = jwtProvider.Generate(userName, password);

    return Task.FromResult(token);
});

app.UseAuthentication();

app.UseAuthorization();

app.Run();

