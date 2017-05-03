using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangMayTinh.DTO
{
    public class TaiKhoan
    {
        private string userName;
        private string password;
        private string tenHienThi;
        private string loaiTaiKhoan;

        
        

        public TaiKhoan(string userName, string password, string tenHienThi, string loaiTaiKhoan)
        {
            this.UserName = userName;
            this.Password = password;
            this.TenHienThi = tenHienThi;
            this.LoaiTaiKhoan = loaiTaiKhoan;
        }

        public TaiKhoan(DataRow row)
        {
            this.UserName = row["userName"].ToString();
            this.Password = row["password"].ToString();
            this.TenHienThi = row["tenHienThi"].ToString();
            this.LoaiTaiKhoan = row["loaiTaiKhoan"].ToString() == "0"?"admin":"member";
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string TenHienThi
        {
            get { return tenHienThi; }
            set { tenHienThi = value; }
        }

        

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        
        public string LoaiTaiKhoan
        {
            get { return loaiTaiKhoan; }
            set { loaiTaiKhoan = value; }
        }
        
    }
}
