using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Storage;
using NUnit.Framework;
using SharedLibraryDatabase;

namespace NTests
{
    public class BaseTests
    {
        public IServiceProvider ServiceProvider;
        public IDatabaseFactory DatabaseFactory { get; }
        public IDbContextTransaction Transaction { get; set; }

        public BaseTests()
        {
            ServiceProvider =
                WebHost.CreateDefaultBuilder(new string[] { })
                    .UseStartup<TestStartup>().Build().Services;
            DatabaseFactory = (IDatabaseFactory)ServiceProvider.GetService(typeof(IDatabaseFactory));
        }

        [SetUp]
        public void Setup()
        {
            Transaction = DatabaseFactory.Get().Database.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            Transaction.Rollback();
        }
    }
}