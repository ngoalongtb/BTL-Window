using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangMayTinh.DAO
{
    public class XuatDAO
    {
        private XuatDAO() { }
        private static XuatDAO instance;

        public static XuatDAO Instance
        {
            get { if (instance == null) instance = new XuatDAO(); return XuatDAO.instance; }
            private set { XuatDAO.instance = value; }
        }

        public int Add(string cmtnd, string username)
        {
            string query = "uspInsertXuat @idKhachHang , @nguoiXuat ";
            try 
	        {
                return DataProvider.Instance.executeNonQuery(query, new object[] { cmtnd, username });
	        }
	        catch (Exception)
	        {
                return 0;
	        }
        }

        public int GetMaxID()
        {
            string query = "select max(ID) as ID from Xuat";
            DataTable data = new DataTable();
            try
            {
                data = DataProvider.Instance.executeQuery(query);
                if (data.Rows.Count == 1)
                    return int.Parse(data.Rows[0]["ID"].ToString());
            }
            catch (Exception)
            {


            }
            return 0;
        }

        public bool DelByTime(DateTime from, DateTime to)
        {
            try
            {
                string query = string.Format("delete Xuat where NgayXuat>= '{0}' and NgayXuat <= '{1}'",from,to);
                int result = DataProvider.Instance.executeNonQuery(query);

                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        public bool Del(int idXuat)
        {
            try
            {
                string query = "delete Xuat where ID = "+idXuat;
                int result = DataProvider.Instance.executeNonQuery(query);

                return result > 0;
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }

        public int GetTotalPriceById(int id)
        {
            try
            {
                string query = "uspGetTotalPriceByIDXuat " + id;
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
