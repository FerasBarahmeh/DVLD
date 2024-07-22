using System;
using System.Data.SqlClient;

namespace DVLD_DataAccess_Layer
{
    public class clsLicensesData
    {
        public static bool GetLicenseInfoByID(
            int LicenseID,
            ref int ApplicationID,
            ref int DriverID,
            ref int LicenseClass,
            ref DateTime IssueDate,
            ref DateTime ExpirationDate,
            ref string Notes,
            ref float PaidFees,
            ref bool IsActive,
            ref byte IssueReason,
            ref int CreatedByUserID)
        {
            bool IsFound = false;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Licenses WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClass = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];

                    if (reader["Notes"] == DBNull.Value)
                        Notes = "";
                    else
                        Notes = (string)reader["Notes"];

                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    IsActive = (bool)reader["IsActive"];
                    IssueReason = (byte)reader["IssueReason"];
                    CreatedByUserID = (int)reader["DriverID"];
                }
                else
                {
                    IsFound = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                conn.Close();
            }

            return IsFound;
        }

        public static int Insert(
            int ApplicationID,
            int DriverID,
            int LicenseClass,
            DateTime IssueDate,
            DateTime ExpirationDate,
            string Notes,
            float PaidFees,
            bool IsActive,
            byte IssueReason,
            int CreatedByUserID)
        {
            int LicenseID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
                              INSERT INTO Licenses
                               (ApplicationID,
                                DriverID,
                                LicenseClass,
                                IssueDate,
                                ExpirationDate,
                                Notes,
                                PaidFees,
                                IsActive,IssueReason,
                                CreatedByUserID)
                         VALUES
                               (
                               @ApplicationID,
                               @DriverID,
                               @LicenseClass,
                               @IssueDate,
                               @ExpirationDate,
                               @Notes,
                               @PaidFees,
                               @IsActive,@IssueReason, 
                               @CreatedByUserID);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);

            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

            if (Notes == "")
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Notes", Notes);

            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);

            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();

                object Result = command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                    LicenseID = insertedID;
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
        public static bool Update(
            int LicenseID,
            int ApplicationID,
            int DriverID,
            int LicenseClass,
            DateTime IssueDate,
            DateTime ExpirationDate,
            string Notes,
            float PaidFees,
            bool IsActive,
            byte IssueReason,
            int CreatedByUserID)
        {
            int RowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
                UPDATE Licenses
                SET ApplicationID=@ApplicationID, DriverID = @DriverID,
                              LicenseClass = @LicenseClass,
                              IssueDate = @IssueDate,
                              ExpirationDate = @ExpirationDate,
                              Notes = @Notes,
                              PaidFees = @PaidFees,
                              IsActive = @IsActive,IssueReason=@IssueReason,
                              CreatedByUserID = @CreatedByUserID
                WHERE LicenseID=@LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

            if (Notes == "")
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
                command.Parameters.AddWithValue("@Notes", Notes);

            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (RowsAffected > 0);
        }

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

        public static bool IsPersonHasLicense(int PersonID, int LicenseClassID)
        {
            bool IsFound = false;
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"
                    SELECT HasLicense=1
                    FROM Licenses
                    INNER JOIN Drivers
                    ON Licenses.DriverID = Drivers.DriverID
                    WHERE Drivers.PersonID = @PersonID 
                    AND Licenses.LicenseClass=@LicenseClassID;
            ";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                conn.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                IsFound = Reader.HasRows;
                Reader.Close();
            }
            catch (Exception ex)
            {
            }
            finally { conn.Close(); }

            return IsFound;
        }
    }
}
