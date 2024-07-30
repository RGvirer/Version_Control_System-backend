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
            try
            {
                using var ctx = new Rivki_Gvirer(); // השתמש בקונטקסט שלך
                ctx.User.Add(item); // הוסף את המודל שלך
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
                using var ctx = new Rivki_Gvirer(); // השתמש בקונטקסט שלך
                ctx.User.Remove(item); // הסר את המודל שלך
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
                using var ctx = new Rivki_Gvirer(); // השתמש בקונטקסט שלך
                var groupPermissions = ctx.User.ToList();
                return condition == null ? groupPermissions : groupPermissions.Where(condition).ToList();
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
                using var ctx = new Rivki_Gvirer(); // השתמש בקונטקסט שלך
                ctx.User.Update(item); // עדכן את המודל שלך
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
