using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess_Layer
{
    public class clsCountryData
    {
        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"                
	            SELECT Countries.CountryID, Countries.CountryName
                FROM Countries;
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

        public static bool Find(int ID, ref string CountryName)
        {
            bool IsFound = false;
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM Countries WHERE CountryID=@CountryID";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@CountryID", ID);

            try
            {
                conn.Open();
                
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    CountryName = (string)reader["CountryName"];
                } else IsFound = false;
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
        public static bool Find(string CountryName, ref int ID)
        {
            bool IsFound = false;
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM Countries WHERE CountryName=@CountryName";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    ID = (int)reader["CountryId"];
                }
                else IsFound = false;
                reader.Close();
            }
            catch (Exception)
            {
                IsFound = false;
            }
            finally { conn.Close(); }


            return IsFound;
        }
    }
}
