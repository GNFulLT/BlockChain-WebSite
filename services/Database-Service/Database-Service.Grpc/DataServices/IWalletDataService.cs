using Database_Service.Grpc.Responses;
using Database_Service.Grpc.Requests;
using Database_Service.Models;
using ProtoBuf.Grpc.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf.Grpc;

namespace Database_Service.Grpc.DataServices
{
    [Service]
    public interface IWalletDataService : IDataService<Wallet>
    {
        [Operation]
        ValueTask<DataServiceResponse<Wallet?>> GetByUserId(DataServiceRequest req, CallContext context = default);

    }
}
