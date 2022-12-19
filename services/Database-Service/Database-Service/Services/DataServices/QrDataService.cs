using Database_Service.Grpc.DataServices;
using Database_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Database_Service.Services.DataServices
{
    public class QrDataService : DataServiceBase<Qr>,IQrDataService
    {
        public QrDataService(DbContext db, ILogger<QrDataService> logger) : base(db, logger)
        { }
    }
}
