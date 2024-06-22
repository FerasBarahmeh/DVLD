using Business;
using System;
using System.IO;
using System.Windows.Forms;

namespace DVLD.General_Class
{
    public static class clsAuth
    {
        private readonly static string _NameFile = "AuthorizedData.txt";

        public static clsUser User { get; set; }

        public static bool RememperAuthorizedUser(string Username, string Password)
        {
            try
            {
                string CurrentDirectory = Directory.GetCurrentDirectory();

                string PathFile = CurrentDirectory + "\\" + _NameFile;

                using (StreamWriter writed = new StreamWriter(PathFile))
                {
                    writed.WriteLine(Username+";"+Password);
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Remmber me error " + ex.Message);
            }
        }

        public static bool CleanRememperAuthorizedUser()
        {
            return RememperAuthorizedUser("", "");
        }

        public static void SetParameters(out string Username, out string Password)
        {
            try
            {
                string PathFile = Directory.GetCurrentDirectory() + "\\" + _NameFile;
                using (StreamReader reader = new StreamReader(PathFile))
                {
                    string Content = reader.ReadToEnd();
                    string[] Params = Content.Split(';');
                    Username = Params[0];
                    Password = Params[1];
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Can't Fetch Paramenter: " + ex.Message);
            }
        }
    }
}
