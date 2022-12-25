using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Auth0.Core.Exceptions;
using Auth0.OidcClient;
using Authentication_Service;
using Authentication_Service.Request;
using Authentication_Service.Response;
using Database_Service.Grpc.DataServices;
using Database_Service.Grpc.Requests;
using Database_Service.Models;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using ProtoBuf.Grpc.Client;
using Steeltoe.Discovery.Client;

var builder = WebApplication.CreateBuilder(args);

const string AUTH_KEY = "TAU_AUTH_TOKEN";


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

GrpcChannel dbChannel = GrpcChannel.ForAddress("http://localhost:3333/", new GrpcChannelOptions
{
    Credentials = ChannelCredentials.Insecure,
});


app.MapGet("/authorize", async (HttpContext context) =>
{
    var apiClient = new AuthenticationApiClient($"{conf.Domain}");

    try
    {
        bool doesHave = context.Request.Cookies.TryGetValue(AUTH_KEY,out string? accessToken);
        if(!doesHave)
            return Results.NotFound(null);

        var user = await apiClient.GetUserInfoAsync(accessToken);

        return Results.Accepted(value: user);
    }
    catch(Exception ex)
    {
        return Results.NotFound(null);
    }
   
});

app.MapGet("/logout", async () =>
{

}).RequireAuthorization("tautoken:read-write");

app.MapGet("/login", async (HttpContext context,[FromBody] LoginRequest req) =>
{
    var apiClient = new AuthenticationApiClient($"{conf.Domain}");
    
    var loginReq = new ResourceOwnerTokenRequest();
    loginReq.Username = req.Username;
    loginReq.Password = req.Password;
    loginReq.ClientId = conf.ClientId;
    loginReq.ClientSecret = conf.ClientSecret;
    loginReq.Realm = "TauTokenAuthDB";
    try
    {
        var res = await apiClient.GetTokenAsync(loginReq);
        context.Response.Cookies.Append(AUTH_KEY,res.AccessToken);

        return Results.Ok(res);
    }
    catch(Exception ex)
    {
        if (ex is ErrorApiException)
            return Results.BadRequest((ex as ErrorApiException)!.ApiError.Error);
        return Results.BadRequest(ex.Message);
    }




});


app.MapGet("/register", async ([FromBody] RegisterRequest reqq) =>
{

    var apiClient = new AuthenticationApiClient($"{conf.Domain}");

    var service = dbChannel.CreateGrpcService<IUserDataService>();

    var request = new SignupUserRequest
    {
        ClientId = conf.ClientId,
        Email = reqq.Email,
        Password = reqq.Password,
        Username = reqq.Username,
        Connection = "TauTokenAuthDB"
    };

    int? CreatedId = null;

    try
    {

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

        CreatedId = s.Data.Id;
        var res = await apiClient.SignupUserAsync(request);
        
        return Results.Ok(value: new RegisterResponse("User Registered", null));
    }
    catch(Exception ex)
    {
        if(CreatedId is not null)
        {
            var res =  await service.Delete(new DataServiceRequest { Id = (int)CreatedId });
            bool successed = false;
            if(!res.IsSuccess)
            {
                for(int i = 0;i<3;i++)
                {
                    res = await service.Delete(new DataServiceRequest { Id = (int)CreatedId });
                    if(res.IsSuccess)
                    {
                        successed = true;
                        break;
                    }
                }

                if(!successed)
                {
                    Console.WriteLine("Silemedi�im de�er var �abuk bak id si : "+CreatedId);
                }
            }
        }

        if (ex is ErrorApiException)
            return Results.BadRequest((ex as ErrorApiException)!.ApiError.Error);
        return Results.BadRequest(ex.Message);
    }
    

});


app.Run();

