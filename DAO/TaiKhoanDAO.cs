using QuanLyCuaHangMayTinh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangMayTinh.DAO
{
    public class TaiKhoanDAO
    {
        private TaiKhoanDAO() { }

        private static TaiKhoanDAO instance;

        public static TaiKhoanDAO Instance
        {
            get { if (instance == null) instance = new TaiKhoanDAO(); return TaiKhoanDAO.instance; }
            private set { TaiKhoanDAO.instance = value; }
        }

        public List<TaiKhoan> GetAll()
        {
            string query = "select * from TaiKhoan";

            DataTable data = DataProvider.Instance.executeQuery(query);

            List<TaiKhoan> list = new List<TaiKhoan>();
            foreach (DataRow item in data.Rows)
            {
                list.Add(new TaiKhoan(item));
            }
            
            return list;
        }
        public List<TaiKhoan> Find(string strSearch)
        {
            string query = string.Format("select * from TaiKhoan where username like '%{0}%' or TenHienThi like N'%{0}%'", strSearch);

            DataTable data = DataProvider.Instance.executeQuery(query);

            List<TaiKhoan> list = new List<TaiKhoan>();
            foreach (DataRow item in data.Rows)
            {
                list.Add(new TaiKhoan(item));
            }

            return list;
        }

        public TaiKhoan GetByUsername(string username)
        {
            string query = string.Format("select * from TaiKhoan where username = '{0}'",username);

            DataTable data = DataProvider.Instance.executeQuery(query);

            TaiKhoan acc = new TaiKhoan(data.Rows[0]);

            return acc;
        }
        public bool CheckLogin(string username, string password)
        {
            string query = "uspCheckLogin @username , @password ";

            DataTable data = DataProvider.Instance.executeQuery(query, new object[] { username, password});

            if (data.Rows.Count == 1)
                return true;

            return false;
        }



        public bool Add(string userName, string displayName, int type)
        {
            try
            {
                string query = string.Format("insert TaiKhoan(username, password,TenHienThi, LoaiTaiKhoan) values('{0}','12345',N'{1}',{2})",userName,displayName,type);

                int result = DataProvider.Instance.executeNonQuery(query);


                return result > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Edit(string userName, string password, string displayName)
        {
            try
            {
                string query = string.Format("update TaiKhoan set password = '{1}' , tenHienThi = N'{2}' where username = '{0}'",userName,password,displayName);

                int result = DataProvider.Instance.executeNonQuery(query);


                return result > 0;
            }
            catch (Exception)
            {
                
                return false;
            }
        }
        public bool Update(string userName, string displayName, int type)
        {
            try
            {
                string query = string.Format("update TaiKhoan set LoaiTaiKhoan = {1} , tenHienThi = N'{2}' where username = '{0}'", userName, type, displayName);

                int result = DataProvider.Instance.executeNonQuery(query);


                return result > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Del(string userName)
        {
            try
            {
                string query = string.Format("uspDelTaiKhoanByUserName "+userName);

                int result = DataProvider.Instance.executeNonQuery(query);


                return result > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
