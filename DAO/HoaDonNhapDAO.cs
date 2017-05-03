using QuanLyCuaHangMayTinh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuanLyCuaHangMayTinh.DAO
{
    public class HoaDonNhapDAO
    {
        private HoaDonNhapDAO() { }
        private static HoaDonNhapDAO instance;
        
        public static HoaDonNhapDAO Instance
        {
            get { if (instance == null) instance = new HoaDonNhapDAO(); return HoaDonNhapDAO.instance; }
            private set { HoaDonNhapDAO.instance = value; }
        }
        private static int tong;
        /// <summary>
        /// Get Tong Danh Sach
        /// </summary>
        public static int Tong
        {
            get { return HoaDonNhapDAO.tong; }
            set { HoaDonNhapDAO.tong = value; }
        }
        public List<HoaDonNhap> GetByTime(DateTime from, DateTime to)
        {
            DataTable data = new DataTable();
            List<HoaDonNhap> list = new List<HoaDonNhap>();
            string query = "uspGetHoaDonNhapByTime @fromDay , @toDay";
            data = DataProvider.Instance.executeQuery(query,new object[]{from,to});
            tong = 0;
            foreach (DataRow item in data.Rows)
            {
                list.Add(new HoaDonNhap(item));
                tong += int.Parse(item["TongTien"].ToString());
            }

            return list;
        }
        public List<HoaDonNhap> GetAll()
        {
            
            DataTable data = new DataTable();
            List<HoaDonNhap> list = new List<HoaDonNhap>();
            string query = "select Nhap.ID, MaNhaCungCap,NgayNhap,NguoiNhapHang,TongTien from Nhap join(select IdNhap, sum(CTNhap.SoLuong*Gia) as 'TongTien' from CTNhap join MayTinh on CTNhap.MaMayTinh = MayTinh.Ma group by IdNhap) as tam on Nhap.ID = tam.IdNhap";
            data = DataProvider.Instance.executeQuery(query);
            tong = 0;
            foreach (DataRow item in data.Rows)
            {
                list.Add(new HoaDonNhap(item));
                tong += int.Parse(item["TongTien"].ToString());
            }

            return list;
        }
    }
}
