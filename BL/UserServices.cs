using DataTransferObjects;
using IBL;
using IDAL;

namespace BL
{
    public class UserServices : IUserBL
    {
        private readonly IUserDAL userDal;
        public UserServices(IUserDAL _userDal)
        {
            userDal = _userDal;
        }

        public bool AddNew(UserDTO user)
        {
            try
            {
                var success = userDal.AddNew(user);
                if (!success)
                {
                    Console.WriteLine("Failed to add user in BL.");
                }
                return success;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddNew method: {ex.Message}");
                return false;
            }
        }


        public bool Delete(int id)
        {
            try
            {
                UserDTO userDto = userDal.GetAll().Find(user => user.UserId == id) ?? new UserDTO();
                return userDal.Delete(userDto);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public UserDTO Get(int id)
        {
            try
            {
                UserDTO userDto = userDal.GetAll().Find(user => user.UserId == id) ?? new UserDTO();
                return userDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        public List<UserDTO> GetAll()
        {
            try
            {
                return userDal.GetAll();
            }
            catch (Exception)
            {
                return new List<UserDTO>();
            }
        }


        public bool Update(UserDTO user)
        {
            try
            {
                return userDal.Update(user);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
