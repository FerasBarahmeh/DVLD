using DVLD_DataAccess_Layer;
using System.Data;

namespace Business
{
    public class clsApplicationType
    {
        private enum _enMode { Update, Add }
        private _enMode _Mode;
        public int ApplicatonTypeID;
        public string ApplicatonTypeTitle;
        public string ApplicationTypeFees;

        public clsApplicationType() 
        {
            this.ApplicatonTypeID = -1;
            this.ApplicatonTypeTitle = string.Empty;
            this.ApplicationTypeFees = string.Empty;
            _Mode = _enMode.Add;
        }
        public clsApplicationType(int ApplicatonTypeID, string ApplicatonTypeTitle, string ApplicatonTypeFees)
        {
            this.ApplicatonTypeID = ApplicatonTypeID;
            this.ApplicatonTypeTitle = ApplicatonTypeTitle;
            this.ApplicationTypeFees = ApplicatonTypeFees;
            _Mode = _enMode.Update;
        }
        public static DataTable All()
        {
            return clsApplicationTypesData.All();
        }

        public static clsApplicationType Find(int ApplicatonTypeID)
        {
            string ApplicatonTypeFees = "", ApplicatonTypeTitle = "";
            if (clsApplicationTypesData.Find(ApplicatonTypeID, ref ApplicatonTypeTitle, ref ApplicatonTypeFees))
                return new clsApplicationType(ApplicatonTypeID, ApplicatonTypeTitle, ApplicatonTypeFees);

            return null;

        }

        private bool _Update()
        {
            return clsApplicationTypesData.Update(ApplicatonTypeID, ApplicatonTypeTitle, ApplicationTypeFees);
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
