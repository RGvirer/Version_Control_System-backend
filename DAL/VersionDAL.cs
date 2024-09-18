using AutoMapper;
using DAL.Models;
using DataTransferObjects;

namespace DAL
{
    internal class VersionDAL
    {
        private readonly VersionMmanagementSystemContext dbContext;
        private readonly IMapper mapper;

        public VersionDAL(VersionMmanagementSystemContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }

        public bool AddNew(VersionDTO version)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<VersionDTO, Models.Version>();
                });

                var localMapper = config.CreateMapper();
                var entity = localMapper.Map<Models.Version>(version);

                dbContext.Versions.Add(entity);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(VersionDTO versionDto)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<VersionDTO, Models.Version>();
                });

                var localMapper = config.CreateMapper();
                var versionEntity = localMapper.Map<Models.Version>(versionDto);

                var versionToDelete = dbContext.Versions.Find(versionEntity.VersionId);
                if (versionToDelete != null)
                {
                    dbContext.Versions.Remove(versionToDelete);
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

        public VersionDTO Get(int id)
        {
            try
            {
                var version = dbContext.Versions.Find(id);
                if (version == null) return null;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Models.Version, VersionDTO>();
                });

                var localMapper = config.CreateMapper();
                return localMapper.Map<VersionDTO>(version);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<VersionDTO> GetAll()
        {
            try
            {
                var versions = dbContext.Versions.ToList();

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Models.Version, VersionDTO>();
                });

                var localMapper = config.CreateMapper();
                return versions.Select(version => localMapper.Map<VersionDTO>(versions)).ToList();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public bool Update(VersionDTO version)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<VersionDTO, Models.Version>();
                });

                var localMapper = config.CreateMapper();
                var entity = localMapper.Map<Models.Version>(version);

                dbContext.Versions.Update(entity);
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
