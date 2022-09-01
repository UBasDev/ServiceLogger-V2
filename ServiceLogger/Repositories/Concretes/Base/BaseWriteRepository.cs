using ServiceLogger.Contexts;
using ServiceLogger.Models;
using ServiceLogger.Repositories.Abstracts.Base;

namespace ServiceLogger.Repositories.Concretes.Base
{
    public class BaseWriteRepository : WriteRepository<RequestLog>, IBaseWriteRepository
    {
        public BaseWriteRepository(SQLServerDbContext context) : base(context)
        {
        }
    }
}
