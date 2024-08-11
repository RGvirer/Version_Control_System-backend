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
        private readonly IPatientDAL patientDal;
        public PatientsServices(IPatientDAL _patientDAL)
        {
            patientDal = _patientDAL;
        }

        public bool AddNew(PatientDTO patient)
        {
            try
            {
                return patientDal.AddNew(patient);
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
                PatientDTO patientDto = patientDal.GetAll().Find(patient => patient.PatientId == id) ?? new PatientDTO();
                return patientDal.Delete(patientDto);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public PatientDTO Get(int id)
        {
            try
            {
                PatientDTO patientDto = patientDal.GetAll().Find(patient => patient.PatientId == id) ?? new PatientDTO();
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
                return patientDal.GetAll();
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
                return patientDal.Update(patient);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
