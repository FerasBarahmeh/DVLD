using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess_Layer
{
    public class clsPersonData
    {
        public static DataTable All()
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"
                    SELECT People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName, People.DateOfBirth, People.Gendor, CASE WHEN People.Gendor = 0 THEN 'Male' ELSE 'Female' END AS GenderName, People.Address, People.Phone, People.Email, People.NationalityCountryID, People.ImagePath, Countries.CountryName
                    FROM People INNER JOIN Countries
                    ON People.NationalityCountryID = Countries.CountryID
                    ORDER BY People.FirstName;
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

        public static bool GetPersonInfoByID(int PersonID, ref string FirstName, ref string SecondName,
          ref string ThirdName, ref string LastName, ref string NationalNo, ref DateTime DateOfBirth,
           ref short Gendor, ref string Address, ref string Phone, ref string Email,
           ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFound = false;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM People WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = reader["ThirdName"] as string ?? "";
                    LastName = (string)reader["LastName"];
                    NationalNo = (string)reader["NationalNo"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    Email = reader["Email"] as string ?? "";
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    ImagePath = reader["ImagePath"] as string ?? "";
                }
                reader.Close();
            }
            catch (Exception)
            {
                IsFound = false;
            }
            finally
            {
                conn.Close();
            }

            return IsFound;
        }

        public static bool GetPersonInfoByNationalNo(string NationalNo, ref int PersonID, ref string FirstName, ref string SecondName,
          ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
           ref short Gendor, ref string Address, ref string Phone, ref string Email,
           ref int NationalityCountryID, ref string ImagePath)
        {
            bool IsFound = false;



            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM People WHERE NationalNo = @NationalNo;";
            SqlCommand command = new SqlCommand(Query, conn);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = reader["ThirdName"] as string ?? "";
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gendor = (byte)reader["Gendor"];
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    Email = reader["Email"] as string ?? "";
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    ImagePath = reader["ImagePath"] as string ?? "";
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
                throw new Exception("Error in Data tier can't get data by National No.: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return IsFound;
        }

        public static int Insert(string FirstName, string SecondName,
           string ThirdName, string LastName, string NationalNo, DateTime DateOfBirth,
           short Gendor, string Address, string Phone, string Email,
            int NationalityCountryID, string ImagePath)
        {
            int PersonID = -1;
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"
                INSERT INTO People
                           (NationalNo
                           ,FirstName
                           ,SecondName
                           ,ThirdName
                           ,LastName
                           ,DateOfBirth
                           ,Gendor
                           ,Address
                           ,Phone
                           ,Email
                           ,NationalityCountryID
                           ,ImagePath)
                     VALUES
                            (@NationalNo
                           ,@FirstName
                           ,@SecondName
                           ,@ThirdName
                           ,@LastName
                           ,@DateOfBirth
                           ,@Gendor
                           ,@Address
                           ,@Phone
                           ,@Email
                           ,@NationalityCountryID
                           ,@ImagePath);
                SELECT SCOPE_IDENTITY();
            ";

            SqlCommand cmd = new SqlCommand(Query, conn);

            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@SecondName", SecondName);
            cmd.Parameters.AddWithValue("@ThirdName", !string.IsNullOrEmpty(ThirdName) ? (object)ThirdName : System.DBNull.Value);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@NationalNo", NationalNo);
            cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            cmd.Parameters.AddWithValue("@Gendor", Gendor);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            cmd.Parameters.AddWithValue("@Email", !string.IsNullOrEmpty(Email) ? (object)Email : DBNull.Value);
            cmd.Parameters.AddWithValue("@ImagePath", !string.IsNullOrEmpty(ImagePath) ? (object)ImagePath : System.DBNull.Value);

            try
            {
                conn.Open();
                object res = cmd.ExecuteScalar();
                if (res != null && int.TryParse(res.ToString(), out int insertedID))
                    PersonID = insertedID;
            }
            catch (Exception) { throw; }
            finally { conn.Close(); }
            return PersonID;
        }

        public static bool Update(int PersonID, string FirstName, string SecondName,
           string ThirdName, string LastName, string NationalNo, DateTime DateOfBirth,
           short Gendor, string Address, string Phone, string Email,
            int NationalityCountryID, string ImagePath)
        {
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"
               UPDATE People
               SET NationalNo = @NationalNo
                  ,FirstName = @FirstName
                  ,SecondName = @SecondName
                  ,ThirdName = @ThirdName
                  ,LastName = @LastName
                  ,DateOfBirth = @DateOfBirth
                  ,Gendor = @Gendor
                  ,Address = @Address
                  ,Phone = @Phone
                  ,Email = @Email
                  ,NationalityCountryID = @NationalityCountryID
                  ,ImagePath = @ImagePath
               WHERE PersonID = @PersonID;
            ";

            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@NationalNo", NationalNo);
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@SecondName", SecondName);
            cmd.Parameters.AddWithValue("@ThirdName", ThirdName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            cmd.Parameters.AddWithValue("@Gendor", Gendor);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            cmd.Parameters.AddWithValue("@ImagePath", ImagePath);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            int affected = 0;

            try
            {
                conn.Open();
                affected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Database error: " + ex.Message, ex);
            }
            finally { conn.Close(); }

            return (affected == 1);
        }
        public static bool IsPersonExist(string PersonNationalNo)
        {
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"
                SELECT Found=1 FROM People WHERE NationalNo = @NationalNo;
            ";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@NationalNo", PersonNationalNo);

            bool IsFound = false;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                IsFound = reader.HasRows;
                reader.Close();

            }
            catch (Exception)
            {
                IsFound = false;
            }
            finally { conn.Close(); }

            return IsFound;
        }

        public static bool Delete(int PersonID)
        {
            int RowAffected = 0;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"DELETE FROM People WHERE PersonID = @PersonID;";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                conn.Open();
                RowAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Database Delete Person Error " + ex.Message, ex);
            }
            finally { conn.Close(); }

            return RowAffected > 0;
        }

        public static bool IsUser(int PersonID)
        {
            bool IsFound = false;
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"
                SELECT Found=1 
                FROM People 
                INNER JOIN Users 
                On Users.PersonID = People.PersonID 
                WHERE People.PersonID = @PersonID;
            ";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                conn.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                IsFound = Reader.HasRows;
                Reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Can't know if person is user : " + ex.Message);
            }
            finally { conn.Close(); }

            return IsFound;
        }
        public static bool IsDriver(int PersonID)
        {
            bool IsFound = false;
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"
                SELECT Found=1
                FROM Drivers
                WHERE PersonID = @PersonID;
            ";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                conn.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                IsFound = Reader.HasRows;
                Reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Can't know if person is user : " + ex.Message);
            }
            finally { conn.Close(); }

            return IsFound;
        }
        public static int GetDriverIDByPersonID(int PersonID)
        {
            int DriverID = -1;
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"
                SELECT Drivers.DriverID
                FROM Drivers
                WHERE PersonID = @PersonID;
            ";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                conn.Open();
                SqlDataReader Reader = cmd.ExecuteReader();

                if (Reader.Read())
                    DriverID = (int)Reader["DriverID"];
                Reader.Close();
            }
            catch (Exception ex)
            {
            }
            finally { conn.Close(); }

            return DriverID;
        }
    }
}
