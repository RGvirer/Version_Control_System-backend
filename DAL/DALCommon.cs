using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
namespace BL
{
    public static class DALCommon
    {
        public static IServiceCollection AddDALDependencies(this IServiceCollection collection)
        {
            collection.AddScoped(typeof(IDAL.IObjectDAL), typeof(DAL.DepartmentDAL));
            collection.AddScoped(typeof(IDAL.IObjectDAL), typeof(DAL.UserDal));
            collection.AddDbContext<RivkiGvirerContext>(options =>
                    options.UseSqlServer());

            return collection;
        }
    }
}
