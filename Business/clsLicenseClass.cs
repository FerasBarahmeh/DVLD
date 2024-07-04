using DVLD_DataAccess_Layer;
using System.Data;

namespace Business
{
    public class clsLicenseClass
    {
        public static DataTable All()
        {
            return clsLicenseClassData.All();
        }
    }
}
