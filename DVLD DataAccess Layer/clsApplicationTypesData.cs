using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess_Layer
{
    public class clsApplicationTypesData
    {
        public static DataTable All()
        {
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"
                SELECT 
	                ApplicationTypes.ApplicationTypeID,
	                ApplicationTypes.ApplicationTypeTitle, 
	                ApplicationTypes.ApplicationFees
                FROM 
	                ApplicationTypes;
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
            catch (Exception ex)
            {
                throw new Exception("Get Application Types Error: " + ex.Message);
            }
            finally { conn.Close(); }

            return dt;
        }
        public static bool Find(int ApplicationTypeID, ref string ApplicationTypeTitle, ref string ApplicatonTypeFees )
        {
            bool IsFound = false;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"
                    SELECT  ApplicationTypeID, ApplicationTypeTitle, ApplicationFees
                    FROM ApplicationTypes 
                    WHERE ApplicationTypeID = @ApplicationTypeID;
            ";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    ApplicationTypeTitle = reader["ApplicationTypeTitle"].ToString();
                    ApplicatonTypeFees = reader["ApplicationFees"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Can't find application type: " + ex.Message);
            }
            finally { conn.Close(); }

            return IsFound;
        }
        public static bool Update(int ApplicationTypeID, string ApplicationTypeTitle, string ApplicationFees)
        {
            int RowAffected = 0;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"
                UPDATE ApplicationTypes
                SET ApplicationTypeTitle = @ApplicationTypeTitle, ApplicationFees = @ApplicationFees
                 WHERE ApplicationTypeID = @ApplicationTypeID
            ";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            cmd.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            cmd.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);

            try
            {
                conn.Open();
                RowAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Can't update Applicaton Type " + ex.Message);
            }
            finally { conn.Close(); }

            return (RowAffected > 0);
        }

        public static bool IsExist(string ApplicationTypeTitle)
        {
            bool IsFound = false;
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"
                    SELECT Found=1 
                    FROM ApplicationTypes 
                    WHERE ApplicationTypeTitle = @ApplicationTypeTitle;
            ";

            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);

            try
            {
                conn.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                IsFound = Reader.HasRows;
                Reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Can't find application type : " + ex.Message);
            }
            finally { conn.Close(); }
            return IsFound;
        }
    }
}
