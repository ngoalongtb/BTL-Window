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
    public partial class fXuat : Form
    {
        private KhachHang currKh;
        private BindingSource bds = new BindingSource();
        private TaiKhoan acc;
        private int currIDXuat = 0;
        public fXuat(TaiKhoan acc)
        {
            InitializeComponent();
            this.acc = acc;
        }

        public void ChangeHeader()
        {
            dtgv.Columns["MaMayTinh"].HeaderText = "Mã máy tính";
            dtgv.Columns["SoLuong"].HeaderText = "Số lượng";
            dtgv.Columns["IDXuat"].HeaderText = "Số hóa đơn xuất";
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

        private event EventHandler dangBanHang;
        public event EventHandler DangBanHang
        {
            add
            {
                dangBanHang += value;
            }
            remove
            {
                dangBanHang -= value;
            }
        }
        private event EventHandler daBanHang;
        public event EventHandler DaBanHang
        {
            add
            {
                daBanHang += value;
            }
            remove
            {
                daBanHang -= value;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

            if (btnConfirm.Text == "Hủy bỏ")
            {
                if (txtThanhTien.Text != "0")
                {
                    MessageBox.Show("Bạn cần trả lại hết hàng");
                    return;
                }
                if (XuatDAO.Instance.Del(currIDXuat))
                {
                    btnConfirm.BackColor = Color.Orange;
                    btnConfirm.Text = "Bắt đầu mua hàng";
                    pnChiTietXuat.Visible = false;
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra. Vui lòng liên hệ admin");
                }
                return;
            }

            if (txtCmtnd.Text.Trim() == "")
            {
                MessageBox.Show("Mã không được để trống");
                return;
            }
            currKh = KhachHangDAO.Instance.Check(txtCmtnd.Text);
            if (currKh == null)
            {
                MessageBox.Show("Vui lòng nhập vào thông tin khách hàng!!!");

                myEvent(this, new EventArgs());
                //Chuyển form
                return;
            }
            //thành công add 1 cái Xuat
            if (MessageBox.Show("Bạn có chắc chắn đang nhập hàng của nhà cung cấp có mã:" + currKh.Cmtnd + " tên là: " + currKh.Ten, "Xác nhận", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {

                if (XuatDAO.Instance.Add(txtCmtnd.Text, acc.UserName) == 0)
                {
                    MessageBox.Show("Có lỗi xảy ra. Liên hệ admin");
                    return;
                }
                //thành công
                currIDXuat = XuatDAO.Instance.GetMaxID();
                btnConfirm.BackColor = Color.FromArgb(21, 21, 21);
                btnConfirm.Text = "Hủy bỏ";
                pnChiTietXuat.Visible = true;
                LoadDtgv();
                dtgv.DataSource = bds;
                ChangeHeader();
                AddDataBinding();
                dangBanHang(this, e);
            }



        }
        public void LoadTxtThanhTien()
        {
            txtThanhTien.Text = XuatDAO.Instance.GetTotalPriceById(currIDXuat).ToString();
        }
        public void LoadDtgv()
        {
            bds.DataSource = ChiTietXuatDAO.Instance.GetByIdXuat(currIDXuat);
        }
        public void AddDataBinding()
        {
            txtMaMayTinh.DataBindings.Clear();
            nbudSoLuong.DataBindings.Clear();
            txtMaMayTinh.DataBindings.Add("Text", dtgv.DataSource, "MaMayTinh",true,DataSourceUpdateMode.Never);
            nbudSoLuong.DataBindings.Add("Value", dtgv.DataSource, "SoLuong", true, DataSourceUpdateMode.Never);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            if (txtMaMayTinh.Text.Trim() == "")
            {
                MessageBox.Show("Không được bỏ trống mã máy tính");
                return;
            }
            if (ChiTietXuatDAO.Instance.Add(currIDXuat, txtMaMayTinh.Text, (int)nbudSoLuong.Value))
            {
                MessageBox.Show("Thêm thành công");
                LoadDtgv();
                LoadTxtThanhTien();
            }
            else
            {
                MessageBox.Show("Hết hàng");
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            if (ChiTietXuatDAO.Instance.Del(int.Parse(dtgv.SelectedRows[0].Cells["ID"].Value.ToString())))
            {
                MessageBox.Show("Hủy thành công");
                LoadDtgv();
                LoadTxtThanhTien();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra");
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Thành tiền : "+ txtThanhTien.Text+"\r\n Thanh toán:","Xác nhận",MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                daBanHang(this, e);
                this.Close();
            }
        }

    }
}
