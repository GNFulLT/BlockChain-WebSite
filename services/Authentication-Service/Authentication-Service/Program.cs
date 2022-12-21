using Auth0.AspNetCore.Authentication;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Authentication_Service;
using Authentication_Service.Request;
using Authentication_Service.Response;
using Database_Service.Grpc.DataServices;
using Database_Service.Grpc.Requests;
using Database_Service.Models;
using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Net.Client.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProtoBuf.Grpc.Client;
using Steeltoe.Discovery;
using Steeltoe.Discovery.Client;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDiscoveryClient(builder.Configuration);
builder.Services.AddAuthorization();
var conf = builder.Configuration.GetSection("Auth0").Get<Auth0Config>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
     .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, c =>
     {
         c.Authority = $"https://{conf.Domain}";
         c.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
         {
             ValidAudience = "www.tautoken.com",
             ValidIssuer = conf.Domain
         };
     });

builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("tautoken:read-write", p => p.
        RequireAuthenticatedUser().
        RequireClaim("scope", "tautoken:read-write"));
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/testgrpc", async () =>
{
   

    using var channel = GrpcChannel.ForAddress("http://localhost:3333/", new GrpcChannelOptions
    {
        Credentials = ChannelCredentials.Insecure,
    });
    var client = channel.CreateGrpcService<IUserDataService>();
    var res = await client.Get(new Database_Service.Grpc.Requests.DataServiceRequest()
    {
        Id = 1
    });
    Console.WriteLine($"Greeting: {res.Message}");
    var regi = new RegisterRequest();

    return res.Data.Email + res.Data.Name + res.Data.Username; 
});

GrpcChannel dbChannel = GrpcChannel.ForAddress("http://localhost:3333/", new GrpcChannelOptions
{
    Credentials = ChannelCredentials.Insecure,
});

app.MapGet("/register", async ([FromBody] RegisterRequest reqq) =>
{

    var apiClient = new AuthenticationApiClient($"{conf.Domain}");

    var request = new SignupUserRequest
    {
        ClientId = conf.ClientId,
        Email = reqq.Email,
        Password = reqq.Password,
        Username = reqq.Username,
        Connection = "TauTokenAuthDB"
    };

    try
    {
//        var res = await apiClient.SignupUserAsync(request);
        var service = dbChannel.CreateGrpcService<IUserDataService>();

        var req = new DataServiceRequestWithEntity<User>()
        {
            Data = new User()
            {
                Username = reqq.Username,
                Password = reqq.Password,
                Email = reqq.Email,
            }
        };

        var s = await service.Create(req);
        if (!s.IsSuccess)
        {
            return Results.StatusCode(500);
        }

        return Results.CreatedAtRoute(value: new RegisterResponse("User Registered", null));
    }
    catch(Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
    

});


app.MapGet("/weatherforecast", () =>
{
    /*
    var dclient =  app.Services.GetRequiredService<IDiscoveryClient>();

    var instances = dclient.GetInstances("DB-SERVICE");
    */

    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}