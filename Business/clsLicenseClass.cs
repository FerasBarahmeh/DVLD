using DVLD_DataAccess_Layer;
using System.Data;

namespace Business
{
    public class clsLicenseClass
    {
        public int LicenseClassID;
        public string ClassName;
        public string ClassDescription;
        public short MinimumAllowedAge;
        public short DefaultValidityLength;
        public float ClassFees;

        public clsLicenseClass(
            int LicenseClassID,
            string ClassName,
            string ClassDescription,
            short MinimumAllowedAge,
            short DefaultValidityLength,
            float ClassFees
        )
        {
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
        }

        public static DataTable All()
        {
            return clsLicenseClassData.All();
        }

        public static clsLicenseClass Find(int LicenseClassID)
        {

            string ClassName = "", ClassDescription = "";
            short MinimumAllowedAge = short.MinValue, DefaultValidityLength = short.MinValue;
            float ClassFees = float.MinValue;
            clsLicenseClassData.Find(LicenseClassID, ref ClassName, ref ClassDescription, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees);
            return new clsLicenseClass(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
        }

        public static int FindIDByName(string Name)
        {
            int LicenseClassID = -1;
            bool flag = clsLicenseClassData.FindIDByName(Name, ref LicenseClassID);
            return flag ? LicenseClassID : -1;
        }
    }
}
