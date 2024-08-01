using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDal : IDAL.IUserDAL
    {
        private readonly DbContext dbContext;
        public UserDal(DbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public bool AddNew(object user)
        {
            throw new NotImplementedException();
        }

        public bool Delete(object user)
        {

            throw new NotSupportedException();
        }
        public object Get(int id)
        {
            try
            {
                using RivkiGvirerContext ctx = new RivkiGvirerContext();
                var users = ctx.Users.ToList();
                return users[id];
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
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

        public bool Update(object user)
        {
            try
            {
                using var ctx = new RivkiGvirerContext();
                ctx.Users.Update((User)user);
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
