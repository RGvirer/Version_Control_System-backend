using System;
using System.Collections.Generic;
using System.Linq;
using IDAL;
using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class DepartmentServices : IBL.IObjectBL
    {
        private readonly IObjectDAL departmentDAL;
        private readonly IAppDbContext dbContext;
        public DepartmentServices(IObjectDAL _departmentDAL, IAppDbContext _dbContext)
        {
            departmentDAL = _departmentDAL;
            dbContext = _dbContext;
        }

        public bool AddNew(object user)
        {
            try
            {
                return departmentDAL.AddNew(user);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(object user)
        {
            try
            {
                return departmentDAL.Delete(user);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Get(object item)
        {
            throw new NotImplementedException();
        }

        public List<object> GetAll()
        {
            try
            {
                return departmentDAL.GetAll();
            }
            catch (Exception)
            {
                return new List<object>();
            }
        }


        public bool Update(object user)
        {
            try
            {
                return departmentDAL.Update(user);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
