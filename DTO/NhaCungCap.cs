using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangMayTinh.DTO
{
    public class NhaCungCap
    {
        private string ma;
        private string ten;
        private string diaChi;
        private string soDienThoai;
        private string email;

        public NhaCungCap(DataRow row)
        {
            this.Ma = row["Ma"].ToString();
            this.Ten = row["Ten"].ToString();
            this.DiaChi = row["DiaChi"].ToString();
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

        public string Ma
        {
            get { return ma; }
            set { ma = value; }
        }
    }
}
