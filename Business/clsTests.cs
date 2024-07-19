using DVLD_DataAccess_Layer;

namespace Business
{
    public class clsTests
    {
        public static int GetPassedTestsCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTestsData.GetPassedTestsCount(LocalDrivingLicenseApplicationID);
        }
    }
}
