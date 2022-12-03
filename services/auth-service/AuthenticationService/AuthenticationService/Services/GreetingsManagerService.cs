using BasicGrpcService;
using Grpc.Core;


namespace AuthenticationService.Services
{
    public class GreetingsManagerService : GreetingsManager.GreetingsManagerBase
    {
        public override Task<GreetingResponse>
          GenerateGreeting(GreetingRequest request,
            ServerCallContext context)
        {
            
            return Task.FromResult(new GreetingResponse
            {
                Message = "Hello " + request.Name
            });
        }
    }
}
