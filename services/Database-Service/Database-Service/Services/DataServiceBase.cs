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

        protected DbContext DbContext;
        protected DbSet<T> dbSet;
        protected ILogger _logger;
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

        public ValueTask<DataServiceResponse<T?>> Delete(DataServiceRequest req,CallContext context = default)
        {
            try
            {
                dbSet.Remove(dbSet.First(e => e.Id == req.Id));
                DbContext.SaveChanges();
                return ValueTask.FromResult(new DataServiceResponse<T?>("Deleted", null, true));
            }
            catch (Exception ex)
            {
                _logger.LogError("While try to delete : \n"+ex.Message);
                return ValueTask.FromResult(new DataServiceResponse<T?>(ex.Message, null, false));
            }
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
            try 
            { 
                if(req.Id != req.Data.Id)
                {
                    return ValueTask.FromResult(new DataServiceResponse<T?>("Cannot update the id", null, false));
                }
                var entity = dbSet.Find(req.Id);
                if(entity is null)
                {
                    return ValueTask.FromResult(new DataServiceResponse<T?>("There is no entity like that", null, false));
                }
                dbSet.Entry(entity).CurrentValues.SetValues(req.Data);

                DbContext.SaveChanges();
                return ValueTask.FromResult(new DataServiceResponse<T?>("Entity Updated", null, false));
            }
            catch (Exception ex)
            {
                _logger.LogError("Unexpected Error while trying to update an entity : \n"+ex.Message);
                return ValueTask.FromResult(new DataServiceResponse<T?>("Unexpected Server Error", null, false));
            }
        }
    }
}
