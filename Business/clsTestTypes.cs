
using DVLD_DataAccess_Layer;
using System.Data;

namespace Business
{
    public class clsTestTypes
    {
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };

        private enum _enMode { Update, Add }
        private _enMode _Mode;
        public int TestTypeID;
        public string TestTypeTitle;
        public string TestTypeDescription;
        public string TestTypeFees;

        public clsTestTypes()
        {
            this.TestTypeID = -1;
            this.TestTypeTitle = string.Empty;
            this.TestTypeDescription = string.Empty;
            this.TestTypeFees = string.Empty;
            _Mode = _enMode.Add;
        }

        public clsTestTypes(int TestTypeID, string TestTypeTitle, string TestTypeDescription, string TestTypeFees)
        {
            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;
            _Mode = _enMode.Update;
        }

        public static clsTestTypes Find(int TestID)
        {
            string TestTypeTitle = "", TestTypeDescription = "", TestTypeFees = "";
            if (clsTestTypesData.Find(TestID, ref TestTypeTitle, ref TestTypeDescription, ref TestTypeFees))
            {
                return new clsTestTypes(TestID, TestTypeTitle, TestTypeDescription, TestTypeFees);
            }
            return null;
        }

        public static DataTable All()
        {
            return clsTestTypesData.All();
        }

        private bool _Update()
        {
            return clsTestTypesData.Update(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);
        }

        public bool Save()
        {
            bool Result = false;

            if (_Mode == _enMode.Update)
                Result = _Update();

            return Result;
        }
        public static bool IsExist(string TestTypeTitle)
        {
            return clsTestTypesData.IsExist(TestTypeTitle);
        }
    }
}
