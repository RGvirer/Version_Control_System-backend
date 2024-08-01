using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DepartmentDAL : IDAL.IObjectDAL
    {
        public bool AddNew(object department)
        {
            try
            {
                using var ctx = new RivkiGvirerContext();
                ctx.Departments.Add((Department)department);
                ctx.SaveChanges();
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
                using var ctx = new RivkiGvirerContext();
                ctx.Departments.Remove((Department)department);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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

        public bool Update(object department)
        {

            try
            {
                    using var ctx = new RivkiGvirerContext();
                    ctx.Departments.Update((Department)department);
                    ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
