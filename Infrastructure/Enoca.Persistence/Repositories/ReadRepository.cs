using Enoca.Application.Repositories;
using Enoca.Domain.Entities;
using Enoca.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Persistence.Repositories
{
    public class ReadRepository<T, TKey> : IReadRepository<T, TKey> where T : BaseEntity<TKey>
    {
        protected readonly EnocaDbContext _context;

        public ReadRepository(EnocaDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return filter == null ? await query.ToListAsync() : await query.Where(filter).ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(filter);
        }
        public IQueryable<T> Queryable(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }
       
    }
}
