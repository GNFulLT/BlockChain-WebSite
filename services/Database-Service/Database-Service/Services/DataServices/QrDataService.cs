using Database_Service.Grpc.DataServices;
using Database_Service.Grpc.Requests;
using Database_Service.Grpc.Responses;
using Database_Service.Models;
using Microsoft.EntityFrameworkCore;
using ProtoBuf.Grpc;

namespace Database_Service.Services.DataServices
{
    public class QrDataService : DataServiceBase<Qr>,IQrDataService
    {
        public QrDataService(DbContext db, ILogger<QrDataService> logger) : base(db, logger)
        { }

        public async ValueTask<DataServiceResponse<Qr?>> GetByUserId(DataServiceRequest req, CallContext context = default)
        {
             try
            {
                var qr = await dbSet.FirstOrDefaultAsync(q => q.UserId == req.Id);
                if(qr is default(Qr))
                    return new DataServiceResponse<Qr?>("There is no user with that username",null,false);

                return new DataServiceResponse<Qr?>("Found",qr,true);
            }
            catch(Exception ex)
            {
                _logger.LogError("Unknown exception throwed while trying to find an user with that Qr : "+req.Id);
                _logger.LogError(ex.ToString());
                return new DataServiceResponse<Qr?>("Unknown server exception",null,false);
            }
        }
    }
}
