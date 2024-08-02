using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBL;

namespace BL
{
    public static class BLCommon
    {
        public static IServiceCollection AddBLDependencies(this IServiceCollection collection)
        {
            collection.AddScoped(typeof(IObjectBL), typeof(DepartmentServices));
            collection.AddScoped(typeof(IUserBL), typeof(UserServices));
            return collection;
        }
    }
}
