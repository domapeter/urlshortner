using DAL.Interfaces;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWorkBase<T> : IAsyncUnitOfWork<T> where T : IEntity
    {
        protected IAsyncRepository<T> repository;

        public UnitOfWorkBase(IAsyncRepository<T> repository)
        {
            this.repository = repository;
        }

        public async Task<T> CreateAsync(T entity)
        {
            T result;
            using (var tr = await repository.BeginTransactionAsync())
            {
                result = await repository.CreateAsync(entity);
                await repository.SaveChangesAsync();
                await tr.CommitAsync();
            }
            return result;
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> filter)
        {
            return await repository.FindAsync(filter);
        }
    }
}