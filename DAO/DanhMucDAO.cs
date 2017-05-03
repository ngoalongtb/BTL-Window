using QuanLyCuaHangMayTinh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangMayTinh.DAO
{
    public class DanhMucDAO
    {
        private DanhMucDAO() { }
        private static DanhMucDAO instance;

        public static DanhMucDAO Instance
        {
            get { if (instance == null) instance = new DanhMucDAO(); return DanhMucDAO.instance; }
            private set { DanhMucDAO.instance = value; }
        }

        public List<DanhMuc> GetAll()
        {
            DataTable data = new DataTable();

            string query = "select * from DanhMuc";
            data = DataProvider.Instance.executeQuery(query);

            List<DanhMuc> list = new List<DanhMuc>();
            foreach (DataRow row in data.Rows)
            {
                list.Add(new DanhMuc(row));
            }

            return list;
        }
        //đang làm đến đây
        public bool Add(string tenDanhMuc)
        {
            string query = string.Format("insert into DanhMuc(TenDanhMuc) values(N'{0}')",tenDanhMuc);
            try
            {
                int result = DataProvider.Instance.executeNonQuery(query);
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Edit(int id, string ten)
        {
            
            string query = string.Format("update  DanhMuc set tenDanhMuc =N'{1}' where id = {0}", id, ten);
            try
            {
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

            string query = string.Format("delete  DanhMuc  where id = '{0}'", id);
            try
            {
                int result = DataProvider.Instance.executeNonQuery(query);
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }

        }


        public DataTable Find(string searchString)
        {
            DataTable data = new DataTable();

            string query = string.Format("select * from DanhMuc where tenDanhMuc like N'%{0}%' or id = {0}", searchString);
            data = DataProvider.Instance.executeQuery(query);

            return data;
        }
    }
}
