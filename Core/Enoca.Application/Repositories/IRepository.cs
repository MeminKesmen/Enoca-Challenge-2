using Enoca.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enoca.Application.Repositories
{
    public interface IRepository<T, TKey> where T : BaseEntity<TKey>
    {
        DbSet<T> Table { get; }
    }
}
