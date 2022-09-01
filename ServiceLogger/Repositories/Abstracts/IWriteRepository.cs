using ServiceLogger.Models.Common;

namespace ServiceLogger.Repositories.Abstracts
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        public Task AddSingleAsync(T model);
        public Task SaveChangesAsync();
    }
}
