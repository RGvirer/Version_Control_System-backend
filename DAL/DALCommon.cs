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

            services.AddScoped<IAppDbContext, RivkiGvirerContext>();
            services.AddScoped<IUserDAL, UserDal>(); // Make sure UserDal implements IUserDAL

            return services;
        }
    }
}
