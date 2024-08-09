using System;
using System.Collections.Generic;
using System.Linq;
using DataTransferObjects;
using IDAL;
using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class PatientsServices : IBL.IPatientBL
    {
        private readonly IPatientDAL patientDAL;
        public PatientsServices(IPatientDAL _patientDAL)
        {
            patientDAL = _patientDAL;
        }

        public bool AddNew(PatientDTO patient)
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

        public bool Delete(int id)
        {
            try
            {
                PatientDTO patientDto = patientDAL.GetAll().Find(patient => patient.PatientId == id) ?? new PatientDTO();
                return patientDAL.Delete(patientDto);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Get(int id)
        {
            try
            {
                PatientDTO patientDto = patientDal.GetAll().Find(patient => patient.UserId == id) ?? new UserDTO();
                return patientDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<PatientDTO> GetAll()
        {
            try
            {
                return patientDAL.GetAll();
            }
            catch (Exception)
            {
                return new List<PatientDTO>();
            }
        }


        public bool Update(PatientDTO patient)
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
