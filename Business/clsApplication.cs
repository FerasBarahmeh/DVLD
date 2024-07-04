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
            ReleaseDetainedDrivingLicsense = 5,
            NewInternationalLicense = 6,
            RetakeTest = 7
        };

        protected enum enMode { Update = 1, Insert = 2 }
        protected enMode Mode;
        public int ApplicationPersonID { get; set; }

        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public int ApplicationTypeID { get; set; }
        public int CreatedByUserID { get; set; }
        public clsPersone CreatedByInfo;
        public float PaidFees;
        public DateTime ApplicationDate;
        public DateTime LastStatusDate;
        public enApplicationStatus ApplicationStatus;
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

        public clsApplication()
        {
            Mode = enMode.Insert;
            ApplicationPersonID = -1;
            ApplicationTypeID = -1;
            ApplicantPersonID = -1;
            ApplicationTypeID = -1;
            ApplicationStatus = enApplicationStatus.New;
            LastStatusDate = DateTime.MinValue;
            PaidFees = 0;
            ApplicationDate = DateTime.MinValue;
            CreatedByUserID = -1;
        }

    }
}
