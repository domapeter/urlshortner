using Entities.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAsyncRepository<T> where T : IEntity
    {
        Task<T> CreateAsync(T entity);

        Task<T> FindAsync(Expression<Func<T, bool>> filter);

        Task<IDbContextTransaction> BeginTransactionAsync();

        Task<int> SaveChangesAsync();
    }
}