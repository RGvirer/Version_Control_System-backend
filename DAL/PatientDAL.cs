using AutoMapper;
using DAL.Models;
using DataTransferObjects;


namespace DAL
{
    public class PatientDal : IDAL.IPatientDAL
    {
        private readonly RivkiGvirerContext dbContext;
        private readonly IMapper mapper;

        public PatientDal(RivkiGvirerContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }

        public bool AddNew(PatientDTO patient)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<PatientDTO, Patient>();
                });

                var localMapper = config.CreateMapper();
                var entity = localMapper.Map<Patient>(patient);

                dbContext.Patients.Add(entity);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(PatientDTO patientDto)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<PatientDTO, Patient>();
                });

                var localMapper = config.CreateMapper();
                var patientEntity = localMapper.Map<Patient>(patientDto);

                var patientToDelete = dbContext.Patients.Find(patientEntity.PatientId);
                if (patientToDelete != null)
                {
                    dbContext.Patients.Remove(patientToDelete);
                    dbContext.SaveChanges();
                    return true;
                }
                return false; // המשתמש לא נמצא
            }
            catch (Exception ex)
            {
                // טיפול בלוג או פעולות אחרות כדי להבין את הבעיה
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public PatientDTO Get(int id)
        {
            try
            {
                var patient = dbContext.Patients.Find(id);
                if (patient == null) return null;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Patient, PatientDTO>();
                });

                var localMapper = config.CreateMapper();
                return localMapper.Map<PatientDTO>(patient);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool GetAll(PatientDTO item)
        {
            throw new NotImplementedException();
        }

        public List<PatientDTO> GetAll()
        {
            try
            {
                var patients = dbContext.Patients.ToList();

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Patient, PatientDTO>();
                });

                var localMapper = config.CreateMapper();
                return patients.Select(patient => localMapper.Map<PatientDTO>(patient)).ToList();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public bool Update(PatientDTO patient)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<PatientDTO, Patient>();
                });

                var localMapper = config.CreateMapper();
                var entity = localMapper.Map<Patient>(patient);

                dbContext.Patients.Update(entity);
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