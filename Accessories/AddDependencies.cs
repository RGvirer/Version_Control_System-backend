using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BL;
using DAL;

namespace Accessories
{
    public static class AddDependencies
    {
        public static void AddDependency(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection
                 .AddBLDependencies()
                 .AddDALDependencies(configuration);
        }
    }
}
