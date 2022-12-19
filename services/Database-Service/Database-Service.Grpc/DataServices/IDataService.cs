using Database_Service.Grpc.Requests;
using Database_Service.Grpc.Responses;
using Database_Service.Models;
using ProtoBuf;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;
using System.Runtime.Serialization;

namespace Database_Service.Grpc.DataServices
{
    [SubService]
    public interface IDataService<T> where T : IDatabaseModel
    {
        [Operation]
        ValueTask<DataServiceResponse<T?>> Create(DataServiceRequestWithEntity<T> req, CallContext context = default);

        [Operation]
        ValueTask<DataServiceResponse<T?>> Update(DataServiceRequestWithEntity<T> req, CallContext context = default);

        [Operation]
        ValueTask<DataServiceResponse<T?>> Delete(CallContext context = default);

        [Operation]
        ValueTask<DataServiceResponse<T?>> Get(DataServiceRequest req, CallContext context = default);
    }

    
    
}
