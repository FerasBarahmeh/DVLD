
using System;
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

        public static bool Find(
            int LicenseClassID,
            ref string ClassName,
            ref string ClassDescription,
            ref short MinimumAllowedAge,
            ref short DefaultValidityLength,
            ref float ClassFees
        )
        {
            bool IsFounded = false;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"
                    SELECT 
	                    LicenseClasses.LicenseClassID,
	                    LicenseClasses.ClassName,
	                    LicenseClasses.ClassDescription,
	                    LicenseClasses.MinimumAllowedAge,
	                    LicenseClasses.DefaultValidityLength,
	                    LicenseClasses.ClassFees
                    FROM 
	                    LicenseClasses 
                    Where LicenseClassID = @LicenseClassID; 
            ";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    IsFounded = true;
                    ClassName = reader["ClassName"].ToString();
                    ClassDescription = reader["ClassDescription"].ToString();
                    if (short.TryParse(reader["MinimumAllowedAge"].ToString(), out short MinimumAllowedAgeShort))
                        MinimumAllowedAge = MinimumAllowedAgeShort;
                    if (short.TryParse(reader["DefaultValidityLength"].ToString
                        (), out short DefaultValidityLengthShort))
                        DefaultValidityLength = DefaultValidityLengthShort;
                    if (float.TryParse(reader["ClassFees"].ToString(), out float ClassFeesFloat))
                        ClassFees = ClassFeesFloat;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Can't find License Class: " + ex.Message);
            }
            finally { conn.Close(); }


            return IsFounded;
        }
        public static bool FindIDByName(
            string ClassName,
            ref int LicenseClassID
          )
        {
            bool IsFounded = false;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"
                    SELECT 
	                    LicenseClasses.LicenseClassID,
                    FROM 
	                    LicenseClasses 
                    Where LicenseClasses.ClassName = @ClassName; 
            ";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    IsFounded = true;
                    LicenseClassID = (int)reader["LicenseClassID"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Can't find license class ID by name: " + ex.Message);
            }
            finally { conn.Close(); }


            return IsFounded;
        }
    }
}
