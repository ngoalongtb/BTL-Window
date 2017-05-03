using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangMayTinh.DTO
{
    public class HoaDonXuat
    {
        private int iD;
        private string khachHang;
        private DateTime ngayXuat;
        private string nguoiBanHang;
        private int tongTien;

        public HoaDonXuat(DataRow row)
        {
            this.ID = int.Parse(row["ID"].ToString());
            this.KhachHang = row["Ten"].ToString();
            this.NgayXuat = (DateTime)(row["NgayXuat"]);
            this.NguoiBanHang = row["NguoiBanHang"].ToString();
            this.TongTien = int.Parse(row["TongTien"].ToString());
        }
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        public string KhachHang
        {
            get { return khachHang; }
            set { khachHang = value; }
        }
        public DateTime NgayXuat
        {
            get { return ngayXuat; }
            set { ngayXuat = value; }
        }
        public string NguoiBanHang
        {
            get { return nguoiBanHang; }
            set { nguoiBanHang = value; }
        }

        public int TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }
    }
}
