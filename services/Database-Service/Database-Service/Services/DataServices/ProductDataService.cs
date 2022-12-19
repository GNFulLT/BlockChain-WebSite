using Database_Service.Grpc.DataServices;
using Database_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace Database_Service.Services.DataServices
{
    public class ProductDataService : DataServiceBase<Product>, IProductDataService
    {

        public ProductDataService(DbContext db, ILogger<ProductDataService> logger) : base(db, logger)
        { }
    }
}
