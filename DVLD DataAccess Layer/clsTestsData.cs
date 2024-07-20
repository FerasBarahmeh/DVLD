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
                WHERE LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
                AND Applications.ApplicantPersonID = @ApplicantPersonID
                AND TestAppointments.TestTypeID = @TestTypeID
                ORDER BY Tests.TestID 
                DESC;
            ";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
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
        public static int Insert(
            int TestAppointmentID,
            bool TestResult,
            string Notes,
            int CreatedByUserID)
        {
            int TestID = -1;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
                Insert Into Tests (TestAppointmentID,TestResult, Notes, CreatedByUserID)
                Values (@TestAppointmentID,@TestResult, @Notes, @CreatedByUserID);            
                UPDATE TestAppointments 
                SET IsLocked=1 where TestAppointmentID = @TestAppointmentID;
                SELECT SCOPE_IDENTITY();
            ";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            cmd.Parameters.AddWithValue("@TestResult", TestResult);

            if (Notes != "" && Notes != null)
                cmd.Parameters.AddWithValue("@Notes", Notes);
            else
                cmd.Parameters.AddWithValue("@Notes", System.DBNull.Value);

            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                conn.Open();

                object Result = cmd.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                    TestID = insertedID;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }

            return TestID;
        }
        public static bool Update(
            int TestID,
            int TestAppointmentID,
            bool TestResult,
            string Notes,
            int CreatedByUserID)
        {

            int RowsAffected = 0;
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
                Update  Tests  
                SET TestAppointmentID = @TestAppointmentID,
                TestResult=@TestResult,
                Notes = @Notes,
                CreatedByUserID=@CreatedByUserID
                WHERE TestID = @TestID
            ";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@TestID", TestID);
            cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            cmd.Parameters.AddWithValue("@TestResult", TestResult);
            cmd.Parameters.AddWithValue("@Notes", Notes);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                conn.Open();
                RowsAffected = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
            return (RowsAffected > 0);
        }

    }
}
