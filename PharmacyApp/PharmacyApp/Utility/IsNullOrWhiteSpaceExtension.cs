using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Models
{
    public static class IsNullOrWhiteSpaceExtension
    {
        public static bool AllIsNullOrWhiteSpace(this bool isNullorWhiteSpace,string firstName, string secondName,
                                                            string address,string bornDate,string mail, string number )
        {
            if (!String.IsNullOrWhiteSpace(firstName) && !String.IsNullOrWhiteSpace(secondName)
                && !String.IsNullOrWhiteSpace(address) && !String.IsNullOrWhiteSpace(bornDate)
                && !String.IsNullOrWhiteSpace(mail) && !String.IsNullOrWhiteSpace(number)
               )
            {
                return !isNullorWhiteSpace;
            }
            else return isNullorWhiteSpace;
        }
    }
}
