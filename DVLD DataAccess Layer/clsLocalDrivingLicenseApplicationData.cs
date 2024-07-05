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
            catch (Exception )
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
    }
}
