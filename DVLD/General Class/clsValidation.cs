using System;
using System.Text.RegularExpressions;

namespace DVLD.General_Class
{
    public class clsValidation
    {
        public static bool IsValidEmail(string Email) 
        {
            var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
            return (new Regex(pattern)).IsMatch(Email);
        }
        public static bool Integer(string Number)
        {
            var pattern = @"^[0-9]*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool Float(string Number)
        {
            var pattern = @"^[0-9]*(?:\.[0-9]*)?$";

            var regex = new Regex(pattern);

            return regex.IsMatch(Number);
        }

        public static bool IsNumber(string Number)
        {
            return (Integer(Number) || Float(Number));
        }
    }
}
