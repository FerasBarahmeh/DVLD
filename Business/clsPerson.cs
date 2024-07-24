using DVLD_DataAccess_Layer;
using System;
using System.Data;


namespace Business
{
    public class clsPerson
    {
        public enum enMode { Update = 0, Add = 1 }
        private enMode Mode { get; set; }
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecundName { get; set; }
        public string ThirdName { get; set; }
        public string FullName
        {
            get { return FirstName + ' ' + SecundName + ' ' + LastName + ' ' + LastName; }
        }
        public string NationalNo { get; set; }
        public DateTime DataOfBirth { get; set; }
        public short Gender { get; set; }
        public string GenderName
        {
            get
            {
                switch (Gender)
                {
                    case 0:
                        return "Male";
                    case 1:
                        return "Femail";
                    default:
                        return "None";
                }
            }
        }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public int NationalCountyID { get; set; }

        public clsCountry CountryInformation { get; set; }

        public clsPerson()
        {
            this.Mode = enMode.Add;
            this.PersonID = -1;
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.SecundName = string.Empty;
            this.ThirdName = string.Empty;
            this.NationalNo = string.Empty;
            this.DataOfBirth = DateTime.MinValue;
            this.Gender = short.MinValue;
            this.Address = string.Empty;
            this.Phone = string.Empty;
            this.Email = string.Empty;
            this.ImagePath = string.Empty;
            this.NationalCountyID = -1;
            this.CountryInformation = null;
        }

        public clsPerson(int personID, string firstaName, string lastaName, string sectoundName, string thirdName, string nationalNo, DateTime dataOfBirth, short gender, string address, string phone, string email, string imagePath, int nationalCountyID)
        {
            Mode = enMode.Update;
            this.PersonID = personID;
            this.FirstName = firstaName;
            this.LastName = lastaName;
            this.SecundName = sectoundName;
            this.ThirdName = thirdName;
            this.NationalNo = nationalNo;
            this.DataOfBirth = dataOfBirth;
            this.Gender = gender;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.ImagePath = imagePath;
            this.NationalCountyID = nationalCountyID;
            this.CountryInformation = clsCountry.Find(nationalCountyID);
        }

        public static DataTable GetAllPeople()
        {
            return clsPersonData.All();
        }

        public static clsPerson Find(int PersonID)
        {
            string FirstName = "", LastName = "", SecoundName = "", ThirdName = "", NationalNo = "", Address = "", Phone = "", Email = "", ImagePath = "";
            DateTime DOB = DateTime.MinValue;
            short Gender = 0; int NationalCountyID = -1;

            bool IsFound = clsPersonData.GetPersonInfoByID(
                            PersonID, ref FirstName, ref SecoundName, ref ThirdName,
                            ref LastName, ref NationalNo, ref DOB, ref Gender,
                            ref Address, ref Phone, ref Email, ref NationalCountyID, ref ImagePath);

            return IsFound
                ? new clsPerson(PersonID, FirstName, LastName, SecoundName, ThirdName, NationalNo, DOB, Gender, Address, Phone, Email, ImagePath, NationalCountyID) : null;
        }

        public static clsPerson Find(string NationalNo)
        {
            string FirstName = "", LastName = "", SecoundName = "", ThirdName = "", Address = "", Phone = "", Email = "", ImagePath = "";
            DateTime DOB = DateTime.MinValue;
            short Gender = 0; int NationalCountyID = -1, PersonID = -1;

            bool IsFound = clsPersonData.GetPersonInfoByNationalNo(
                            NationalNo, ref PersonID, ref FirstName, ref SecoundName, ref ThirdName,
                            ref LastName, ref DOB, ref Gender, ref Address, ref Phone, ref Email, ref NationalCountyID, ref ImagePath);

            return IsFound
                ? new clsPerson(PersonID, FirstName, LastName, SecoundName, ThirdName, NationalNo, DOB, Gender, Address, Phone, Email, ImagePath, NationalCountyID) : null;
        }

        public static bool IsPersonExist(string PersonNationalNo)
        {
            return clsPersonData.IsPersonExist(PersonNationalNo);
        }

        private bool _Update()
        {
            return
                clsPersonData.Update(this.PersonID, this.FirstName, this.SecundName, this.ThirdName, this.LastName, this.NationalNo, this.DataOfBirth, this.Gender, this.Address, this.Phone, this.Email, this.NationalCountyID, this.ImagePath);
        }

        private bool _Add()
        {
            PersonID = clsPersonData.Insert(
                this.FirstName, this.SecundName, this.ThirdName,
                this.LastName, this.NationalNo, this.DataOfBirth,
               (short)this.Gender, this.Address, this.Phone, this.Email,
                this.NationalCountyID, this.ImagePath);

            return (PersonID != -1);

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:

                    if (_Add())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    break;
                case enMode.Update:
                    return _Update();
            }
            return false;
        }

        public static bool Delete(int PersonID)
        {
            return clsPersonData.Delete(PersonID);
        }

        public static bool IsUser(int PersonID)
        {
            return clsPersonData.IsUser(PersonID);
        }
        public static bool IsDriver(int PersonID)
        {
            return clsPersonData.IsDriver(PersonID);
        }
        public static int GetDriverIDByPersonID(int PersonID)
        {
            return clsPersonData.GetDriverIDByPersonID(PersonID);
        }
    }
}
