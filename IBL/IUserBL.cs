using DataTransferObjects;

namespace IBL
{
    public interface IUserBL
    {
        public List<UserDTO> GetAll();
        public UserDTO Get(int id);
        public bool AddNew(UserDTO item);
        public bool Delete(int id);
        public bool Update(UserDTO item);
    }
}
