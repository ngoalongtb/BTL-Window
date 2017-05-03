using QuanLyCuaHangMayTinh.Code;
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
    public partial class fMayTinh : Form
    {
        public fMayTinh()
        {
            InitializeComponent();
        }

        private BindingSource bds = new BindingSource();

        private void fMayTinh_Load(object sender, EventArgs e)
        {
            LoadDtgv();
            LoadCbxDanhMuc();
            dtgv.DataSource = bds;
            dtgv.Columns["idDanhMuc"].Visible = false;
            dtgv.Columns["Anh"].Visible = false;
            ChangHeader();
            AddDataBinding();
            
        }

        public void ChangHeader()
        {
            dtgv.Columns["Ma"].HeaderText = "Mã";
            dtgv.Columns["Ten"].HeaderText = "Tên";
            dtgv.Columns["ChiTiet"].HeaderText = "Chi tiết";
            dtgv.Columns["DonGiaNhap"].HeaderText = "Đơn giá nhập";
            dtgv.Columns["DonGiaXuat"].HeaderText = "Đơn giá xuất";
            dtgv.Columns["SoLuong"].HeaderText = "Số lượng";

        }

        public void LoadDtgv()
        {
            bds.DataSource = MayTinhDAO.Instance.GetAll();
            
        }

        public void LoadCbxDanhMuc()
        {
            cbxDanhMuc.DataSource = DanhMucDAO.Instance.GetAll();
            cbxDanhMuc.DisplayMember = "TenDanhMuc";
        }

        public void AddDataBinding()
        {
            txtMa.DataBindings.Add("Text", dtgv.DataSource, "Ma",true,DataSourceUpdateMode.OnPropertyChanged);
            txtTen.DataBindings.Add("Text", dtgv.DataSource, "Ten", true, DataSourceUpdateMode.OnPropertyChanged);
            txtChiTiet.DataBindings.Add("Text", dtgv.DataSource, "ChiTiet", true, DataSourceUpdateMode.OnPropertyChanged);
            nbudDonGiaNhap.DataBindings.Add("Value", dtgv.DataSource, "DonGiaNhap", true, DataSourceUpdateMode.OnPropertyChanged);
            nbudDonGiaXuat.DataBindings.Add("Value", dtgv.DataSource, "DonGiaXuat", true, DataSourceUpdateMode.OnPropertyChanged);
            nbudSoLuong.DataBindings.Add("Text", dtgv.DataSource, "SoLuong", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(!MyRegular.CheckRequired(txtMa.Text,"Bắt buộc nhập vào mã"))
                return;
            if(!MyRegular.CheckRequired(txtTen.Text,"Bắt buộc nhập vào tên"))
                return;
            if(!MyRegular.CheckRequired(txtChiTiet.Text,"Bắt buộc nhập vào chi tiết hàng hóa"))
                return;



            if (MayTinhDAO.Instance.Add(txtMa.Text, txtTen.Text, ((DanhMuc)cbxDanhMuc.SelectedItem).ID, "", (int)nbudDonGiaNhap.Value, (int)nbudDonGiaXuat.Value, (int)nbudSoLuong.Value, txtChiTiet.Text))
            {
                MessageBox.Show("Thêm mới thành công");
            }
            else{
                MessageBox.Show("Thất bại. Vui lòng kiểm tra lại !!!");
            }
            LoadDtgv();
        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int idDanhMuc = int.Parse(dtgv.SelectedRows[0].Cells["idDanhMuc"].Value.ToString());
                for (int i = 0; i < cbxDanhMuc.Items.Count; i++)
                {
                    if (idDanhMuc == ((DanhMuc)cbxDanhMuc.Items[i]).ID)
                    {
                        cbxDanhMuc.SelectedIndex = i;
                        return;
                    }
                }
            }
            catch (Exception)
            {
                cbxDanhMuc.SelectedIndex = 0;
            }
            
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!MyRegular.CheckRequired(txtMa.Text, "Bắt buộc nhập vào mã"))
                return;
            if (!MyRegular.CheckRequired(txtTen.Text, "Bắt buộc nhập vào tên"))
                return;
            if (!MyRegular.CheckRequired(txtChiTiet.Text, "Bắt buộc nhập vào chi tiết hàng hóa"))
                return;

            if (MayTinhDAO.Instance.Edit(txtMa.Text, txtTen.Text, ((DanhMuc)cbxDanhMuc.SelectedItem).ID, "", (int)nbudDonGiaNhap.Value, (int)nbudDonGiaXuat.Value, (int)nbudSoLuong.Value, txtChiTiet.Text))
            {
                MessageBox.Show("Cập nhật thành công");
            }
            else{
                MessageBox.Show("Thất bại. Vui lòng kiểm tra lại !!!");
            }
            LoadDtgv();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadDtgv();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!MyRegular.CheckRequired(txtMa.Text, "Bắt buộc nhập vào mã"))
                return;
            if (MayTinhDAO.Instance.Del(txtMa.Text))
            {
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Vui lòng xử lý hóa đơn trước");
            }
            LoadDtgv();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (!MyRegular.CheckRequired(txtMa.Text, "Bạn cần nhập vào từ khóa để tìm kiếm"))
                return;
            bds.DataSource = MayTinhDAO.Instance.Find(txtTimKiem.Text);
        }
    }
}
