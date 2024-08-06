using DAL.Models;
using IDAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class DALCommon
    {
        public static IServiceCollection AddDALDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RivkiGvirerContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IDAL.IUserDAL), typeof(DAL.UserDal));
            services.AddDbContext<RivkiGvirerContext>(options =>
                                options.UseSqlServer());

            return services;
        }
    }
}
