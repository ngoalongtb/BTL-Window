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
    public partial class fThongTinCaNhan : Form
    {
        private TaiKhoan loginAccount;
        public fThongTinCaNhan(TaiKhoan acc)
        {
            InitializeComponent();
            loginAccount = acc;
            LoadData();
        }
        private event EventHandler capNhatThongTin;
        public event EventHandler CapNhatThongTin
        {
            add
            {
                capNhatThongTin += value;
            }
            remove
            {
                capNhatThongTin -= value;
            }
        }
        public void LoadData()
        {
            txtUsername.Text = loginAccount.UserName;
            txtDisplayName.Text = loginAccount.TenHienThi;
        }

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {

            if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");
                return;
            }
            if (txtPassword.Text != loginAccount.Password)
            {
                MessageBox.Show("Mật khẩu không chính xác");
                return;
            }
            if(txtDisplayName.Text.Trim()=="")
            {
                MessageBox.Show("Bắt buộc phải nhập tên hiển thị");
                return;
            }
            if(txtNewPass.Text != txtReNewPass.Text)
            {
                MessageBox.Show("Mật khẩu mới không khớp");
                return;
            }
            string strNewPass = loginAccount.Password;
            if (txtNewPass.Text.Trim() != "")
                strNewPass = txtNewPass.Text;
            if(TaiKhoanDAO.Instance.Edit(loginAccount.UserName,strNewPass,txtDisplayName.Text))
            {
                MessageBox.Show("Cập nhật thành công");
                capNhatThongTin(this, e);
            }
            else
            {
                MessageBox.Show("Thất bại. Xin lỗi vì sự cố đáng tiếc. Vui lòng gặp admin để sửa lỗi!!!");
            }

        }
    }
}
