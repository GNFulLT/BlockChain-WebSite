// Read the contents of the launchSettings.json file
using Database_Service;
using Database_Service.Grpc;
using Database_Service.Grpc.DataServices;
using Database_Service.Models;
using Database_Service.Services;
using Database_Service.Services.DataServices;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProtoBuf.Grpc.Server;
using Steeltoe.Discovery.Client;


GrpcUtils.WriteProtoFiles<IUserDataService>();



/*
var json = File.ReadAllText("Properties/launchSettings.json");

// Parse the JSON to get the port number
var launchSettings = JsonConvert.DeserializeObject<dynamic>(json);
var appUrl = (string)launchSettings.profiles["Database_Service"].applicationUrl;

var uri = new Uri(appUrl);

var port = uri.Port;

// Output the port number
Console.WriteLine($"Port: {port}");
*/
var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(options => {
    options.ConfigureEndpointDefaults(defaults =>
          defaults.Protocols = HttpProtocols.Http2);

});

// Add services to the container.   
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDiscoveryClient(builder.Configuration);
builder.Services.AddDbContext<PDatabase>();
builder.Services.AddScoped<DbContext, PDatabase>();

builder.Services.AddCodeFirstGrpc(opt =>
{
    //opt.EnableDetailedErrors = true;
});

builder.Services.AddGrpcReflection();
builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
    logging.AddFilter("Grpc", LogLevel.Debug);

});
var app = builder.Build();

app.MapGrpcReflectionService();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<UserDataService>();
});

app.UseHttpsRedirection();

// Configure the HTTP request pipeline.


    app.UseSwagger();
    app.UseSwaggerUI();


PDatabase.UpdateDatabase();

//app.UseAuthorization();

//app.MapControllers();

app.Run();
