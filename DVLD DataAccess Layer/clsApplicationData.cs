using System.Data.SqlClient;
using System;

namespace DVLD_DataAccess_Layer
{
    public class clsApplicationData
    {
        public static int Insert(
            int ApplicantPersonID,
            DateTime ApplicationDate,
            int ApplicationTypeID,
            short ApplicationStatus,
            DateTime LastStatusDate,
            float PaidFees,
            int CreatedByUserID
        )
        {
            int ApplicationID = -1;
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"
              INSERT INTO Applications
                   (ApplicantPersonID
                   ,ApplicationDate
                   ,ApplicationTypeID
                   ,ApplicationStatus
                   ,LastStatusDate
                   ,PaidFees
                   ,CreatedByUserID)
             VALUES
                   (@ApplicantPersonID
                   ,@ApplicationDate
                   ,@ApplicationTypeID
                   ,@ApplicationStatus
                   ,@LastStatusDate
                   ,@PaidFees
                   ,@CreatedByUserID);

                SELECT SCOPE_IDENTITY();
            ";

            SqlCommand cmd = new SqlCommand(Query, conn);

            cmd.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            cmd.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            cmd.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            cmd.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            cmd.Parameters.AddWithValue("@PaidFees", PaidFees);
            cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                conn.Open();
                object res = cmd.ExecuteScalar();
                if (res != null && int.TryParse(res.ToString(), out int insertedID))
                    ApplicationID = insertedID;
            }
            catch (Exception) { throw; }
            finally { conn.Close(); }
            return ApplicationID;
        }

        public static int GetActiveApplicationIDForLicenseClass(
            int ApplicantPersonID,
            int ApplicationTypeID,
            int LicenseClassID
        )
        {
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"
                SELECT 
	                ActiveApplicationID=Applications.ApplicationID  
                FROM 
	                Applications 
                INNER JOIN 
	                LocalDrivingLicenseApplications
                ON 
	                Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                WHERE 
	                ApplicantPersonID = @ApplicantPersonID 
                And 
	                ApplicationTypeID = @ApplicationTypeID 
                And
	                LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
                And 
	                ApplicationStatus=1;
            ";

            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            int ActiveApplicationID = -1;

            try
            {
                conn.Open();
                object result = cmd.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int AppID))
                {
                    ActiveApplicationID = AppID;
                }
            }
            catch (Exception)
            {
                return ActiveApplicationID;
            }
            finally { conn.Close(); }

            return ActiveApplicationID;
        }

        public static bool Find(
            int ApplicationID,
            ref int ApplicantPersonID,
            ref DateTime ApplicationDate,
            ref int ApplicationTypeID,
            ref short ApplicationStatus,
            ref DateTime LastStatusDate,
            ref float PaidFees,
            ref int CreatedByUserID
        )
        {
            bool IsFound = false;
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"
                SELECT 
                    * 
                FROM 
                    Applications 
                WHERE 
                    ApplicationID=@ApplicationID
            ";

            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    
                    ApplicationID = (int)reader["ApplicationID"];
                    ApplicantPersonID = (int)reader["ApplicantPersonID"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationStatus = (short)reader["ApplicationStatus"];
                    if (DBNull.Value == reader["LastStatusDate"])
                    {
                        ApplicationStatus = 0;
                    }
                    object test = reader["LastStatusDate"];
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    PaidFees = reader["PaidFees"] != DBNull.Value && float.TryParse(reader["PaidFees"].ToString(), out float paidFees) ? paidFees : 0.0f;
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
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
