using AutoMapper;
using DAL.Models;
using DataTransferObjects;

namespace DAL
{
    public class DepartmentDal : IDAL.IDepartmentDAL
    {
        private readonly RivkiGvirerContext dbContext;
        private readonly IMapper mapper;

        public DepartmentDal(RivkiGvirerContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }

        public bool AddNew(DepartmentDTO department)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DepartmentDTO, Department>();
                });

                var localMapper = config.CreateMapper();
                var entity = localMapper.Map<Department>(department);

                dbContext.Departments.Add(entity);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(DepartmentDTO departmentDto)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DepartmentDTO, Department>();
                });

                var localMapper = config.CreateMapper();
                var departmentEntity = localMapper.Map<Department>(departmentDto);

                var departmentToDelete = dbContext.Departments.Find(departmentEntity.DepartmentId);
                if (departmentToDelete != null)
                {
                    dbContext.Departments.Remove(departmentToDelete);
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

        public DepartmentDTO Get(int id)
        {
            try
            {
                var department = dbContext.Departments.Find(id);
                if (department == null) return null;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Department, DepartmentDTO>();
                });

                var localMapper = config.CreateMapper();
                return localMapper.Map<DepartmentDTO>(department);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<DepartmentDTO> GetAll()
        {
            try
            {
                var departments = dbContext.Departments.ToList();

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Department, DepartmentDTO>();
                });

                var localMapper = config.CreateMapper();
                return departments.Select(department => localMapper.Map<DepartmentDTO>(departments)).ToList();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public bool Update(DepartmentDTO department)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DepartmentDTO, Department>();
                });

                var localMapper = config.CreateMapper();
                var entity = localMapper.Map<Department>(department);

                dbContext.Departments.Update(entity);
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
