using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh.Code
{
  
    public static class MyRegular
    {
        public static bool CheckRequired(string str, string messageError, string messageAccept = "" )
        {
            

            if(str.Trim()== "")
            {
                MessageBox.Show(messageError);
                return false;
            }
            else
                if(messageAccept != "")
                MessageBox.Show(messageAccept);
            return true;
        }

        public static bool CheckEmail(string str)
        {
            string pattern = @"^[0-9,a-z,A-Z]{1,}@[0-9,a-z,A-Z]{1,}.[0-9,a-z,A-Z]{1,}$";

            Regex r = new Regex(pattern);

            if(!r.IsMatch(str))
            {
                MessageBox.Show("Email không hợp lệ..");
                return false;
            }

            return true;
        }

        public static bool CheckPhoneNumber(string str)
        {
            string pattern = @"^0[0-9]{9,10}$";

            Regex r = new Regex(pattern);

            if (!r.IsMatch(str))
            {
                MessageBox.Show("Số điện thoại không hợp lệ..");
                return false;
            }

            return true;
        }
        public static bool CheckCMTND(string str)
        {
            string pattern = @"^[0-9]{9}$";
            string pattern2 = @"^[0-9]{12}$";

            Regex r = new Regex(pattern);
            Regex r2 = new Regex(pattern2);

            if (!r.IsMatch(str) && !r2.IsMatch(str))
            {
                MessageBox.Show("Số chứng minh thư không hợp lệ.(9 số, 12 số).");
                return false;
            }

            return true;
        }
        public static bool CheckMaNCC(string str)
        {
            string pattern = @"^[A-Za-z]{3}[0-9]{1,5}$";

            Regex r = new Regex(pattern);

            if (!r.IsMatch(str))
            {
                MessageBox.Show("Mã nhà cung cấp băt đầu bằng 3 chữ cái, theo sau từ 1 đến 5 số");
                return false;
            }

            return true;
        }
        

    }
}
