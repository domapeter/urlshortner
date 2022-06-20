using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAsyncUnitOfWork<T> where T : IEntity
    {
        Task<T> CreateAsync(T entity);

        Task<T> FindAsync(Expression<Func<T, bool>> filter);
    }
}