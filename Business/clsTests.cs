﻿using DVLD_DataAccess_Layer;

namespace Business
{
    public class clsTests
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int TestID { set; get; }
        public int TestAppointmentID { set; get; }
        public clsTestAppointments TestAppointmentInfo { set; get; }
        public bool TestResult { set; get; }
        public string Notes { set; get; }
        public int CreatedByUserID { set; get; }

        public clsTests()
        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = "";
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }
        public clsTests(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)

        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestAppointmentInfo = clsTestAppointments.Find(TestAppointmentID);
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;

            Mode = enMode.Update;
        }


        public static int GetPassedTestsCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTestsData.GetPassedTestsCount(LocalDrivingLicenseApplicationID);
        }
        public static clsTests FindLastTestPerPersonAndLicenseClass(int PersonID, int LicenseClassID, clsTestTypes.enTestType TestTypeID)
        {
            int TestID = -1;
            int TestAppointmentID = -1;
            bool TestResult = false; string Notes = ""; int CreatedByUserID = -1;

            bool Flag = clsTestsData.GetLastTestByPersonAndTestTypeAndLicenseClass(
                PersonID,
                LicenseClassID,
                (int)TestTypeID,
                ref TestID,
                ref TestAppointmentID,
                ref TestResult,
                ref Notes,
                ref CreatedByUserID);

            if (Flag)
                return new clsTests(TestID,
                        TestAppointmentID, TestResult,
                        Notes, CreatedByUserID);

            return null;

        }
        private bool _InsertTest()
        {
            this.TestID = clsTestsData.Insert(this.TestAppointmentID,
                this.TestResult, this.Notes, this.CreatedByUserID);

            return (this.TestID != -1);
        }
        private bool _UpdateTest()
        {
            return clsTestsData.Update(this.TestID, this.TestAppointmentID,
                this.TestResult, this.Notes, this.CreatedByUserID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_InsertTest())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateTest();

            }

            return false;
        }

    }
}
