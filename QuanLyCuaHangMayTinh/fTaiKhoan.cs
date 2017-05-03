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
    public partial class fTaiKhoan : Form
    {
        private TaiKhoan acc;
        private BindingSource bds = new BindingSource();
        public fTaiKhoan(TaiKhoan acc)
        {
            InitializeComponent();
            this.acc = acc;
            LoadDtgv();
            
            dtgv.DataSource = bds;
            dtgv.Columns["Password"].Visible = false;
            AddDataBinding();
            ChangHeader();
            
        }
        public void ChangHeader()
        {
            dtgv.Columns["TenHienThi"].HeaderText = "Tên hiển thị";
            dtgv.Columns["LoaiTaiKhoan"].HeaderText = "Loại tài khoản";
            dtgv.Columns["Username"].HeaderText = "Tên tài khoản";

        }

        public void LoadDtgv()
        {
            bds.DataSource = TaiKhoanDAO.Instance.GetAll();
        }

        public void AddDataBinding()
        {
            txtUsername.DataBindings.Add("Text", dtgv.DataSource, "UserName",true,DataSourceUpdateMode.Never);

            txtDisplayName.DataBindings.Add("Text", dtgv.DataSource, "TenHienThi", true, DataSourceUpdateMode.Never);
        }

        

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgv.SelectedRows[0].Cells["LoaiTaiKhoan"].Value.ToString() == "admin")
                {
                    cbxType.SelectedIndex = 0;
                }
                else cbxType.SelectedIndex = 1;
            }
            catch (Exception)
            {
                cbxType.SelectedIndex = 0;
            }
            
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if(!MyRegular.CheckRequired(txtUsername.Text,"Bắt buộc nhập vào username"))
                return;
            if (!MyRegular.CheckRequired(txtDisplayName.Text, "Bắt buộc nhập vào tên hiển thị"))
                return;
            

            if(TaiKhoanDAO.Instance.Add(txtUsername.Text, txtDisplayName.Text, cbxType.SelectedIndex))
            {
                MessageBox.Show("Tại tài khoản thành công\r\n "+txtUsername.Text+" mật khẩu: 12345 .\r\nVui lòng đăng nhập và đổi mật khẩu");
                LoadDtgv();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra");
            }

            //if (txtUsername.Text == acc.UserName)
            //{
            //    MessageBox.Show("Bạn không thể thay đổi thông tin cá nhân ở đây");
            //    return;
            //}
        }
        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadDtgv();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!MyRegular.CheckRequired(txtUsername.Text, "Bắt buộc nhập vào username"))
                return;
            if (!MyRegular.CheckRequired(txtDisplayName.Text, "Bắt buộc nhập vào tên hiển thị"))
                return;

            if (txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("Username không được để trống");
                return;
            }
            if (txtUsername.Text == acc.UserName)
            {
                MessageBox.Show("Bạn không thể thay đổi thông tin cá nhân ở đây");
                return;
            }
            if (TaiKhoanDAO.Instance.Update(txtUsername.Text, txtDisplayName.Text, cbxType.SelectedIndex))
            {
                MessageBox.Show("Cập nhật thành công");
                LoadDtgv();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (!MyRegular.CheckRequired(txtTimKiem.Text, "Bạn nhập vào từ khóa để tìm kiếm"))
                return;
            bds.DataSource = TaiKhoanDAO.Instance.Find(txtTimKiem.Text);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("Username không được để trống");
                return;
            }
            if (txtUsername.Text == acc.UserName)
            {
                MessageBox.Show("Bạn không thể thay đổi thông tin cá nhân ở đây");
                return;
            }
            if(MessageBox.Show("Bạn có chắc chắn xóa tài khoản này.\r\n  Các giao dịch do tk này sẽ không chứa thông tin tài khoản ","Xác nhận",MessageBoxButtons.OKCancel)==System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            if (TaiKhoanDAO.Instance.Del(txtUsername.Text))
            {
                MessageBox.Show("Xóa thành công");
                LoadDtgv();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra");
            }
        }
    }
}
