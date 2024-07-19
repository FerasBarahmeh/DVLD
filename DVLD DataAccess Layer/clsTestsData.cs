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
        public static bool GetLastTestByPersonAndTestTypeAndLicenseClass(
            int PersonID,
            int LicenseClassID,
            int TestTypeID,
            ref int TestID,
            ref int TestAppointmentID,
            ref bool TestResult,
            ref string Notes,
            ref int CreatedByUserID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"
                SELECT * FROM Tests
                INNER JOIN TestAppointments
                ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                INNER JOIN LocalDrivingLicenseApplications
                ON TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                INNER JOIN Applications
                ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                WHERE LocalDrivingLicenseApplications.LicenseClassID = 1 
                AND Applications.ApplicantPersonID = 1
                AND TestAppointments.TestTypeID = 1
                ORDER BY Tests.TestID 
                DESC;
            ";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    TestID = (int)reader["TestID"];
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];
                    if (reader["Notes"] == DBNull.Value)
                        Notes = "";
                    else
                        Notes = (string)reader["Notes"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
                else
                {
                    isFound = false;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
    }
}
