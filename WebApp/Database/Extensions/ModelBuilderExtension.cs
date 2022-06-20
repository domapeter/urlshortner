using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Database.Extensions
{
    public static  class ModelBuilderExtension
    {
        public static void AddEntities<T>(this ModelBuilder modelBuilder, string assemblyName = null)
        {
            Assembly currentLibrary = assemblyName == null ? typeof(T).Assembly : Assembly.Load(assemblyName);
            modelBuilder.AddEntities<T>(currentLibrary);
        }

        public static void AddEntities<T>(this ModelBuilder modelBuilder, Assembly assembly)
        {
            if (!typeof(T).IsInterface)
            {
                throw new ArgumentException("Type should be interface!");
            }

            var entitiesTypes = assembly.GetTypes().Where(p => p.IsClass && !p.IsAbstract && p.GetInterfaces().Any(x => x == typeof(T)));

            foreach (var entityType in entitiesTypes)
            {
                modelBuilder.Entity(entityType);
            }
        }
    }
}