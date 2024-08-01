using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class BLCommon
    {
        public static IServiceCollection AddBLDependencies(this IServiceCollection collection)
        {
            collection.AddScoped(typeof(IBL.IObjectBL), typeof(BL.DepartmentServices));
            collection.AddScoped(typeof(IBL.IUserBL), typeof(BL.UserServices));
            return collection;
        }
    }
}
