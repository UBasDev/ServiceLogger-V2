using Microsoft.EntityFrameworkCore;
using ServiceLogger.Contexts;
using ServiceLogger.Models.Common;
using ServiceLogger.Repositories.Abstracts;

namespace ServiceLogger.Repositories.Concretes
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly SQLServerDbContext _context;
        public WriteRepository(SQLServerDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public async Task AddSingleAsync(T model)
            => await Table.AddAsync(model);

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
