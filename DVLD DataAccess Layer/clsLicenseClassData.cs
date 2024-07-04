
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess_Layer
{
    public class clsLicenseClassData
    {
        public static DataTable All()
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"                
	            SELECT *  FROM LicenseClasses ORDER BY ClassName;
            ";

            SqlCommand cmd = new SqlCommand(Query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            finally { conn.Close(); }
            return dt;
        }
    }
}
