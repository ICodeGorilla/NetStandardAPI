using System;
using Microsoft.EntityFrameworkCore;
using Shared.Core.Repository.Contract;

namespace Shared.Core.Repository
{
    public class EfCoreDatabaseFactoryBase<T> : IEfCoreDatabaseFactory<T> where T : DbContext, new()
    {
        protected readonly string NameOrConnectionString;
        private T _context;

        public EfCoreDatabaseFactoryBase(string nameOrConnectionString)
        {
            NameOrConnectionString = nameOrConnectionString;
        }

        public EfCoreDatabaseFactoryBase()
        {
        }

        T IEfCoreDatabaseFactory<T>.Get()
        {
            return Get();
        }

        public T Get()
        {
            return _context ?? (_context = (T) Activator.CreateInstance(typeof(T), NameOrConnectionString));
        }
    }
}