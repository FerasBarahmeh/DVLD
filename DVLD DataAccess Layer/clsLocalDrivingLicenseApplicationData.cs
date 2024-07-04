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
    }
}
