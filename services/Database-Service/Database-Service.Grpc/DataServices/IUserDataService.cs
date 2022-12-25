using Database_Service.Grpc.Responses;
using Database_Service.Grpc.Requests;

using Database_Service.Models;
using ProtoBuf;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;
using ProtoBuf.Meta;

namespace Database_Service.Grpc.DataServices
{
    [Service]
    public interface IUserDataService :IDataService<User>
    {
        [Operation]
        ValueTask<DataServiceResponse<User?>> GetByUsername(UserUsernameRequest req, CallContext context = default);

    }
}
