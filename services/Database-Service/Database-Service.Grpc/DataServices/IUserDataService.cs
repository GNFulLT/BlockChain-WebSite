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
       
    }
}
