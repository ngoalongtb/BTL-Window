using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangMayTinh.DTO
{
    public class HoaDonNhap
    {
        private int iD;
        private string maNhaCungCap;
        private DateTime ngayNhap;
        private string nguoiNhapHang;
        private int tongTien;

        public HoaDonNhap(DataRow row)
        {
            this.ID = int.Parse(row["ID"].ToString());
            this.MaNhaCungCap = row["MaNhaCungCap"].ToString();
            this.NgayNhap = (DateTime)(row["NgayNhap"]);
            this.NguoiNhapHang = row["NguoiNhapHang"].ToString();
            this.TongTien = int.Parse(row["TongTien"].ToString());
        }
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        public string MaNhaCungCap
        {
            get { return maNhaCungCap; }
            set { maNhaCungCap = value; }
        }
        public DateTime NgayNhap
        {
            get { return ngayNhap; }
            set { ngayNhap = value; }
        }
        public string NguoiNhapHang
        {
            get { return nguoiNhapHang; }
            set { nguoiNhapHang = value; }
        }

        public int TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }
        
    }
}
