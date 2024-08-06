using System;
using System.Collections.Generic;
using System.Linq;
using IDAL;
using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class PatientsServices : IBL.IObjectBL
    {
        private readonly IObjectDAL patientDAL;
        public PatientsServices(IObjectDAL _patientDAL)
        {
            patientDAL = _patientDAL;
        }

        public bool AddNew(object patient)
        {
            try
            {
                return patientDAL.AddNew(patient);
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
                return patientDAL.Delete(patient);
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
                return patientDAL.GetAll();
            }
            catch (Exception)
            {
                return new List<object>();
            }
        }


        public bool Update(object patient)
        {
            try
            {
                return patientDAL.Update(patient);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
