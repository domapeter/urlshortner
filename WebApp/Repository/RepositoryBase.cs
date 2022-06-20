using DAL.Interfaces;
using Database;
using Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : class, IEntity
    {
        protected UrlShortnerDbContext Context { get; }

        protected DbSet<T> Entities => Context.Set<T>();

        public RepositoryBase(UrlShortnerDbContext context)
        {
            Context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            var created = await Entities.AddAsync(entity);

            return created.Entity;
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> filter)
        {
            var query = Entities.Where(filter).AsQueryable();

            var result = await query.AsNoTracking().SingleAsync();

            return result;
        }

        public Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return Context.Database.BeginTransactionAsync();
        }

        public Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }
    }
}