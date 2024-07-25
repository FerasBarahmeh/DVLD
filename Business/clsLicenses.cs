using DVLD_DataAccess_Layer;
using System;
using System.Data;

namespace Business
{
    public class clsLicenses
    {
        public enum enMode { Insert = 0, Update = 1 };
        public enMode Mode = enMode.Insert;
        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };
        public clsDriver DriverInfo;
        public int LicenseID { set; get; }
        public int ApplicationID { set; get; }
        public int DriverID { set; get; }
        public int LicenseClass { set; get; }
        public clsLicenseClass LicenseClassIfo;
        public DateTime IssueDate { set; get; }
        public DateTime ExpirationDate { set; get; }
        public string Notes { set; get; }
        public float PaidFees { set; get; }
        public bool IsActive { set; get; }
        public string IsActiveText
        {
            get
            {
                switch (IsActive)
                {
                    case true:
                        return "Yes";
                    case false:
                        return "No";
                    default:
                        return "None";
                }
            }
        }
        public enIssueReason IssueReason { set; get; }
        public string IssueReasonText
        {
            get
            {
                return GetIssueReasonText(this.IssueReason);
            }
        }
        public int CreatedByUserID { set; get; }
        public clsDetainedLicense DetainedInfo { set; get; }
        public bool IsDetained
        {
            get { return clsDetainedLicense.IsLicenseDetained(this.LicenseID); }
        }
        public clsLicenses()

        {
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClass = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = 0;
            this.IsActive = true;
            this.IssueReason = enIssueReason.FirstTime;
            this.CreatedByUserID = -1;

            Mode = enMode.Insert;

        }

        public clsLicenses(int LicenseID, int ApplicationID, int DriverID, int LicenseClass,
            DateTime IssueDate, DateTime ExpirationDate, string Notes,
            float PaidFees, bool IsActive, enIssueReason IssueReason, int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;
            this.DriverInfo = clsDriver.FindByDriverID(this.DriverID);
            this.LicenseClassIfo = clsLicenseClass.Find(this.LicenseClass);
            this.DetainedInfo = clsDetainedLicense.FindByLicenseID(this.LicenseID);
            Mode = enMode.Update;
        }

        public static int GetActiveLicenseIDByPersonID(int ApplicationPersonID, int LicenseClassID)
        {
            return clsLicensesData.GetActiveLicenseIDByPersonID(ApplicationPersonID, LicenseClassID);
        }
        private bool _Insert()
        {
            this.LicenseID = clsLicensesData.Insert(this.ApplicationID, this.DriverID, this.LicenseClass,
               this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees,
               this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);

            return (this.LicenseID != -1);
        }
        private bool _Update()
        {
            return clsLicensesData.Update(this.ApplicationID, this.LicenseID, this.DriverID, this.LicenseClass,
            this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees,
            this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Insert:
                    if (_Insert())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _Update();

            }

            return false;
        }

        public bool IsLicenseExpired()
        {
            return (ExpirationDate < DateTime.Now);
        }
        public static string GetIssueReasonText(enIssueReason IssueReason)
        {
            switch (IssueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.DamagedReplacement:
                    return "Replacement for Damaged";
                case enIssueReason.LostReplacement:
                    return "Replacement for Lost";
                default:
                    return "First Time";
            }
        }
        public static clsLicenses Find(int LicenseID)
        {
            int ApplicationID = -1; int DriverID = -1; int LicenseClass = -1;
            DateTime IssueDate = DateTime.Now; DateTime ExpirationDate = DateTime.Now;
            string Notes = "";
            float PaidFees = 0; bool IsActive = true; int CreatedByUserID = 1;
            byte IssueReason = 1;
            if (clsLicensesData.GetLicenseInfoByID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass,
            ref IssueDate, ref ExpirationDate, ref Notes,
            ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))

                return new clsLicenses(LicenseID, ApplicationID, DriverID, LicenseClass,
                                     IssueDate, ExpirationDate, Notes,
                                     PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            else
                return null;

        }

        public static bool IsPersonHasLicense(int PersonID, int LicenseClassID)
        {
            return clsLicensesData.IsPersonHasLicense(PersonID, LicenseClassID);
        }

        public static DataTable GetLicenseByDriverID(int DriverID)
        {
            return clsLicensesData.GetLicenseByDriverID(DriverID);
        }
        public bool CanUpgradeToBeInternational()
        {
            return LicenseClass == 3;
        }
        public bool Deactivate()
        {
            return (clsLicensesData.DeactivateLicense(this.LicenseID));
        }
        public clsLicenses RenewLicense(string Notes, int CreatedByUserID)
        {
            clsApplication Application = new clsApplication();

            Application.ApplicationPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.RenewDrivingLicense;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicense).ApplicationTypeFees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
                return null;
            clsLicenses NewLicense = new clsLicenses();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClass = this.LicenseClass;
            NewLicense.IssueDate = DateTime.Now;

            int DefaultValidityLength = this.LicenseClassIfo.DefaultValidityLength;

            NewLicense.ExpirationDate = DateTime.Now.AddYears(DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = this.LicenseClassIfo.ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = clsLicenses.enIssueReason.Renew;
            NewLicense.CreatedByUserID = CreatedByUserID;

            if (!NewLicense.Save()) return null;

            Deactivate();

            return NewLicense;
        }
        public clsLicenses Replacement(clsApplication.enApplicationType applicationType, int CreatedBy)
        {
            clsApplication Application = new clsApplication();

            Application.ApplicationPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.RenewDrivingLicense;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.Find((int)applicationType).ApplicationTypeFees;
            Application.CreatedByUserID = CreatedBy;

            if (!Application.Save())
                return null;
            clsLicenses NewLicense = new clsLicenses();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClass = this.LicenseClass;
            NewLicense.IssueDate = DateTime.Now;

            int DefaultValidityLength = this.LicenseClassIfo.DefaultValidityLength;

            NewLicense.ExpirationDate = DateTime.Now.AddYears(DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = this.LicenseClassIfo.ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason =
                (applicationType == clsApplication.enApplicationType.ReplaceDamagedDrivingLicense)
                ? clsLicenses.enIssueReason.DamagedReplacement
                : clsLicenses.enIssueReason.LostReplacement;


            NewLicense.CreatedByUserID = CreatedBy;

            if (!NewLicense.Save()) return null;

            Deactivate();

            return NewLicense;

        }
        public bool ReleaseDetainedLicense(int ReleasedByUserID, ref int ApplicationID)
        {
            clsApplication Application = new clsApplication();

            Application.ApplicationPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationType.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense).ApplicationTypeFees;
            Application.CreatedByUserID = ReleasedByUserID;

            if (!Application.Save())
            {
                ApplicationID = -1;
                return false;
            }

            ApplicationID = Application.ApplicationID;


            return this.DetainedInfo.ReleaseDetainedLicense(ReleasedByUserID, Application.ApplicationID);

        }
        public int Detain(float FineFees, int CreatedByUserID)
        {
            clsDetainedLicense detainedLicense = new clsDetainedLicense();
            detainedLicense.LicenseID = this.LicenseID;
            detainedLicense.DetainDate = DateTime.Now;
            detainedLicense.FineFees = Convert.ToSingle(FineFees);
            detainedLicense.CreatedByUserID = CreatedByUserID;

            if (!detainedLicense.Save())
            {

                return -1;
            }

            return detainedLicense.DetainID;

        }
    }
}
