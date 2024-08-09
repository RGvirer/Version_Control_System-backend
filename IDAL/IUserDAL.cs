using DataTransferObjects;

namespace IDAL
{
    public interface IUserDAL
    {
        public bool AddNew(UserDTO entity);
        public UserDTO Get(int id);
        public List<UserDTO> GetAll();
        public bool Update(UserDTO entity);
        public bool Delete(UserDTO entity);

    }
}
