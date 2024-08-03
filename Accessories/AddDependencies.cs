using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration; // צריך להוסיף את ה-namespace הזה
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
