using DataTransferObjects;

namespace IBL
{
    internal interface IVersionBL
    {
        public List<VersionDTO> GetAll();
        public VersionDTO Get(int id);
        public bool AddNew(VersionDTO item);
        public bool Delete(int id);
        public bool Update(VersionDTO item);
    }
}
