using System;
using System.Data.SqlClient;

namespace DVLD_DataAccess_Layer
{
    public class clsTestsData
    {
        public static int GetPassedTestsCount(int LocalDrivingLicenseApplicationID)
        {
            byte PassedTestCount = 0;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"
                SELECT NumberOfPassedTests = COUNT(TestID)
                FROM Tests
                INNER JOIN TestAppointments
                ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                WHERE Tests.TestResult = 1
                AND TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;
            ";

            SqlCommand command = new SqlCommand(Query, conn);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                conn.Open();

                object Result = command.ExecuteScalar();

                if (Result != null && byte.TryParse(Result.ToString(), out byte ptCount))
                    PassedTestCount = ptCount;
            }

            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }

            return PassedTestCount;
        }
    }
}
