using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonWebsite.Validation
{
    class EmailStringAttribute : ValidationAttribute
    {
        string correctValuePunktSe = ".se";
        string correctValuePunktCom = ".com";
       

        public override bool IsValid(object value)
        {
            string tempString =value.ToString();
            string last4 = tempString.Substring(tempString.Length - 4, 4);
            string last3 = tempString.Substring(tempString.Length - 3, 3);
            
            if (last4 == correctValuePunktCom || last3 == correctValuePunktSe)
                return true;
            else
                return false;
        }
    }
}
