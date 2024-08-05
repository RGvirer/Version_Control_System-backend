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

        public bool AddNew(object department)
        {
            try
            {
                return departmentDAL.AddNew(department);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(object department)
        {
            try
            {
                return departmentDAL.Delete(department);
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


        public bool Update(object department)
        {
            try
            {
                return departmentDAL.Update(department);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
