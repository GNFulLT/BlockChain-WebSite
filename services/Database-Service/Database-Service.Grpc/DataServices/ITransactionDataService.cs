using Database_Service.Models;
using ProtoBuf.Grpc.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Service.Grpc.DataServices
{
    [Service]
    public interface ITransactionDataService : IDataService<Transaction>
    {
    }
}
