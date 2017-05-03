using QuanLyCuaHangMayTinh.Code;
using QuanLyCuaHangMayTinh.DAO;
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
    public partial class fKhachHang : Form
    {
        public fKhachHang()
        {
            InitializeComponent();
        }

        private void fKhachHang_Load(object sender, EventArgs e)
        {
            dtgv.DataSource = bds;
            LoadDtgv();
            ChangHeader();
            AddDataBinding();
        }
        private BindingSource bds = new BindingSource();

        public void LoadDtgv()
        {
            bds.DataSource = KhachHangDAO.Instance.GetAll();
        }
        public void ChangHeader()
        {
            dtgv.Columns["Cmtnd"].HeaderText = "CMTND";
            dtgv.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dtgv.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
            dtgv.Columns["Ten"].HeaderText = "Tên";
            dtgv.Columns["Tuoi"].HeaderText = "Tuổi";
        }
        public void AddDataBinding()
        {
            txtCmtnd.DataBindings.Add("Text", dtgv.DataSource, "Cmtnd", true, DataSourceUpdateMode.OnPropertyChanged);
            txtDiaChi.DataBindings.Add("Text", dtgv.DataSource, "DiaChi", true, DataSourceUpdateMode.OnPropertyChanged);
            txtEmail.DataBindings.Add("Text", dtgv.DataSource, "Email", true, DataSourceUpdateMode.OnPropertyChanged);
            txtSdt.DataBindings.Add("Text", dtgv.DataSource, "SoDienThoai", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTen.DataBindings.Add("Text", dtgv.DataSource, "Ten", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTuoi.DataBindings.Add("Value", dtgv.DataSource, "Tuoi", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!MyRegular.CheckRequired(txtCmtnd.Text, "Bắt buộc nhập vào Cmtnd"))
                return;
            if (!MyRegular.CheckRequired(txtDiaChi.Text, "Bắt buộc nhập vào địa chỉ"))
                return;
            if (!MyRegular.CheckRequired(txtTen.Text, "Bắt buộc nhập vào tên"))
                return;

            if (!MyRegular.CheckEmail(txtEmail.Text))
                return;
            if (!MyRegular.CheckPhoneNumber(txtSdt.Text))
                return;
            if (!MyRegular.CheckCMTND(txtCmtnd.Text))
                return;
            

            if (KhachHangDAO.Instance.Add(txtCmtnd.Text, txtTen.Text,(int)txtTuoi.Value, txtDiaChi.Text, txtSdt.Text,txtEmail.Text))
            {
                MessageBox.Show("Thêm mới thành công");
                LoadDtgv();

            }
            else
            {
                MessageBox.Show("Thêm mới không thành công. Vui lòng kiểm tra lại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!MyRegular.CheckRequired(txtCmtnd.Text, "Bắt buộc nhập vào Cmtnd"))
                return;
            if (!MyRegular.CheckRequired(txtDiaChi.Text, "Bắt buộc nhập vào địa chỉ"))
                return;
            if (!MyRegular.CheckRequired(txtTen.Text, "Bắt buộc nhập vào tên"))
                return;

            if (!MyRegular.CheckEmail(txtEmail.Text))
                return;
            if (!MyRegular.CheckPhoneNumber(txtSdt.Text))
                return;
            if (!MyRegular.CheckCMTND(txtCmtnd.Text))
                return;

            if (txtCmtnd.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập vào cmtnd");
                return;
            }
            if (KhachHangDAO.Instance.Edit(txtCmtnd.Text, txtTen.Text, (int)txtTuoi.Value, txtDiaChi.Text,  txtSdt.Text, txtEmail.Text))
            {
                MessageBox.Show("Cập nhật thành công");
                LoadDtgv();

            }
            else
            {
                MessageBox.Show("Cập nhật không thành công. Vui lòng kiểm tra lại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!MyRegular.CheckRequired(txtCmtnd.Text, "Bắt buộc nhập vào Cmtnd"))
                return;
            if(txtCmtnd.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập vào cmtnd");
                return;
            }
            if (KhachHangDAO.Instance.Del(txtCmtnd.Text))
            {
                MessageBox.Show("Xóa thành công");
                LoadDtgv();

            }
            else
            {
                MessageBox.Show("Không thể xóa khách hàng này. Hóa đơn cần thông tin của Khách hàng này!!!");
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadDtgv();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (!MyRegular.CheckRequired(txtCmtnd.Text, "Bạn hãy nhập vào từ khóa tìm kiếm"))
                return;
            bds.DataSource = KhachHangDAO.Instance.Find(txtTimKiem.Text);
        }
    }
}
