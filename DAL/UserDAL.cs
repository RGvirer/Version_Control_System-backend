using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace DAL
{
    public class UserDal : IDAL.IObjectDAL
    {
        public bool AddNew(object item)
        {
            if (item is User user)
            {
                try
                {
                    using var ctx = new RivkiGvirerContext();
                    ctx.Users.Add(user);
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
            if (item is User user)
            {
                try
                {
                    using var ctx = new RivkiGvirerContext();
                    ctx.Users.Remove(user);
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
                var users = ctx.Users.ToList();
                return condition == null ? users.Cast<object>().ToList() : users.Where(condition).Cast<object>().ToList();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public bool Update(object item)
        {
            if (item is User user)
            {
                try
                {
                    using var ctx = new RivkiGvirerContext();
                    ctx.Users.Update(user);
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
