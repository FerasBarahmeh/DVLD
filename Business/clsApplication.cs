using DVLD_DataAccess_Layer;
using System;

namespace Business
{
    public class clsApplication
    {
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };
        public enum enApplicationType
        {
            NewDrivingLicense = 1,
            RenewDrivingLicense = 2,
            ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4,
            ReleaseDetainedDrivingLicense = 5,
            NewInternationalLicense = 6,
            RetakeTest = 7
        };
        protected enum enMode { Update = 1, Insert = 2 }
        protected enMode Mode;
        public int ApplicationID { get; set; }
        public int ApplicationPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public enApplicationStatus ApplicationStatus;
        public DateTime LastStatusDate;
        public float PaidFees;
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByInfo;
        public string ApplicationStatusName
        {
            get
            {
                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknown";
                }
            }
        }

        public clsApplicationType ApplicationType;
        public clsApplication()
        {
            Mode = enMode.Insert;
            ApplicationID = -1;
            ApplicationPersonID = -1;
            ApplicationDate = DateTime.MinValue;
            ApplicationTypeID = -1;
            ApplicationStatus = enApplicationStatus.New;
            LastStatusDate = DateTime.MinValue;
            PaidFees = 0;
            CreatedByUserID = -1;
        }

        private clsApplication(int ApplicationID, int ApplicantPersonID,
         DateTime ApplicationDate, int ApplicationTypeID,
          enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
          float PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicationPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationType = clsApplicationType.Find(ApplicationTypeID);
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByInfo = clsUser.Find(CreatedByUserID);
            Mode = enMode.Update;
        }

        public static int GetActiveApplicationIDForLicenseClass(int ApplicationPersonID, enApplicationType ApplicationType, int LicenseClassID)
        {
            return clsApplicationData.GetActiveApplicationIDForLicenseClass(ApplicationPersonID, (int)ApplicationType, LicenseClassID);
        }

        private bool _Insert()
        {
            ApplicationID = clsApplicationData.Insert(ApplicationPersonID, ApplicationDate, ApplicationTypeID, (short)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            return ApplicationID != -1;
        }

        private bool _Update()
        {
            return false;
        }

        public virtual bool Save()
        {
            switch (Mode)
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

        public static clsApplication FindBaseApplicationByID(int ApplicationID)
        {

            int ApplicationPersonID = -1, ApplicationTypeID = -1, CreatedByUserID = -1;
            float PaidFees = 0; short ApplicationStatus = 0;
            DateTime ApplicationDate = DateTime.MinValue, LastStatusDate = DateTime.MinValue;

            bool IsFound = clsApplicationData.Find(
                ApplicationID,
                ref ApplicationPersonID,
                ref ApplicationDate,
                ref ApplicationTypeID,
                ref ApplicationStatus,
                ref LastStatusDate,
                ref PaidFees,
                ref CreatedByUserID
            );

            if (IsFound)
                return new clsApplication(ApplicationID, ApplicationPersonID, ApplicationDate, ApplicationTypeID, (enApplicationStatus)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);

            return null;
        }
    }
}
