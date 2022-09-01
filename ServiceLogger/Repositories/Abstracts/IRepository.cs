using Microsoft.EntityFrameworkCore;
using ServiceLogger.Models.Common;

namespace ServiceLogger.Repositories.Abstracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
