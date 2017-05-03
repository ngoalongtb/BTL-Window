using QuanLyCuaHangMayTinh.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangMayTinh.DAO
{
    public class NhaCungCapDAO
    {
        private NhaCungCapDAO(){}
        private static NhaCungCapDAO instance;

        public static NhaCungCapDAO Instance
        {
            get { if (instance == null) instance = new NhaCungCapDAO(); return NhaCungCapDAO.instance; }
            private set { NhaCungCapDAO.instance = value; }
        }

        public DataTable GetAll()
        {
            DataTable data = new DataTable();

            string query = "select * from NhaCungCap";
            data = DataProvider.Instance.executeQuery(query);

            return data;
        }

        public NhaCungCap Check(string ma)
        {
            DataTable data = new DataTable();
            string query = string.Format("select * from NhaCungCap where ma = '{0}'",ma);

            data = DataProvider.Instance.executeQuery(query);
            if(data.Rows.Count == 0) return null;
            
            NhaCungCap ncc = new NhaCungCap(data.Rows[0]);
            return ncc;
        }

        public bool Add(string ma, string ten, string diaChi, string soDienThoai, string email)
        {
            string query = string.Format("insert into NhaCungCap(Ma,Ten,DiaChi,SoDienThoai,Email) values('{0}',N'{1}',N'{2}','{3}','{4}')",ma,ten,diaChi,soDienThoai,email);
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

        public bool Edit(string ma, string ten, string diaChi, string soDienThoai, string email)
        {
            string query = string.Format("update  NhaCungCap set ten =N'{1}', diaChi = N'{2}', soDienThoai = '{3}', email = '{4}' where ma = '{0}'",ma,ten,diaChi,soDienThoai,email);
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
        public bool Del(string ma)
        {
            string query = string.Format("delete  NhaCungCap  where ma = '{0}'", ma);
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

            string query = string.Format("select * from NhaCungCap where ten like N'%{0}%' or diaChi like N'%{0}%' or soDienThoai  like '%{0}%' or email  like '%{0}%' or ma  like '%{0}%'",searchString);
            data = DataProvider.Instance.executeQuery(query);

            return data;
        }

    }
}
