using DVLD_DataAccess_Layer;
using System;
using System.Data;
using System.Net.Http.Headers;
using System.Security.Policy;

namespace Business
{
    public class clsUser
    {
        private enum _enMode {Insert = 0, Update = 1}
        private _enMode _Mode;
        public string Username {  get; set; }
        public string Password { get; set; }
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public bool IsActive { get; set; }

        public clsUser()
        {
            _Mode = _enMode.Insert;
            Username = string.Empty;
            Password = string.Empty;
            UserID = -1;
            PersonID = -1;
            IsActive = true;
        }

        public clsUser(string Username, string Password, int UserID, int PersonID, bool IsActive)
        {
            _Mode = _enMode.Update;
            this.UserID = UserID;
            this.Username = Username;
            this.Password = Password;
            this.PersonID = PersonID;
            this.IsActive = IsActive;
        }

        public static DataTable All()
        {
            return clsUserData.All();
        }

        public static clsUser FindUserByAuthRequirment(string Username, string Password)
        {
            int UserID = -1, PersonID = -1;
            bool IsActive = false;

            if (clsUserData.FindUserByAuthRequirment(Username, Password, ref UserID, ref PersonID, ref IsActive))
                return new clsUser(Username, Password, UserID, PersonID, IsActive);
            return null;
        }

        public static bool IsExist(string Username)
        {
            return clsUserData.IfUserExist(Username);
        }

        private bool _Insert()
        {
            UserID = clsUserData.Insert(PersonID, Username, Password, IsActive);
            return (UserID != -1);
        }

        private bool _Update()
        {
            return clsUserData.Update(UserID, PersonID, Username, Password, IsActive);
        }

        public bool Save()
        {
            bool Result;
            if (_Mode == _enMode.Insert)
            {
                Result  = _Insert();
                if (Result)
                    _Mode = _enMode.Update;
            }
            else
                Result = _Update();

            return Result;
        }

        public static clsUser Find(int UserID)
        { 
            int PersonID  = -1;  string UserName = "", Password = ""; bool IsActive = true;
            if (clsUserData.Find(UserID, ref PersonID, ref UserName, ref Password, ref IsActive))
                return new clsUser(UserName, Password, UserID, PersonID, IsActive);

            return null;
        }

        public static bool Delete(int UserID)
        {
            return clsUserData.Delete(UserID);
        }

        public static bool ChangePassword(int UserID, string Password)
        {
            return clsUserData.ChangePassword(UserID, Password);
        }
    }
}
