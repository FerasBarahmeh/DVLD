using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccess_Layer
{
    public static class clsUserData
    {
        public static DataTable All()
        {
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"
                SELECT 
	                FullName = People.FirstName + ' ' + ISNULL(People.SecondName, '') + ' ' + ISNULL(People.ThirdName, '') + ' ' + People.LastName,
	                Users.Username,
	                Users.PersonID, 
	                Users.UserID, 
	                Users.IsActive 
                FROM 
	                Users
                INNER JOIN People
                ON Users.PersonID = People.PersonID;
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
                throw new Exception("Get All Users Error: " + ex.Message);
            } finally { conn.Close(); }

            return dt;
        }
        public static bool FindUserByAuthRequirment (string Username, string Password, ref int UserID, ref int PersonID, ref bool IsActive )
        {
            bool IsFound = false;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@Username", Username);
            cmd.Parameters.AddWithValue("@Password", Password);

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if ( reader.Read() )
                {
                    IsFound = true;
                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    IsActive = (bool)reader["IsActive"];
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw new Exception("Database Error Can't Check if User Exists: " + ex.Message);
            }
            finally { conn.Close(); }

            return IsFound;
        }

        public static bool IfUserExist(string Username)
        {
            bool IsFound = false;
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT Found=1 FROM Users WHERE Username = @Username;";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@Username", Username );

            try
            {
                conn.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                IsFound = Reader.HasRows;
                Reader.Close();
            }
            catch (Exception ex)
            { 
                throw new Exception("User Data error can't find if user exit : " + ex.Message);
            }
            finally { conn.Close(); }
            return IsFound;
        }

        public static int Insert(int PersonID, string UserName, string Password, bool IsActive)
        {
            int UserID = -1;
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"
                INSERT INTO Users
                    (PersonID
                    ,UserName
                    ,Password
                    ,IsActive)
                 VALUES
                    (@PersonID
                    ,@UserName
                    ,@Password
                    ,@IsActive);

                SELECT SCOPE_IDENTITY();
            ";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                conn.Open();
                object Result = cmd.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int InsertedUserID))
                    UserID = InsertedUserID;
            }
            catch (Exception ex)
            {
                throw new Exception("Can't insert user : " + ex.Message);
            }
            finally { conn.Close(); }

            return UserID;
        }

        public static bool Update(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            int RowAffected = 0;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"
                UPDATE Users
                SET PersonID = @PersonID
                    ,UserName = @UserName
                    ,Password = @Password
                    ,IsActive = @IsActive
                 WHERE UserID = @UserID
            ";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                conn.Open();
                RowAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Can't update user : " + ex.Message);
            }
            finally { conn.Close(); }

            return (RowAffected > 0);
        }

        public static bool Find(int UserID, ref int PersonID, ref string UserName, ref string Password, ref bool IsActive)
        {
            bool IsFound = false;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM Users WHERE UserID = @UserID;";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    PersonID = (int)reader["PersonID"];
                    IsActive = (bool)reader["IsActive"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Database Error Can't find user by UserID: " + ex.Message);
            }
            finally { conn.Close(); }

            return IsFound;
        }

        public static bool Delete(int UserID)
        {
            int RowAffected = 0;
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"DELETE FROM Users WHERE UserID = @UserID;";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                conn.Open();
                RowAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                //throw new Exception("Can't delte user " + ex.Message);
            }
            finally { conn.Close(); }

            return RowAffected > 0;
        }

        public static bool ChangePassword(int UserID, string Password)
        {
            int RowAffected = 0;

            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"
                UPDATE Users
                SET 
                    Password = @Password
                 WHERE UserID = @UserID
            ";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@Password", Password);

            try
            {
                conn.Open();
                RowAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Change password: " + ex.Message);
            }
            finally { conn.Close(); }

            return (RowAffected > 0);
        }
    }
}
