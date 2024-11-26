using AutoMapper;
using DAL.Models;
using DataTransferObjects;

namespace DAL
{
    public class MergeDAL:IDAL.IMergeDAL
    {
        private readonly VersionMmanagementSystemContext dbContext;
        private readonly IMapper mapper;

        public MergeDAL(VersionMmanagementSystemContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }

        public bool AddNew(MergeDTO merge)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<MergeDTO, Merge>();
                });

                var localMapper = config.CreateMapper();
                var entity = localMapper.Map<Merge>(merge);

                dbContext.Merges.Add(entity);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(MergeDTO mergeDto)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<MergeDTO, Merge>();
                });

                var localMapper = config.CreateMapper();
                var mergeEntity = localMapper.Map<Merge>(mergeDto);

                var mergeToDelete = dbContext.Merges.Find(mergeEntity.MergeId);
                if (mergeToDelete != null)
                {
                    dbContext.Merges.Remove(mergeToDelete);
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

        public MergeDTO Get(int id)
        {
            try
            {
                var merge = dbContext.Merges.Find(id);
                if (merge == null) return null;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Merge, MergeDTO>();
                });

                var localMapper = config.CreateMapper();
                return localMapper.Map<MergeDTO>(merge);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<MergeDTO> GetAll()
        {
            try
            {
                var merges = dbContext.Merges.ToList();

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Merge, MergeDTO>();
                });

                var localMapper = config.CreateMapper();
                return merges.Select(merge => localMapper.Map<MergeDTO>(merge)).ToList();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public bool Update(MergeDTO merge)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<MergeDTO, Merge>();
                });

                var localMapper = config.CreateMapper();
                var entity = localMapper.Map<Merge>(merge);

                dbContext.Merges.Update(entity);
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
