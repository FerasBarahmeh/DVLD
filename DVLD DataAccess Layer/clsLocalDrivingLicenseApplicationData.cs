using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess_Layer
{
    public class clsLocalDrivingLicenseApplicationData
    {
        public static DataTable All()
        {
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"
                    SELECT 
                        *
                    FROM 
                        LocalDrivingLicenseApplications_View
                    ORDER BY 
                        ApplicationDate 
                    Desc;
            ";
            SqlCommand cmd = new SqlCommand(Query, conn);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows) dt.Load(reader);

                reader.Close();
            }
            catch (Exception)
            {
                throw new Exception("Error in render");
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        public static int Insert(
            int ApplicationID,
            int LicenseClassID
        )
        {
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"
                INSERT INTO LocalDrivingLicenseApplications
                           (ApplicationID,
		                   LicenseClassID)
                VALUES
                    (@ApplicationID
                    ,@LicenseClassID);

                SELECT SCOPE_IDENTITY();
            ";

            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            int LocalDrivingLicenseApplication = -1;
            try
            {
                conn.Open();
                object res = cmd.ExecuteScalar();
                if (res != null && int.TryParse(res.ToString(), out int insertedID))
                    LocalDrivingLicenseApplication = insertedID;
            }
            catch (Exception) { throw; }
            finally { conn.Close(); }

            return LocalDrivingLicenseApplication;
        }

        public static bool Find(
            int LocalDrivingLicenseApplicationID,
            ref int ApplicationID,
            ref int LicenseClassID
        )
        {
            bool IsFound = false;
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"
                SELECT 
                    * 
                FROM 
                    LocalDrivingLicenseApplications 
                WHERE 
                    LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID
            ";

            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                }
                else IsFound = false;
                reader.Close();
            }
            catch (Exception)
            {
                IsFound = false;
                throw;
            }
            finally { conn.Close(); }


            return IsFound;
        }

        public static bool IsPassTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool Passed = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
                SELECT 
	                TOP 1 TestResult 
                FROM 
	                LocalDrivingLicenseApplications
                INNER JOIN 
	                TestAppointments
                ON 
	                TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                INNER JOIN 
	                Tests
                ON 
	                Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                WHERE 
	                (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)
                AND
	                (TestAppointments.TestTypeID = @TestTypeID)
                ORDER BY 
	                TestAppointments.TestAppointmentID 
                DESC;
            ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && bool.TryParse(result.ToString(), out bool returnedResult))
                {
                    Passed = returnedResult;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }

            return Passed;

        }
        public static bool HasLicense(int LocalDrivingLicenseApplicationID, int LicenseClassID)
        {
            bool Found = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
                SELECT 
	                Found=1 
                FROM 
	                Applications
                INNER JOIN 
	                LocalDrivingLicenseApplications
                ON 
	                LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                INNER JOIN 
	                Licenses
                ON 
	                Licenses.ApplicationID = Applications.ApplicationID
                WHERE 
	                LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                AND 
	                LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID;
            ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && bool.TryParse(result.ToString(), out bool returnedResult))
                {
                    Found = returnedResult;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }

            return Found;
        }
        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool Result = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @" 
                SELECT TOP 1 Found = 1
                FROM LocalDrivingLicenseApplications
                INNER JOIN TestAppointments
                ON TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                WHERE TestAppointments.LocalDrivingLicenseApplicationID  = @LocalDrivingLicenseApplicationID
                AND TestTypeID = @TestTypeID 
                AND IsLocked = 0
                ORDER BY TestAppointments.TestAppointmentID 
                DESC;
            
            ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                if (result != null) Result = true;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }

            return Result;
        }
        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
                SELECT Found=1
                FROM LocalDrivingLicenseApplications
                INNER JOIN Applications
                ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                INNER JOIN TestAppointments
                ON TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                INNER JOIN Tests
                ON  Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                WHERE TestAppointments.TestTypeID = @TestTypeID  AND LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                ORDER BY TestAppointments.TestAppointmentID DESC;
            ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null) IsFound = true;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return IsFound;
        }

        public static int TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            int TotalTrialsPerTest = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"
                SELECT TotalTrialsPerTest=COUNT(Tests.TestID)
                FROM LocalDrivingLicenseApplications
                INNER JOIN Applications
                ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                INNER JOIN TestAppointments
                ON TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                INNER JOIN Tests
                ON  Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                WHERE TestAppointments.TestTypeID = @TestTypeID  AND LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;
            ";

            SqlCommand cmd = new SqlCommand(Query, connection);

            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    TotalTrialsPerTest = (int)reader["TotalTrialsPerTest"];
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return TotalTrialsPerTest;
        }
    }
}
