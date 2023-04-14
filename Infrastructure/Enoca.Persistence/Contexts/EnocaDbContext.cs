using Enoca.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Persistence.Contexts
{
    public class EnocaDbContext:DbContext
    {
        public EnocaDbContext(DbContextOptions<EnocaDbContext> options) : base(options)
        {

        }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<CarrierConfiguration> CarrierConfigurations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CarrierReport> CarrierReports { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity<int>>();
            //foreach (var data in datas)
            //{
            //    switch (data.State)
            //    {
            //        case EntityState.Detached:
            //            break;
            //        case EntityState.Unchanged:
            //            break;
            //        case EntityState.Deleted:
            //            break;
            //        case EntityState.Modified:
            //            data.Entity.EDate = DateTime.Now;
            //            break;
            //        case EntityState.Added:
            //            data.Entity.CDate = DateTime.Now;
            //            //data.Entity.Id = UniqueId.GetUniqueId;
            //            break;
            //        default:
            //            break;
            //    }
            //}
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
