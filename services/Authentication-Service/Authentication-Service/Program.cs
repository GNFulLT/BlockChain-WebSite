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
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
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

builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
});

builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("tautoken:read-write", p => p.
        RequireAuthenticatedUser().
        RequireClaim("scope", "tautoken:read-write"));
});
builder.Services.AddCors();
var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();


app.UseCors(x => x
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true) // allow any origin
                    //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins separated with comma
                    .AllowCredentials()); // allow credentials

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

GrpcChannel dbChannel = GrpcChannel.ForAddress("http://host.docker.internal:3333/", new GrpcChannelOptions
{
    Credentials = ChannelCredentials.Insecure,
});


app.MapPost("/permit", async ([FromBody] PermitRequest token) =>
{
    Console.WriteLine("Request Income");
    if(token is null)
    {
        return Results.BadRequest("AccessToken is not given");

    }
    Console.WriteLine("AccessToken var ve bu : "+token.AccessToken);
    var apiClient = new AuthenticationApiClient($"{conf.Domain}");
    Console.WriteLine("Bağlantı kurultu auth0 ile domain : "+conf.Domain);
    try
    {
        var user = await apiClient.GetUserInfoAsync(token.AccessToken);
        Console.WriteLine("User getirildi : "+user);
        var service = dbChannel.CreateGrpcService<IUserDataService>();

        var dbRes = await service.GetByUsername(new UserUsernameRequest() { Username = user.NickName });

        Console.WriteLine(user.NickName);
        if(!dbRes.IsSuccess)
        {
            Console.WriteLine("User getirilmedi : "+dbRes.Message);
        }
        Console.WriteLine("Başarıyla Getirildi");
        return Results.Ok(dbRes.Data);
    }
    catch(Exception ex)
    {
        return Results.NotFound("Unknown Server Exception");
    }
   
});

app.MapPost("/logout", async () =>
{

}).RequireAuthorization("tautoken:read-write");

app.MapPost("/login", async (HttpContext context,[FromBody] LoginRequest req) =>
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

        return Results.Ok(new {token=res,username=req.Username});
    }
    catch(Exception ex)
    {
        if (ex is ErrorApiException)
            return Results.BadRequest((ex as ErrorApiException)!.ApiError.Error);
        return Results.BadRequest(ex.Message);
    }




});


app.MapPost("/register", async ([FromBody] RegisterRequest reqq) =>
{

    var apiClient = new AuthenticationApiClient($"{conf.Domain}");

    var service = dbChannel.CreateGrpcService<IUserDataService>();

    var request = new SignupUserRequest
    {
        ClientId = conf.ClientId,
        Email = reqq.Email,
        Password = reqq.Password,
        Username = reqq.Username,
        Connection = "TauTokenAuthDB",
        Nickname= reqq.Username
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

