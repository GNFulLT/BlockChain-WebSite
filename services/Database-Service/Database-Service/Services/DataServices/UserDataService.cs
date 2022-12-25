using Database_Service.Grpc.DataServices;
using Database_Service.Grpc.Requests;
using Database_Service.Grpc.Responses;
using Database_Service.Models;
using Microsoft.EntityFrameworkCore;
using ProtoBuf.Grpc;

namespace Database_Service.Services.DataServices
{
    public class UserDataService : DataServiceBase<User>,IUserDataService
    {
        public UserDataService(DbContext db,ILogger<UserDataService> logger) : base(db,logger)
        {
        }

        public async ValueTask<DataServiceResponse<User?>> GetByUsername(UserUsernameRequest req, CallContext context = default)
        {
            try
            {
                var user = await dbSet.FirstOrDefaultAsync(user => user.Username.Equals(req.Username));
                if(user is default(User))
                    return new DataServiceResponse<User?>("There is no user with that username",null,false);

                return new DataServiceResponse<User?>("Found",user,true);
            }
            catch(Exception ex)
            {
                _logger.LogError("Unknown exception throwed while trying to find an user with that username : "+req.Username);
                _logger.LogError(ex.ToString());
                return new DataServiceResponse<User?>("Unknown server exception",null,false);
            }
        }
    }
}
