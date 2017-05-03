using QuanLyCuaHangMayTinh.DAO;
using QuanLyCuaHangMayTinh.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangMayTinh
{
    public partial class fThongKe : Form
    { 
        public fThongKe()
        {
            InitializeComponent();
            
            LoadDtgv();
            dtgv.DataSource = bds;
            dtpkFrom.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1,0,0,0);
            dtpkTo.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 28, 0, 0, 0);
            cbxType.SelectedIndex = 1;
        }

        private event EventHandler myEvent;
        public event EventHandler MyEvent
        {
            add
            {
                myEvent += value;
            }
            remove
            {
                myEvent -= value;
            }
        }

        private BindingSource bds = new BindingSource();

        public void ChangeHeader()
        {
            if(cbxType.SelectedIndex == 1)
            {
                dtgv.Columns["KhachHang"].HeaderText = "Khách hàng";
                dtgv.Columns["NgayXuat"].HeaderText = "Ngày xuất";
                dtgv.Columns["NguoiBanHang"].HeaderText = "Người bán hàng";
                dtgv.Columns["TongTien"].HeaderText = "Tổng tiền";
            }
            else
            {
                dtgv.Columns["MaNhaCungCap"].HeaderText = "Mã nhà cung cấp";
                dtgv.Columns["NgayNhap"].HeaderText = "Ngày nhập";
                dtgv.Columns["NguoiNhapHang"].HeaderText = "Người nhập hàng";
                dtgv.Columns["TongTien"].HeaderText = "Tổng tiền";
            }
            
        }

        public void LoadDtgv()
        {
            if (cbxType.SelectedIndex == 1)
            {
                bds.DataSource = HoaDonXuatDAO.Instance.GetByTime(dtpkFrom.Value, dtpkTo.Value);
                txtTongTien.Text = HoaDonXuatDAO.Tong.ToString();
            }
            else
            {
                bds.DataSource = HoaDonNhapDAO.Instance.GetByTime(dtpkFrom.Value,dtpkTo.Value);
                txtTongTien.Text = HoaDonNhapDAO.Tong.ToString();
            }
        }

        

        private void cbxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDtgv();
            ChangeHeader();
        }

        private void dtpkFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadDtgv();
        }

        private void dtpkTo_ValueChanged(object sender, EventArgs e)
        {
            LoadDtgv();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            if (cbxType.SelectedIndex == 1)
            {
                bds.DataSource = HoaDonXuatDAO.Instance.GetAll();
                txtTongTien.Text = HoaDonXuatDAO.Tong.ToString();
            }
            else
            {
                bds.DataSource = HoaDonNhapDAO.Instance.GetAll();
                txtTongTien.Text = HoaDonNhapDAO.Tong.ToString();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (cbxType.SelectedIndex == 1)
            {

                bds.DataSource = XuatDAO.Instance.DelByTime(dtpkFrom.Value, dtpkTo.Value);
            }
            else
            {
                bds.DataSource = NhapDAO.Instance.DelByTime(dtpkFrom.Value, dtpkTo.Value);
            }
            LoadDtgv();
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            MyEventArgs mea = new MyEventArgs();
            mea.Type = cbxType.SelectedIndex;
            mea.FromTime = dtpkFrom.Value;
            mea.ToTime = dtpkTo.Value;
            myEvent(this, mea);
        }

    }

    
}
