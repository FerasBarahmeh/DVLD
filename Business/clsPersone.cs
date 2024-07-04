using System;
using System.Data;
using DVLD_DataAccess_Layer;


namespace Business
{
    public class clsPersone
    {
        public enum enMode { Update = 0, Add = 1 }
        private enMode Mode { get; set; }
        public int PersonID { get; set; }
        public string FirstaName { get; set; }
        public string LastaName { get; set; }
        public string SectoundName { get; set; }
        public string ThirdName { get; set; }
        public string FullName
        {
            get { return FirstaName + ' ' + SectoundName + ' ' + LastaName + ' ' + LastaName; }
        }
        public string NationalNo { get; set; }
        public DateTime DataOfBirth { get; set; }
        public short Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public int NationalCountyID { get; set; }

        public clsCountry CountryInformation { get; set; }

        public clsPersone()
        {
            this.Mode = enMode.Add;
            this.PersonID = -1;
            this.FirstaName = string.Empty;
            this.LastaName = string.Empty;
            this.SectoundName = string.Empty;
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

        public clsPersone(int personID, string firstaName, string lastaName, string sectoundName, string thirdName, string nationalNo, DateTime dataOfBirth, short gender, string address, string phone, string email, string imagePath, int nationalCountyID)
        {
            Mode = enMode.Update;
            this.PersonID = personID;
            this.FirstaName = firstaName;
            this.LastaName = lastaName;
            this.SectoundName = sectoundName;
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
            return clsPersoneData.All();
        }

        public static clsPersone Find(int PersonID)
        {
            string FirstName = "", LastaName = "", SecoundName = "", ThirdName = "", NationalNo = "", Address = "", Phone = "", Email = "", ImagePath = "";
            DateTime DOB= DateTime.MinValue; 
            short Gender = 0; int NationalCountyID = -1;

            bool IsFound = clsPersoneData.GetPersonInfoByID(
                            PersonID, ref FirstName, ref SecoundName, ref ThirdName,
                            ref LastaName, ref NationalNo, ref DOB, ref Gender, 
                            ref Address, ref Phone, ref Email, ref NationalCountyID, ref ImagePath);

            return IsFound
                ? new clsPersone(PersonID, FirstName, LastaName, SecoundName, ThirdName, NationalNo, DOB, Gender, Address, Phone, Email, ImagePath, NationalCountyID) : null;
        }

        public static clsPersone Find(string NationalNo)
        {
            string FirstName = "", LastaName = "", SecoundName = "", ThirdName = "", Address = "", Phone = "", Email = "", ImagePath = "";
            DateTime DOB = DateTime.MinValue;
            short Gender = 0; int NationalCountyID = -1, PersonID = -1;

            bool IsFound = clsPersoneData.GetPersonInfoByNationalNo(
                            NationalNo, ref PersonID, ref FirstName, ref SecoundName, ref ThirdName,
                            ref LastaName, ref DOB, ref Gender, ref Address, ref Phone, ref Email, ref NationalCountyID, ref ImagePath);

            return IsFound
                ? new clsPersone(PersonID, FirstName, LastaName, SecoundName, ThirdName, NationalNo, DOB, Gender, Address, Phone, Email, ImagePath, NationalCountyID) : null;
        }

        public static bool IsPersonExist(string PersonNationalNo)
        {
            return clsPersoneData.IsPersonExist(PersonNationalNo);
        }

        private bool _Update()
        {
            return
                clsPersoneData.Update(this.PersonID, this.FirstaName, this.SectoundName, this.ThirdName, this.LastaName, this.NationalNo, this.DataOfBirth, this.Gender, this.Address, this.Phone, this.Email, this.NationalCountyID, this.ImagePath);
        }

        private bool _Add()
        {
            PersonID = clsPersoneData.Insert(
                this.FirstaName, this.SectoundName, this.ThirdName, 
                this.LastaName, this.NationalNo, this.DataOfBirth, 
               (short) this.Gender, this.Address, this.Phone, this.Email, 
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
            return clsPersoneData.Delete(PersonID);
        }

        public static bool IsUser(int PersonID)
        {
            return clsPersoneData.IsUser(PersonID);
        }
    }
}
