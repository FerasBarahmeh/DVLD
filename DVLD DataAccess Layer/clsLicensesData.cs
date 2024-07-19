using System;
using System.Data.SqlClient;

namespace DVLD_DataAccess_Layer
{
    public class clsLicensesData
    {
        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"
                SELECT Licenses.LicenseID
                FROM Licenses 
                INNER JOIN Drivers ON Licenses.DriverID = Drivers.DriverID
                WHERE Licenses.LicenseClass = @LicenseClass 
                AND Drivers.PersonID = @PersonID
                And IsActive=1;
            ";

            SqlCommand cmd = new SqlCommand(Query, connection);

            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@LicenseClass", LicenseClassID);

            try
            {
                connection.Open();
                object Result = cmd.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                {
                    LicenseID = insertedID;
                }
            }

            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }


            return LicenseID;
        }
    }
}
