using AuthenticationService;
using AuthenticationService.DiscoveryClient;
using AuthenticationService.Services;
using Newtonsoft.Json;
using TauDiscoveryClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpc();
builder.Services.AddDiscoveryClient();
var host = builder.Host;
var app = builder.Build();
var conf = builder.Configuration;
app.UseRouting();
app.UseEurekaDiscoveryClient();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<GreetingsManagerService>();
});


app.Run();
