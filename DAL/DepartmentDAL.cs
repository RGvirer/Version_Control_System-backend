using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace DAL
{
    public class DepartmentDAL : IDAL.IObjectDAL
    {
        public bool AddNew(object item)
        {
            if (item is Department department)
            {
            try
            {
                    using var ctx = new RivkiGvirerContext();
                    ctx.Departments.Add(department);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
            return false;
        }

        public bool Delete(object item)
        {
            if (item is Department department)
            {
            try
            {
                    using var ctx = new RivkiGvirerContext();
                    ctx.Departments.Remove(department);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
            return false;
        }

        public List<object> GetAll(Func<object, bool>? condition = null)
        {
            try
            {
                using var ctx = new RivkiGvirerContext();
                var departments = ctx.Departments.ToList();
                return condition == null ? departments.Cast<object>().ToList() : departments.Where(condition).Cast<object>().ToList();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public bool Update(object item)
        {
            if (item is Department department)
            {
            try
            {
                    using var ctx = new RivkiGvirerContext();
                    ctx.Departments.Update(department);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            }
            return false;
        }
    }
}
