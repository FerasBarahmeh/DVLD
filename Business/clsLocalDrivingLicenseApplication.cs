
using DVLD_DataAccess_Layer;
using System;
using System.Data;
using System.Windows.Forms;

namespace Business
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {

        public int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public clsLicenseClass LicenseClassInfo;
        public string PersonFullName
        {
            get
            {
                return clsPersone.Find(ApplicationPersonID).FullName;
            }
        }
        public clsLocalDrivingLicenseApplication()
        {
            LocalDrivingLicenseApplicationID = -1;
            LicenseClassID = -1;
            Mode = enMode.Insert;
        }

        private clsLocalDrivingLicenseApplication(
            int LocalDrivingLicenseApplicationID,
            int ApplicationID,
            int ApplicationPersonID,
            int LicenseClassID,
            int ApplicationTypeID,
            int CreatedByUserID,
            float PaidFees,
            DateTime ApplicationDate,
            DateTime LastStatusDate,
            enApplicationStatus ApplicationStatus
        )
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.ApplicationPersonID = ApplicationPersonID;
            this.LicenseClassID = LicenseClassID;
            this.ApplicationTypeID = ApplicationTypeID;
            this.CreatedByUserID = CreatedByUserID;
            this.PaidFees = PaidFees;
            this.ApplicationDate = ApplicationDate;
            this.LastStatusDate = LastStatusDate;
            this.ApplicationStatus = ApplicationStatus;
            this.CreatedByInfo = clsUser.Find(CreatedByUserID);
            LicenseClassInfo = clsLicenseClass.Find(LicenseClassID);
            Mode = enMode.Update;
        }

        public static DataTable All()
        {
            return clsLocalDrivingLicenseApplicationData.All();
        }

        private bool _Insert()
        {
            LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationData.Insert(ApplicationID, LicenseClassID);

            return (LocalDrivingLicenseApplicationID != -1);
        }
        private bool _Update()
        {
            MessageBox.Show("LicenseClassID = " + LicenseClassID.ToString() + " ApplicationID = " + ApplicationID.ToString());
            return false;
        }

        public override bool Save()
        {
            enMode CurrentMode = base.Mode;
            if (!base.Save()) return false;

            switch (CurrentMode)
            {
                case enMode.Insert:
                    if (_Insert())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _Update();
            }
            return false;
        }

        public static clsLocalDrivingLicenseApplication FindLocalDrivingLicenseApplicationData(int LocalDrivingLicenseApplicationID)
        {

            int ApplicationID = -1, LicenseClassID = -1;

            bool IsFound = clsLocalDrivingLicenseApplicationData.Find(LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID);
            if (IsFound)
            {
                clsApplication Application = FindBaseApplicationByID(ApplicationID);

                return new clsLocalDrivingLicenseApplication(
                    LocalDrivingLicenseApplicationID,
                    ApplicationID,
                    Application.ApplicationPersonID,
                    LicenseClassID,
                    Application.ApplicationTypeID,
                    Application.CreatedByUserID,
                    Application.PaidFees,
                    Application.ApplicationDate,
                    Application.LastStatusDate,
                    Application.ApplicationStatus
                );
            }
            return null;
        }

        public static bool IsPassTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.IsPassTestType(LocalDrivingLicenseApplicationID, TestTypeID);
        }
        public static bool HasLicense(int LocalDrivingLicenseApplicationID, int LicenseClassID)
        {
            return clsLocalDrivingLicenseApplicationData.HasLicense(LocalDrivingLicenseApplicationID, LicenseClassID);
        }

        public int GetActiveLicenseID()
        {
            return clsLicenses.GetActiveLicenseIDByPersonID(this.ApplicationPersonID, this.LicenseClassID);
        }
        public int GetPassedTestsCount()
        {
            return clsTests.GetPassedTestsCount(this.LocalDrivingLicenseApplicationID);
        }

        public bool IsThereAnActiveScheduledTest(clsTestTypes.enTestType TestType)
        {
            return clsLocalDrivingLicenseApplicationData.IsThereAnActiveScheduledTest(this.LocalDrivingLicenseApplicationID, (int)TestType);
        }
        public clsTests GetLastTestPerTestType(clsTestTypes.enTestType TestTypeID)
        {
            return clsTests.FindLastTestPerPersonAndLicenseClass(this.ApplicationPersonID, this.LicenseClassID, TestTypeID);
        }
        public bool DoesAttendTestType(clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public int TotalTrialsPerTest(clsTestTypes.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
    }
}
