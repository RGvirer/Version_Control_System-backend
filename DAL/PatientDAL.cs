using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using WebApplication1.Models;

namespace DAL
{
    public class PatientDAL : IDAL.IObjectDAL
    {
        public bool AddNew(object patient)
        {

            try
            {
                using var ctx = new RivkiGvirerContext();
                ctx.Patients.Add((Patient)patient);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Delete(object patient)
        {
            try
            {
                using var ctx = new RivkiGvirerContext();
                ctx.Patients.Remove((Patient)patient);
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
                var patients = ctx.Patients.ToList();
                return condition == null ? patients.Cast<object>().ToList() : patients.Where(condition).Cast<object>().ToList();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public bool Update(object patient)
        {
            try
            {
                using var ctx = new RivkiGvirerContext();
                ctx.Patients.Update((Patient)patient);
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
