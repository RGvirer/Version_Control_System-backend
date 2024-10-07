using DataTransferObjects;
using IDAL;

namespace BL
{
    public class RepositoryServices : IBL.IRepositoryBL
    {
        private readonly IRepositoryDAL repositoryDal;
        public RepositoryServices(IRepositoryDAL _repositoryDAL)
        {
            repositoryDal = _repositoryDAL;
        }

        public bool AddNew(RepositoryDTO repository)
        {
            try
            {
                if (repository.OwnerId <= 0)
                {
                    throw new ArgumentException("OwnerId must be a valid user ID.");
                }

                return repositoryDal.AddNew(repository);
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
                RepositoryDTO repositoryDto = repositoryDal.GetAll().Find(repository => repository.RepositoryId == id) ?? new RepositoryDTO();
                return repositoryDal.Delete(repositoryDto);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public RepositoryDTO Get(int id)
        {
            try
            {
                RepositoryDTO repositoryDto = repositoryDal.GetAll().Find(repository => repository.RepositoryId == id) ?? new RepositoryDTO();
                return repositoryDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<RepositoryDTO> GetAll()
        {
            try
            {
                return repositoryDal.GetAll();
            }
            catch (Exception)
            {
                return new List<RepositoryDTO>();
            }
        }


        public bool Update(RepositoryDTO repository)
        {
            try
            {
                return repositoryDal.Update(repository);
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
