using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDal : IDAL.IObjectDAL
    {
        public bool AddNew(object item)
        {
            try
            {
                using Model.Rivki_Gvirer_cContext ctx = new();
                ctx.Users.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(object item)
        {
            try
            {
                using Model.Rivki_Gvirer_cContext ctx = new();
                ctx.Users.Remove(item);
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
                using Model.Rivki_Gvirer_cContext ctx = new();
                return condition == null ? ctx.Users.ToList() : ctx.Users.Where(condition).ToList();

            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public bool Update(object item)
        {
            try
            {
                using Model.Rivki_Gvirer_cContext ctx = new();
                ctx.Users.Update(item);
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
