using DataTransferObjects;

namespace IDAL
{
    public interface IRepositoryDAL
    {
        public bool AddNew(RepositoryDTO entity);
        public RepositoryDTO Get(int id);
        public List<RepositoryDTO> GetAll();
        public bool Update(RepositoryDTO entity);
        public bool Delete(RepositoryDTO entity);
    }
}
