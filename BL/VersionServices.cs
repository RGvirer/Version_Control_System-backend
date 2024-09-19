using DataTransferObjects;
using IBL;
using IDAL;

namespace BL
{
    internal class VersionServices : IVersionBL
    {
        private readonly IVersionDAL versionDal;
        public VersionServices(IVersionDAL _versionDal)
        {
            versionDal = _versionDal;
        }

        public bool AddNew(VersionDTO version)
        {
            try
            {
                var success = versionDal.AddNew(version);
                if (!success)
                {
                    Console.WriteLine("Failed to add version in BL.");
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
                VersionDTO versionDto = versionDal.GetAll().Find(version => version.VersionId == id) ?? new VersionDTO();
                return versionDal.Delete(versionDto);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public VersionDTO Get(int id)
        {
            try
            {
                VersionDTO versionDto = versionDal.GetAll().Find(version => version.VersionId == id) ?? new VersionDTO();
                return versionDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        public List<VersionDTO> GetAll()
        {
            try
            {
                return versionDal.GetAll();
            }
            catch (Exception)
            {
                return new List<VersionDTO>();
            }
        }


        public bool Update(VersionDTO version)
        {
            try
            {
                return versionDal.Update(version);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
