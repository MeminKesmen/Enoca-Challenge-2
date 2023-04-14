using Enoca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.Repositories
{
    public interface IWriteRepository<T, TKey> : IRepository<T, TKey> where T : BaseEntity<TKey>
    {
        Task<bool> AddAsync(T model);
        bool Remove(T model);
        Task<bool> RemoveAsync(Expression<Func<T, bool>> filter);
        bool Update(T model);
        Task<bool> AddRangeAsync(List<T> datas);
        Task<int> SaveAsync();
    }
}
