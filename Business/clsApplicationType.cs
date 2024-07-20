using DVLD_DataAccess_Layer;
using System.Data;

namespace Business
{
    public class clsApplicationType
    {
        private enum _enMode { Update, Add }
        private _enMode _Mode;
        public int ApplicationTypeID;
        public string ApplicationTypeTitle;
        public float ApplicationTypeFees;

        public clsApplicationType()
        {
            this.ApplicationTypeID = -1;
            this.ApplicationTypeTitle = string.Empty;
            this.ApplicationTypeFees = float.MinValue;
            _Mode = _enMode.Add;
        }
        public clsApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, float ApplicationTypeFees)
        {
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationTypeFees = ApplicationTypeFees;
            _Mode = _enMode.Update;
        }
        public static DataTable All()
        {
            return clsApplicationTypesData.All();
        }

        public static clsApplicationType Find(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = ""; float ApplicationTypeFees = float.MinValue;
            if (clsApplicationTypesData.Find(ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationTypeFees))
                return new clsApplicationType(ApplicationTypeID, ApplicationTypeTitle, ApplicationTypeFees);

            return null;
        }

        private bool _Update()
        {
            return clsApplicationTypesData.Update(ApplicationTypeID, ApplicationTypeTitle, ApplicationTypeFees);
        }

        public bool Save()
        {
            bool Result = false;

            if (_Mode == _enMode.Update)
                Result = _Update();

            return Result;
        }

        public static bool IsExist(string ApplicationTypesTitle)
        {
            return clsApplicationTypesData.IsExist(ApplicationTypesTitle);
        }
    }
}
