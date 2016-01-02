using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Text.RegularExpressions;
using System.Configuration;

namespace Com.Guiyu.Utils.Tool
{
    public static class KTool
    {


        public static bool isEmail(String email)
        {
            string reg = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            Regex re = new Regex(reg);
            if (re.IsMatch(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static bool isMobileNO(String mobiles)
        {
          

            string reg = @"^((13[0-9])|(15[0-9])|(18[0-9])|(17[1-9]))\d{8}$";
            Regex re = new Regex(reg);
            if (re.IsMatch(mobiles))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
   
    }
}
