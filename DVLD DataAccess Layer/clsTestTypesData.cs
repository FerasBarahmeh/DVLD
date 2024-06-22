
using System.Data.SqlClient;
using System.Data;
using System;

namespace DVLD_DataAccess_Layer
{
    public class clsTestTypesData
    {
        public static DataTable All()
        {
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"
                SELECT 
	                TestTypes.TestTypeID,
	                TestTypes.TestTypeTitle, 
	                TestTypes.TestTypeFees,
	                TestTypes.TestTypeDescription
                FROM 
	                TestTypes;
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
        public static bool Find(int TestTypeID, ref string TestTypeTitle, ref string TestTypeDescription, ref string TestTypeFees)
        {
            bool IsFound = false;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"
                    SELECT  TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees
                    FROM TestTypes 
                    WHERE TestTypeID = @TestTypeID;
            ";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    TestTypeTitle = reader["TestTypeTitle"].ToString();
                    TestTypeDescription = reader["TestTypeDescription"].ToString();
                    TestTypeFees = reader["TestTypeFees"].ToString();
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
        public static bool Update(int TestTypeID, string TestTypeTitle, string TestTypeDescription,  string TestTypeFees)
        {
            int RowAffected = 0;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"
                UPDATE TestTypes
                SET TestTypeTitle = @TestTypeTitle, TestTypeDescription= @TestTypeDescription, TestTypeFees = @TestTypeFees
                 WHERE TestTypeID = @TestTypeID
            ";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            cmd.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            cmd.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            cmd.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);

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

        public static bool IsExist(string TestTypeTitle)
        {
            bool IsFound = false;
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"
                    SELECT Found=1 
                    FROM TestTypes 
                    WHERE TestTypeTitle = @TestTypeTitle;
            ";

            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);

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
