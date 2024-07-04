
using DVLD_DataAccess_Layer;
using System;
using System.Data;

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

        public clsLocalDrivingLicenseApplication(
            int LocalDrivingLicenseApplicationID,
            int ApplicationID,
            int ApplicantPersonID,
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
            this.ApplicantPersonID = ApplicantPersonID;
            this.LicenseClassID = LicenseClassID;
            this.ApplicationTypeID = ApplicationTypeID;
            this.CreatedByUserID = CreatedByUserID;
            this.PaidFees = PaidFees;
            this.ApplicationDate = ApplicationDate;
            this.LastStatusDate = LastStatusDate;
            this.ApplicationStatus = ApplicationStatus;
        }

        public static DataTable All()
        {
            return clsLocalDrivingLicenseApplicationData.All();
        }
    }
}
