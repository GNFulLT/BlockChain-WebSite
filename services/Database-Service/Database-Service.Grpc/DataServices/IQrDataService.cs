using Database_Service.Grpc.Requests;
using Database_Service.Grpc.Responses;
using Database_Service.Models;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Service.Grpc.DataServices
{
    [Service]
    public interface IQrDataService : IDataService<Qr>
    {
         [Operation]
        ValueTask<DataServiceResponse<Qr?>> GetByUserId(DataServiceRequest req, CallContext context = default);
    }
}
