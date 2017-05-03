using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangMayTinh.DTO
{
    public class KhachHang
    {
        private string cmtnd;
        private string ten;
        private string diaChi;
        private int tuoi;
        private string soDienThoai;
        private string email;

        public KhachHang(DataRow row)
        {
            this.Cmtnd = row["Cmtnd"].ToString();
            this.Ten = row["Ten"].ToString();
            this.DiaChi = row["DiaChi"].ToString();
            this.Tuoi = int.Parse(row["Tuoi"].ToString());
            this.SoDienThoai = row["SoDienThoai"].ToString();
            this.Email = row["Email"].ToString();
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string SoDienThoai
        {
            get { return soDienThoai; }
            set { soDienThoai = value; }
        }

        public int Tuoi
        {
            get { return tuoi; }
            set { tuoi = value; }
        }

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }

        public string Cmtnd
        {
            get { return cmtnd; }
            set { cmtnd = value; }
        }
    }
}
