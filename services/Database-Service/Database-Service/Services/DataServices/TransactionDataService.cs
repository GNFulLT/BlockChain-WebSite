using Database_Service.Grpc.DataServices;
using Database_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Database_Service.Services.DataServices
{
    public class TransactionDataService : DataServiceBase<Transaction>, ITransactionDataService
    {
        public TransactionDataService(DbContext db, ILogger<UserDataService> logger) : base(db, logger)
        { }
    }
}
