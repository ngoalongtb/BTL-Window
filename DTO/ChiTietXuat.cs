using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHangMayTinh.DTO
{
    public class ChiTietXuat
    {
        private int iD;
        private int idXuat;
        private string maMayTinh;
        private int soLuong;

        public ChiTietXuat(DataRow row)
        {
            this.ID = int.Parse(row["ID"].ToString());
            this.IdXuat = int.Parse(row["IdXuat"].ToString());
            this.MaMayTinh = row["MaMayTinh"].ToString();
            this.SoLuong = int.Parse(row["SoLuong"].ToString());
        }

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }

        public string MaMayTinh
        {
            get { return maMayTinh; }
            set { maMayTinh = value; }
        }

        public int IdXuat
        {
            get { return idXuat; }
            set { idXuat = value; }
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}
