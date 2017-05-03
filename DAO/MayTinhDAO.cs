using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangMayTinh.DAO
{
    public class MayTinhDAO
    {
        private MayTinhDAO() { }

        private static MayTinhDAO instance;

        public static MayTinhDAO Instance
        {
            get { if (instance == null) instance = new MayTinhDAO(); return MayTinhDAO.instance; }
            private set { MayTinhDAO.instance = value; }
        }

        public DataTable GetAll()
        {
            string query = "select * from MayTinh";

            DataTable data = new DataTable();
            data = DataProvider.Instance.executeQuery(query);

            return data;
        }

        public bool Add(string ma, string ten, int idDanhMuc, string anh, int donGiaNhap,int donGiaXuat, int soLuong, string chiTiet)
        {
            string query = string.Format("insert into MayTinh(Ma,IdDanhMuc,Ten,DonGiaNhap,DonGiaXuat,SoLuong,ChiTiet,Anh) values('{0}',{1},'{2}',{3},{4},'{5}',N'{6}',N'{7}')", ma, idDanhMuc, ten, donGiaNhap, donGiaXuat, soLuong, chiTiet, anh);

            try
            {
                int result = DataProvider.Instance.executeNonQuery(query);
                if (result > 0) return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(string ma, string ten, int idDanhMuc, string anh, int donGiaNhap, int donGiaXuat, int soLuong, string chiTiet)
        {
            string query = string.Format("update MayTinh set idDanhMuc = {1}, ten = '{2}', donGiaNhap = {3}, donGiaXuat = {4}, soLuong = '{5}', chiTiet = N'{6}', anh=N'{7}' where ma = '{0}'", ma, idDanhMuc, ten, donGiaNhap, donGiaXuat, soLuong, chiTiet, anh);

            try
            {
                int result = DataProvider.Instance.executeNonQuery(query);
                if (result > 0) return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Del(string ma)
        {
            string query = string.Format("delete MayTinh where ma ='{0}'",ma);

            try
            {
                int result = DataProvider.Instance.executeNonQuery(query);
                if (result > 0) return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable Find(string strSearch)
        {
            string query = string.Format("select * from MayTinh where ma like '%{0}%' or ten like N'%{0}%' ",strSearch);

            return DataProvider.Instance.executeQuery(query);

        }
    }
}
