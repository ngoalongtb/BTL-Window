using QuanLyCuaHangMayTinh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangMayTinh.DAO
{
    public class HoaDonXuatDAO
    {
        private HoaDonXuatDAO() { }

        private static HoaDonXuatDAO instance;

        public static HoaDonXuatDAO Instance
        {
            get { if (instance == null) instance = new HoaDonXuatDAO(); return HoaDonXuatDAO.instance; }
            private set { HoaDonXuatDAO.instance = value; }
        }
        private static int tong;
        /// <summary>
        /// get set tong của list
        /// </summary>
        public static int Tong
        {
            get { return HoaDonXuatDAO.tong; }
            set { HoaDonXuatDAO.tong = value; }
        }
        public List<HoaDonXuat> GetByTime(DateTime from, DateTime to)
        {
            DataTable data = new DataTable();
            List<HoaDonXuat> list = new List<HoaDonXuat>();
            string query = "uspGetHoaDonXuatByTime @fromDay , @toDay";
            data = DataProvider.Instance.executeQuery(query, new object[] { from, to });
            tong = 0;
            foreach (DataRow item in data.Rows)
            {
                list.Add(new HoaDonXuat(item));
                tong += int.Parse(item["TongTien"].ToString());
            }

            return list;
        }
        public List<HoaDonXuat> GetAll()
        {
            DataTable data = new DataTable();
            List<HoaDonXuat> list = new List<HoaDonXuat>();
            string query = "select Xuat.ID, Ten,NgayXuat,NguoiBanHang,TongTien from Xuat join (select IdXuat, sum(CTXuat.SoLuong*Gia) as 'TongTien' from CTXuat join MayTinh on CTXuat.MaMayTinh = MayTinh.Ma group by IdXuat) as tam on Xuat.ID = tam.IdXuat join KhachHang on Xuat.IdKhachHang = KhachHang.Cmtnd";
            data = DataProvider.Instance.executeQuery(query);
            tong = 0;
            foreach (DataRow item in data.Rows)
            {
                list.Add(new HoaDonXuat(item));
                tong += int.Parse(item["TongTien"].ToString());
            }
            
            return list;
        }
    }
}
