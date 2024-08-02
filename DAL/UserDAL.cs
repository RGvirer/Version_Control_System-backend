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
        private readonly RivkiGvirerContext dbContext;
        public UserDal(RivkiGvirerContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public bool AddNew(object user)
        {
            try
            {
                dbContext.Users.Add((User)user);
                dbContext.SaveChanges();
                return true;
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
                dbContext.Users.Remove((User)user);
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
                return dbContext.Users.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }


        public List<object> GetAll(Func<object, bool>? condition = null)
        {
            try
            {
                var users = dbContext.Users.ToList();
                return condition == null ? users.Cast<object>().ToList() : users.Where(condition).Cast<object>().ToList();
            }
            catch (Exception)
            {
                return new List<object>();
            }
        }

        public List<object> GetAll()
        {
                throw new NotImplementedException();
            }

        public bool Update(object user)
        {
            try
            {
                dbContext.Users.Update((User)user);
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
