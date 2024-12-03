using AutoMapper;
using DAL.Models;
using DataTransferObjects;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class UserDal : IDAL.IUserDAL
    {
        private readonly VersionMmanagementSystemContext dbContext;
        private readonly IMapper mapper;

        public UserDal(VersionMmanagementSystemContext _dbContext, IMapper _mapper)
        {
            dbContext = _dbContext;
            mapper = _mapper;
        }

        public bool AddNew(UserDTO user)
        {
            try
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<UserDTO, User>()
                       .ForMember(m => m.PasswordHash, p => p.MapFrom(a => a.Password))
                       .ReverseMap()
                       .ForMember(m => m.YearCreated, p => p.MapFrom(a => a.CreatedAt.Year));
                });

                var localMapper = config.CreateMapper();
                var entity = localMapper.Map<User>(user);

                dbContext.Users.Add(entity);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DAL AddNew: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                return false;
            }
        }

        public bool Delete(UserDTO userDto)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<UserDTO, User>();
                });

                var localMapper = config.CreateMapper();
                var userEntity = localMapper.Map<User>(userDto);
                var userToDelete = dbContext.Users.Find(userEntity.UserId);

                if (userToDelete != null)
                {
                    dbContext.Users.Remove(userToDelete);
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

        public UserDTO Get(int id)
        {
            try
            {
                var user = dbContext.Users.Find(id);
                if (user == null) return null;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<User, UserDTO>()
                       .ForMember(m => m.Password, p => p.MapFrom(a => a.PasswordHash))
                       .ForMember(m => m.YearCreated, p => p.MapFrom(a => a.CreatedAt.Year));
                });

                var localMapper = config.CreateMapper();
                return localMapper.Map<UserDTO>(user);
            }
            catch (Exception)
            {
                return null;
            }
        }

        //public bool GetAll(UserDTO item)
        //{
        //    throw new NotImplementedException();
        //}

        public List<UserDTO> GetAll()
        {
            try
            {
                var users = dbContext.Users
                    .Include(u => u.Repositories) // טעינת הקשר של הרפוזיטורים
                    .ToList();

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Repository, RepositoryDTO>();
                    cfg.CreateMap<User, UserDTO>()
                       .ForMember(m => m.Password, p => p.MapFrom(a => a.PasswordHash))
                       .ForMember(m => m.YearCreated, p => p.MapFrom(a => a.CreatedAt.Year));
                });


                var localMapper = config.CreateMapper();
                return users.Select(user => localMapper.Map<UserDTO>(user)).ToList();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public bool Update(UserDTO user)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<UserDTO, User>()
                       .ForMember(m => m.PasswordHash, p => p.MapFrom(a => a.Password));
                });

                var localMapper = config.CreateMapper();
                var entity = localMapper.Map<User>(user);

                dbContext.Users.Update(entity);
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
