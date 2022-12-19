using Database_Service.Grpc.DataServices;
using Database_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Database_Service.Services.DataServices
{
    public class WalletDataService : DataServiceBase<Wallet>,IWalletDataService
    {
        public WalletDataService(DbContext db, ILogger<WalletDataService> logger) : base(db, logger)
        { }
    }
}
