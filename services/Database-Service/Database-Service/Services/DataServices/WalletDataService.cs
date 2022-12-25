using Database_Service.Grpc.DataServices;
using Database_Service.Grpc.Requests;
using Database_Service.Grpc.Responses;
using Database_Service.Models;
using Microsoft.EntityFrameworkCore;
using ProtoBuf.Grpc;

namespace Database_Service.Services.DataServices
{
    public class WalletDataService : DataServiceBase<Wallet>,IWalletDataService
    {
        public WalletDataService(DbContext db, ILogger<WalletDataService> logger) : base(db, logger)
        { }

        async public ValueTask<DataServiceResponse<Wallet?>> GetByUserId(DataServiceRequest req, CallContext context = default)
        {
            try
            {
                var wallet = await dbSet.FirstOrDefaultAsync(wallet => wallet.UserId == req.Id);
                if(wallet is default(Wallet))
                    return new DataServiceResponse<Wallet?>("There is no user with that username",null,false);

                return new DataServiceResponse<Wallet?>("Found",wallet,true);
            }
            catch(Exception ex)
            {
                _logger.LogError("Unknown exception throwed while trying to find a wallet with that UserId : "+req.Id);
                _logger.LogError(ex.ToString());
                return new DataServiceResponse<Wallet?>("Unknown server exception",null,false);
            }
        }
    }
}
