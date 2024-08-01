using Microsoft.Extensions.DependencyInjection;
using BL;
using DAL;

namespace Accessories
{
    public static class AddDependencies
    {
        public static void AddDependency(this IServiceCollection serviceCollection)
        {
            serviceCollection
                 .AddBLDependencies()
                 .AddDALDependencies();
        }
    }
}
