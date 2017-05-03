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
    public partial class fManager : Form
    {
        private TaiKhoan acc;
        private bool isReady = true;
        public fManager(TaiKhoan acc)
        {
            this.acc = acc;
            InitializeComponent();
            if (acc.LoaiTaiKhoan != "admin")
            {
                this.pnAdmin.Visible = false;
            }
            timer1.Interval = 30;
            timer1.Start();
        }
        #region menu
        private bool isMouseDown = false;
        private int x, y;

        private void pn_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            x = e.X;
            y = e.Y;
        }

        private void pn_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
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
            x = e.X;
            y = e.Y;
        }

        private void lbl_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                this.Location = new Point(this.Location.X + e.X - x, this.Location.Y + e.Y - y);
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

        #endregion

        
        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            if (!isReady)
            {
                MessageBox.Show("Vui lòng thanh toán trước khi thực hiện");
                return;
            }
            this.Close();
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            if (!isReady)
            {
                MessageBox.Show("Vui lòng thanh toán trước khi thực hiện");
                return;
            }
            fNhaCungCap f = new fNhaCungCap();
            f.TopLevel = false;
            pnContent.Controls.Clear();
            pnContent.Controls.Add(f);
            f.Show();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            if (!isReady)
            {
                MessageBox.Show("Vui lòng thanh toán trước khi thực hiện");
                return;
            }
            fKhachHang f = new fKhachHang();
            f.TopLevel = false;
            pnContent.Controls.Clear();
            pnContent.Controls.Add(f);
            f.Show();
        }

        private void txtDanhMuc_Click(object sender, EventArgs e)
        {
            if (!isReady)
            {
                MessageBox.Show("Vui lòng thanh toán trước khi thực hiện");
                return;
            }
            fDanhMuc f = new fDanhMuc();
            f.TopLevel = false;
            pnContent.Controls.Clear();
            pnContent.Controls.Add(f);
            f.Show();
        }

        private void btnMayTinh_Click(object sender, EventArgs e)
        {
            if (!isReady)
            {
                MessageBox.Show("Vui lòng thanh toán trước khi thực hiện");
                return;
            }
            fMayTinh f = new fMayTinh();
            f.TopLevel = false;
            pnContent.Controls.Clear();
            pnContent.Controls.Add(f);
            f.Show();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if (!isReady)
            {
                MessageBox.Show("Vui lòng thanh toán trước khi thực hiện");
                return;
            }
            this.Close();
        }

        private void btnThongTinCaNhan_Click(object sender, EventArgs e)
        {
            if (!isReady)
            {
                MessageBox.Show("Vui lòng thanh toán trước khi thực hiện");
                return;
            }
            fThongTinCaNhan f = new fThongTinCaNhan(acc);
            f.TopLevel = false;
            pnContent.Controls.Clear();
            pnContent.Controls.Add(f);
            f.Show();
            f.CapNhatThongTin += f_CapNhatThongTin;

        }

        void f_CapNhatThongTin(object sender, EventArgs e)
        {
            acc = TaiKhoanDAO.Instance.GetByUsername(acc.UserName);
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            if (!isReady)
            {
                MessageBox.Show("Vui lòng thanh toán trước khi thực hiện");
                return;
            }
            fNhap f = new fNhap(acc);
            f.TopLevel = false;
            pnContent.Controls.Clear();
            pnContent.Controls.Add(f);
            f.Show();
            f.MyEvent += btnNhaCungCap_Click;
            f.DangNhapHang += f_DangNhapHang;
            f.DaNhapHang += f_DaNhapHang;
        }

        void f_DaNhapHang(object sender, EventArgs e)
        {
            this.isReady = true;
        }

        void f_DangNhapHang(object sender, EventArgs e)
        {
            this.isReady = false;
        }
        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (!isReady)
            {
                MessageBox.Show("Vui lòng thanh toán trước khi thực hiện");
                return;
            }
            fXuat f = new fXuat(acc);
            f.TopLevel = false;
            pnContent.Controls.Clear();
            pnContent.Controls.Add(f);
            f.Show();
            f.MyEvent += btnKhachHang_Click;
            f.DangBanHang += f_DangBanHang;
            f.DaBanHang += f_DaBanHang;
        }

        void f_DaBanHang(object sender, EventArgs e)
        {
            this.isReady = true;
        }

        void f_DangBanHang(object sender, EventArgs e)
        {
            this.isReady = false;
        }


        private void btnAdmin_Click(object sender, EventArgs e)
        {
            if (!isReady)
            {
                MessageBox.Show("Vui lòng thanh toán trước khi thực hiện");
                return;
            }
            fTaiKhoan f = new fTaiKhoan(acc);
            f.TopLevel = false;
            pnContent.Controls.Clear();
            pnContent.Controls.Add(f);
            f.Show();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (!isReady)
            {
                MessageBox.Show("Vui lòng thanh toán trước khi thực hiện");
                return;
            }
            fThongKe f = new fThongKe();
            f.TopLevel = false;
            pnContent.Controls.Clear();
            pnContent.Controls.Add(f);
            f.Show();
            f.MyEvent += ShowReport;
        }

        void ShowReport(object sender, EventArgs e)
        {
            MyEventArgs mea = e as MyEventArgs;
            fBaoCao f = new fBaoCao(mea.Type,mea.FromTime,mea.ToTime);
            f.TopLevel = false;
            pnContent.Controls.Clear();
            pnContent.Controls.Add(f);

            f.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lblChayChu.Location.Y == -200)
            {
                lblChayChu.Location = new Point(lblChayChu.Location.X, 300);
            }
            lblChayChu.Location = new Point(lblChayChu.Location.X, lblChayChu.Location.Y - 1);
        }



    }
}
