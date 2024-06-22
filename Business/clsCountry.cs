using DVLD_DataAccess_Layer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class clsCountry
    {
        public int CountryID = -1;
        public string CountryName = "";

        public clsCountry(int CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }
        public clsCountry() 
        {
           
        }
        public static DataTable GetAllCountries()
        {
            return clsCountryData.GetAllCountries();
        }

        public static clsCountry Find(int CountryID)
        {
            string CountryName = "";
            if (clsCountryData.Find(CountryID, ref CountryName))
            {
                return new clsCountry(CountryID, CountryName);
            }
            return null;
        }

        public static clsCountry Find(string NameCountry) 
        {
            int CountryID = -1;
            if (clsCountryData.Find(NameCountry, ref CountryID))
            {
                return new clsCountry(CountryID, NameCountry);
            }
            return null;
        }
    }
}
