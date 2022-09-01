using Microsoft.EntityFrameworkCore;
using ServiceLogger.Models;
using ServiceLogger.Models.Common;

namespace ServiceLogger.Contexts
{
    public class SQLServerDbContext:DbContext
    {
        public SQLServerDbContext(DbContextOptions<SQLServerDbContext> options):base(options)
        {

        }
        public DbSet<RequestLog> RequestLogs { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var dataList = ChangeTracker.Entries<BaseEntity>();            
            foreach (var data in dataList)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
