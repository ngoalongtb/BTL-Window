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
    public partial class fNhaCungCap : Form
    {
        public fNhaCungCap()
        {
            InitializeComponent();
        }
        private BindingSource bds = new BindingSource();
        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            dtgv.DataSource = bds;
            LoadDtgv();
            ChangHeader();
            AddDataBinding();
            
        }

        public void LoadDtgv()
        {
            bds.DataSource = NhaCungCapDAO.Instance.GetAll();
        }
        public void ChangHeader()
        {
            dtgv.Columns["Ma"].HeaderText = "Mã";
            dtgv.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dtgv.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
            dtgv.Columns["Ten"].HeaderText = "Tên";

        }
        public void AddDataBinding()
        {
            txtMa.DataBindings.Add("Text", dtgv.DataSource, "Ma",true,DataSourceUpdateMode.OnPropertyChanged);
            txtDiaChi.DataBindings.Add("Text", dtgv.DataSource, "DiaChi", true, DataSourceUpdateMode.OnPropertyChanged);
            txtEmail.DataBindings.Add("Text", dtgv.DataSource, "Email", true, DataSourceUpdateMode.OnPropertyChanged);
            txtSoDienThoai.DataBindings.Add("Text", dtgv.DataSource, "SoDienThoai", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTen.DataBindings.Add("Text", dtgv.DataSource, "Ten", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!MyRegular.CheckRequired(txtMa.Text, "Bắt buộc nhập vào mã nhà cung cấp"))
                return;
            if (!MyRegular.CheckRequired(txtTen.Text, "Bắt buộc nhập vào tên nhà cung cấp"))
                return;
            if (!MyRegular.CheckRequired(txtDiaChi.Text, "Bắt buộc nhập vào địa chỉ nhà cung cấp"))
                return;
            if (!MyRegular.CheckEmail(txtEmail.Text))
                return;
            if (!MyRegular.CheckPhoneNumber(txtSoDienThoai.Text))
                return;
            if (!MyRegular.CheckMaNCC(txtMa.Text))
                return;

            if (txtMa.Text.Trim() == "")
            {
                MessageBox.Show("Bắt buộc nhập vào mã");
                return;
            }
            if(NhaCungCapDAO.Instance.Add(txtMa.Text,txtTen.Text,txtDiaChi.Text, txtSoDienThoai.Text,txtEmail.Text))
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
            if (!MyRegular.CheckRequired(txtMa.Text, "Bắt buộc nhập vào mã nhà cung cấp"))
                return;
            if (!MyRegular.CheckRequired(txtTen.Text, "Bắt buộc nhập vào tên nhà cung cấp"))
                return;
            if (!MyRegular.CheckRequired(txtDiaChi.Text, "Bắt buộc nhập vào địa chỉ nhà cung cấp"))
                return;
            if (!MyRegular.CheckEmail(txtEmail.Text))
                return;
            if (!MyRegular.CheckPhoneNumber(txtSoDienThoai.Text))
                return;
            
            //else
            if (txtMa.Text.Trim() == "")
            {
                MessageBox.Show("Bắt buộc nhập vào mã");
                return;
            }
            if (NhaCungCapDAO.Instance.Edit(txtMa.Text, txtTen.Text, txtDiaChi.Text, txtSoDienThoai.Text, txtEmail.Text))
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
            if (!MyRegular.CheckRequired(txtMa.Text, "Bắt buộc nhập vào mã nhà cung cấp"))
                return;

            if(txtMa.Text.Trim()=="")
            {
                MessageBox.Show("Bắt buộc nhập vào mã");
                return;
            }
            if (NhaCungCapDAO.Instance.Del(txtMa.Text))
            {
                MessageBox.Show("Xóa thành công");
                LoadDtgv();

            }
            else
            {
                MessageBox.Show("Vui lòng xử lý hóa đơn trước");
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadDtgv();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (!MyRegular.CheckRequired(txtTimKiem.Text, "Bạn cần nhập vào từ khóa tìm kiếm"))
                return;
            bds.DataSource = NhaCungCapDAO.Instance.Find(txtTimKiem.Text);
        }
    }
}
