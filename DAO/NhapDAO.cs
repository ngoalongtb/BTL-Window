using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangMayTinh.DAO
{
    public class NhapDAO
    {
        private NhapDAO() { }

        private static NhapDAO instance;

        public static NhapDAO Instance
        {
            get { if (instance == null) instance = new NhapDAO(); return NhapDAO.instance; }
            private set { NhapDAO.instance = value; }
        }

        public int GetMaxId()
        {
            DataTable data = new DataTable();
            string query = "select max(id) as 'ID' from Nhap";
            data = DataProvider.Instance.executeQuery(query);

            return int.Parse(data.Rows[0]["ID"].ToString());
        }

        public int Add(string maNhaCC, string nguoiNhap)
        {
            string query = " uspInsertNhap @maNhaCC , @nguoiNhap ";
            
            try
            {
                DataTable data = DataProvider.Instance.executeQuery(query, new object[] { maNhaCC, nguoiNhap });
                int result = int.Parse((data.Rows[0])["ID"].ToString());
                return result;
            }
            catch (Exception)
            {
                return 0;
            }
            
        }
        public bool DelByTime(DateTime from, DateTime to)
        {
            try
            {
                string query = string.Format("delete Nhap where NgayNhap>= '{0}' and NgayNhap <= '{1}'", from, to);
                int result = DataProvider.Instance.executeNonQuery(query);

                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool Del(int id)
        {
            try
            {
                string query = "delete Nhap where ID=" + id;

                int result = DataProvider.Instance.executeNonQuery(query);

                return result>0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int GetTotalPriceById(int id)
        {
            try
            {
                string query = "uspGetTotalPriceByIDNhap " + id;
                DataTable data = new DataTable();
                data = DataProvider.Instance.executeQuery(query);

                int result = int.Parse(data.Rows[0]["TotalPrice"].ToString());
                return result;
            }
            catch (Exception)
            {
                
            }

            return 0;
        }
    }
}
