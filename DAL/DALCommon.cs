using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class DALCommon
    {
        public static IServiceCollection AddDALDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<VersionMmanagementSystemContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IDAL.IUserDAL), typeof(DAL.UserDal));
            services.AddScoped(typeof(IDAL.IRepositoryDAL), typeof(DAL.RepositoryDal));
            services.AddScoped(typeof(IDAL.IBranchDAL), typeof(DAL.BranchDal));
            services.AddScoped(typeof(IDAL.IMergeDAL), typeof(DAL.MergeDAL));
            services.AddScoped(typeof(IDAL.IVersionDAL), typeof(DAL.VersionDAL));
            services.AddDbContext<VersionMmanagementSystemContext>(options =>
                                options.UseSqlServer());

            return services;
        }
    }
}
