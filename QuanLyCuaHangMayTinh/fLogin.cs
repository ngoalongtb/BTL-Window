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
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }
        #region menu
        private bool isMouseDown = false;
        private int x,y;

        private void pn_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            x = e.X;
            y = e.Y;
        }

        private void pn_MouseMove(object sender, MouseEventArgs e)
        {
            if(isMouseDown)
            {
                this.Location = new Point(this.Location.X + e.X - x, this.Location.Y + e.Y - y);
            }
        }

        private void pn_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void lbl_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            x = e.X ;
            y = e.Y ;
        }

        private void lbl_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                this.Location = new Point(this.Location.X  + e.X - x, this.Location.Y  + e.Y - y);
            }
        }

        private void lbl_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void btnMinimum_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
#endregion
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (TaiKhoanDAO.Instance.CheckLogin(txtUserName.Text, txtPassword.Text))
                {
                    this.Hide();
                    TaiKhoan acc = TaiKhoanDAO.Instance.GetByUsername(txtUserName.Text);
                    fManager f = new fManager(acc);
                    f.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác. Vui lòng kiểm tra lại!!!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Kết nối không thành công.\r\n Kiểm tra lại connection string hoặc liên hệ admin");
            }
            
        }

        
    }
}
