using Database.Extensions;
using Entities.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class UrlShortnerDbContext : DbContext
    {
        public UrlShortnerDbContext(DbContextOptions<UrlShortnerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var currentAssembly = GetType().Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(currentAssembly);
            modelBuilder.AddEntities<IEntity>(typeof(IEntity).Assembly);
        }
    }
}