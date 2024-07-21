using DVLD_DataAccess_Layer;
using System;
using System.Data;

namespace Business
{
    public class clsDriver
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public clsPerson PersonInfo;
        public int DriverID { set; get; }
        public int PersonID { set; get; }
        public int CreatedByUserID { set; get; }
        public DateTime CreatedDate { get; }

        public clsDriver()
        {
            DriverID = -1;
            PersonID = -1;
            CreatedByUserID = -1;
            CreatedDate = DateTime.Now;
            Mode = enMode.AddNew;
        }

        public clsDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
            this.PersonInfo = clsPerson.Find(PersonID);

            Mode = enMode.Update;
        }

        private bool _AddNewDriver()
        {
            DriverID = clsDriversData.Insert(PersonID, CreatedByUserID);
            return (this.DriverID != -1);
        }

        private bool _UpdateDriver()
        {
            return clsDriversData.UpdateDriver(DriverID, PersonID, CreatedByUserID);
        }

        public static clsDriver FindByDriverID(int DriverID)
        {
            int PersonID = -1; int CreatedByUserID = -1; DateTime CreatedDate = DateTime.Now;

            if (clsDriversData.GetDriverInfoByDriverID(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate))
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            return null;
        }

        public static clsDriver FindByPersonID(int PersonID)
        {
            int DriverID = -1; int CreatedByUserID = -1; DateTime CreatedDate = DateTime.Now;

            if (clsDriversData.GetDriverInfoByPersonID(PersonID, ref DriverID, ref CreatedByUserID, ref CreatedDate))
                return new clsDriver(DriverID, PersonID, CreatedByUserID, CreatedDate);
            return null;
        }

        public static DataTable GetAllDrivers()
        {
            return clsDriversData.GetAllDrivers();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDriver())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateDriver();

            }

            return false;
        }
    }
}
