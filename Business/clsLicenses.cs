using DVLD_DataAccess_Layer;

namespace Business
{
    public class clsLicenses
    {
        public static int GetActiveLicenseIDByPersonID(int ApplicationpersonID, int LicenseClassID)
        {
            return clsLicensesData.GetActiveLicenseIDByPersonID(ApplicationpersonID, LicenseClassID);
        }
    }
}
