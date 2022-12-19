using Database_Service.Grpc.DataServices;
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
        /*
        public ValueTask<User> Create(GetRequestWithEntity<User> request, CallContext context = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<User> Delete(GetRequest req, CallContext context = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<User> Get(GetRequest req, CallContext context = default)
        {
            User user = set.Find(req.Id);

            return ValueTask.FromResult<User>(user)!;
        }

        public ValueTask<User> Update(GetRequestWithEntity<User> e, CallContext context = default)
        {
            throw new NotImplementedException();
        }
        */
    }
}
