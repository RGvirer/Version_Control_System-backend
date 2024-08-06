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
        public DepartmentServices(IObjectDAL _departmentDAL)
        {
            departmentDAL = _departmentDAL;
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
