using Database_Service.Grpc.DataServices;
using Database_Service.Grpc.Requests;
using Database_Service.Grpc.Responses;
using Database_Service.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Web.Administration;
using ProtoBuf.Grpc;

namespace Database_Service.Services
{
    public abstract class DataServiceBase<T> : IDataService<T> where T : class,IDatabaseModel
    {

        DbContext DbContext;
        private DbSet<T> dbSet;
        private ILogger _logger;
        public DataServiceBase(DbContext context,ILogger logger)
        {
            DbContext = context;
            dbSet = context.Set<T>();
            _logger = logger;
            
        }

        public ValueTask<DataServiceResponse<T?>> Create(DataServiceRequestWithEntity<T> request, CallContext context = default)
        {
            try
            {
                Grpc.GrpcUtils.ValidateRequest(request.Data,nameof(request.Data));
                dbSet.Add(request.Data);
                DbContext.SaveChanges();
                _logger.LogInformation("Veri Girildi");
                return ValueTask.FromResult(new DataServiceResponse<T?>("Create Successfully", request.Data, true));
            }
            catch (Exception ex)
            {
                _logger.LogDebug("Geçersiz veri geldi");
                return ValueTask.FromResult(new DataServiceResponse<T?>(ex.Message, null, false));
            }
        }

        public ValueTask<DataServiceResponse<T?>> Delete(CallContext context = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<DataServiceResponse<T?>> Get(DataServiceRequest req, CallContext context = default)
        {
            T? user = dbSet.Find(req.Id);
            if(user is null)
            {
                return ValueTask.FromResult(new DataServiceResponse<T?>("Couldn't find", null, false));
            }
            return ValueTask.FromResult(new DataServiceResponse<T?>("Find Successfully",user,true));
        }

        public ValueTask<DataServiceResponse<T?>> Update(DataServiceRequestWithEntity<T> req, CallContext context = default)
        {
            throw new NotImplementedException();
        }
    }
}
