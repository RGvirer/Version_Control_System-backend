using AutoMapper;
using DAL.Models;
using DataTransferObjects;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class RepositoryDal : IDAL.IRepositoryDAL
    {
        private readonly VersionMmanagementSystemContext dbContext;
        private readonly IMapper mapper;

        public RepositoryDal(VersionMmanagementSystemContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }

        public bool AddNew(RepositoryDTO repository)
        {
            try
            {

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RepositoryDTO, Repository>();
                        //.ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                        //.ReverseMap();

                    //cfg.CreateMap<UserDTO, User>()
                      //  .ReverseMap();
                });

                var localMapper = config.CreateMapper();
                var entity = localMapper.Map<Repository>(repository);

                dbContext.Repositories.Add(entity);
                var changes=dbContext.SaveChanges();
                if (changes == 0)
                {
                    Console.WriteLine("No changes were saved to the database.");
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Delete(RepositoryDTO repositoryDto)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RepositoryDTO, Repository>()
                        .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                        .ReverseMap();

                    cfg.CreateMap<UserDTO, User>()
                        .ReverseMap();
                });

                var localMapper = config.CreateMapper();
                var repositoryEntity = localMapper.Map<Repository>(repositoryDto);

                var repositoryToDelete = dbContext.Repositories.Find(repositoryEntity.RepositoryId);
                if (repositoryToDelete != null)
                {
                    dbContext.Repositories.Remove(repositoryToDelete);
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

        public RepositoryDTO Get(int id)
        {
            try
            {
                var repository = dbContext.Repositories.Find(id);
                if (repository == null) return null;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RepositoryDTO, Repository>()
                        .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                        .ReverseMap();

                    cfg.CreateMap<UserDTO, User>()
                        .ReverseMap();
                });

                var localMapper = config.CreateMapper();
                return localMapper.Map<RepositoryDTO>(repository);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<RepositoryDTO> GetAll()
        {
            try
            {
                var repositorys = dbContext.Repositories
                    .Include(u => u.Branches)
                    .ToList();

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Branch, BranchDTO>();
                    cfg.CreateMap<RepositoryDTO, Repository>()
                        .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                        .ReverseMap();

                    //cfg.CreateMap<UserDTO, User>()
                    //    .ReverseMap();
                });

                var localMapper = config.CreateMapper();
                return repositorys.Select(repository => localMapper.Map<RepositoryDTO>(repository)).ToList();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public bool Update(RepositoryDTO repository)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RepositoryDTO, Repository>()
                        .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                        .ReverseMap();

                    cfg.CreateMap<UserDTO, User>()
                        .ReverseMap();
                });

                var localMapper = config.CreateMapper();
                var entity = localMapper.Map<Repository>(repository);

                dbContext.Repositories.Update(entity);
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
