using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DepartmentDAL : IDAL.IObjectDAL
    {
        private readonly RivkiGvirerContext dbContext;
        public DepartmentDAL(RivkiGvirerContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public bool AddNew(object department)
        {
            try
            {
                dbContext.Departments.Add((Department)department);
                dbContext.SaveChanges();
                return true;
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
                dbContext.Departments.Remove((Department)department);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public object Get(int id)
        {
            try
            {
                return dbContext.Departments.Find(id);
            }
            catch (Exception)
            {
                return null;
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
                return dbContext.Departments.Cast<object>().ToList();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }


        public bool Update(object department)
        {
            try
            {
                dbContext.Departments.Update((Department)department);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
