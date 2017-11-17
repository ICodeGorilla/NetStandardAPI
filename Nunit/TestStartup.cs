using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedLibraryCore;

namespace NTests
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            //var descriptor =
            //    new ServiceDescriptor(
            //        typeof(IDatabaseFactory),
            //        typeof(TestDatabaseFactory),
            //        ServiceLifetime.Scoped);
            //services.Replace(descriptor);
        }
    }
}