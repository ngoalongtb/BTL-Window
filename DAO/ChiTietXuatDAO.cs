using QuanLyCuaHangMayTinh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangMayTinh.DAO
{
    public class ChiTietXuatDAO
    {
        private ChiTietXuatDAO(){}
        private static ChiTietXuatDAO instance;

        public static ChiTietXuatDAO Instance
        {
            get { if (instance == null) instance = new ChiTietXuatDAO(); return ChiTietXuatDAO.instance; }
            private set { ChiTietXuatDAO.instance = value; }
        }

        public List<ChiTietXuat> GetByIdXuat(int idXuat)
        {
            DataTable data = new DataTable();
            string query = "select * from CTXuat where IdXuat = " + idXuat;

            data = DataProvider.Instance.executeQuery(query);
            List<ChiTietXuat> list = new List<ChiTietXuat>();

            foreach (DataRow item in data.Rows)
            {
                list.Add(new ChiTietXuat(item));
            }

            return list;
        }

        public bool Add(int idXuat, string maMayTinh, int soLuong)
        {
            try
            {
                int result = DataProvider.Instance.executeNonQuery("uspAddChiTietXuat @idXuat , @maMayTinh , @soLuong ", new object[] { idXuat, maMayTinh, soLuong });

                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Del(int idChiTietXuat)
        {
            try
            {
                int result = DataProvider.Instance.executeNonQuery("uspDelChiTietXuat @id ", new object[] { idChiTietXuat });

                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
