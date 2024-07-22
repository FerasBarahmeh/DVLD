using DVLD_DataAccess_Layer;
using System;
using System.Data;

namespace Business
{
    public class clsInternationalLicense : clsApplication
    {
        private enMode _Mode = enMode.Insert;
        public int InternationalLicenseID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public clsDriver DriverInfo { get; set; }

        public clsInternationalLicense()
        {
            _Mode = enMode.Insert;
            DriverID = -1;
            IssuedUsingLocalLicenseID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            IsActive = true;
        }
        public clsInternationalLicense(
           int ApplicationID, int ApplicantPersonID,
         DateTime ApplicationDate,
          enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
          float PaidFees, int CreatedByUserID, int InternationalLicenseID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive)
        {
            // For Parent Class 
            base.ApplicationID = ApplicationID;
            base.ApplicationPersonID = ApplicantPersonID;
            base.ApplicationDate = ApplicationDate;
            base.ApplicationTypeID = (int)clsApplication.enApplicationType.NewInternationalLicense;
            base.ApplicationStatus = ApplicationStatus;
            base.LastStatusDate = LastStatusDate;
            base.PaidFees = PaidFees;
            base.CreatedByUserID = CreatedByUserID;


            // For International Class
            _Mode = enMode.Update;
            this.InternationalLicenseID = InternationalLicenseID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.DriverInfo = clsDriver.FindByDriverID(DriverID);
        }

        private bool _Insert()
        {
            this.InternationalLicenseID =
                clsInternationalLicenseData.Insert(this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID,
               this.IssueDate, this.ExpirationDate,
               this.IsActive, this.CreatedByUserID);


            return (this.InternationalLicenseID != -1);
        }
        private bool _Update()
        {
            return clsInternationalLicenseData.Update(
                this.InternationalLicenseID, this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID,
               this.IssueDate, this.ExpirationDate,
               this.IsActive, this.CreatedByUserID);
        }
        public override bool Save()
        {
            /**
             Because of inheritance first we call the save method in the base class,
             it will take care of adding all information to the application table.
           */
            base.Mode = (clsApplication.enMode)Mode;
            if (!base.Save())
                return false;

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
        public static DataTable All()
        {
            return clsInternationalLicenseData.All();
        }
        public static clsInternationalLicense Find(int InternationalLicenseID)
        {
            int ApplicationID = -1;
            int DriverID = -1; int IssuedUsingLocalLicenseID = -1;
            DateTime IssueDate = DateTime.Now; DateTime ExpirationDate = DateTime.Now;
            bool IsActive = true; int CreatedByUserID = 1;

            if (clsInternationalLicenseData.GetByID(InternationalLicenseID, ref ApplicationID, ref DriverID,
                ref IssuedUsingLocalLicenseID,
            ref IssueDate, ref ExpirationDate, ref IsActive, ref CreatedByUserID))
            {
                clsApplication Application = FindBaseApplicationByID(ApplicationID);

                return new clsInternationalLicense(
                    Application.ApplicationID,
                    Application.ApplicationPersonID,
                    Application.ApplicationDate,
                    (enApplicationStatus)Application.ApplicationStatus, Application.LastStatusDate,
                    Application.PaidFees, Application.CreatedByUserID,
                    InternationalLicenseID, DriverID, IssuedUsingLocalLicenseID,
                    IssueDate, ExpirationDate, IsActive);
            }

            return null;

        }

        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {
            return clsInternationalLicenseData.GetActiveInternationalLicenseIDByDriverID(DriverID);
        }

        public static DataTable GetDriverInternationalLicenses(int DriverID)
        {
            return clsInternationalLicenseData.GetDriverInternationalLicenses(DriverID);
        }
    }
}
