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
    public partial class fNhap : Form
    {
        private TaiKhoan acc;
        private int currNCC = 0;
        private int currIdNhap = 0;
        private BindingSource bds = new BindingSource();
        public fNhap(TaiKhoan acc)
        {
            InitializeComponent();
            this.acc = acc;
        }
        public void ChangeHeader()
        {
            dtgv.Columns["MaMayTinh"].HeaderText = "Mã máy tính";
            dtgv.Columns["SoLuong"].HeaderText = "Số lượng";
            dtgv.Columns["IDNhap"].HeaderText = "Số hóa đơn nhập";
        }
        public void LoadDtgv()
        {
            bds.DataSource = ChiTietNhapDAO.Instance.GetByIDNhap(currIdNhap);
            dtgv.DataSource = bds;
            ChangeHeader();
            AddDataBinding();
        }
        public void LoadTxtThanhTien()
        {
            txtThanhTien.Text = NhapDAO.Instance.GetTotalPriceById(currIdNhap).ToString();
        }
        public void AddDataBinding()
        {
            txtMaMayTinh.DataBindings.Clear();
            nbudSoLuong.DataBindings.Clear();
            txtMaMayTinh.DataBindings.Add("Text", dtgv.DataSource, "MaMayTinh");
            nbudSoLuong.DataBindings.Add("Value", dtgv.DataSource, "SoLuong");
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

        private event EventHandler dangNhapHang;
        public event EventHandler DangNhapHang
        {
            add
            {
                dangNhapHang += value;
            }
            remove
            {
                dangNhapHang -= value;
            }
        }
        private event EventHandler daNhapHang;
        public event EventHandler DaNhapHang
        {
            add
            {
                daNhapHang += value;
            }
            remove
            {
                daNhapHang -= value;
            }
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(btnConfirm.Text == "Hủy bỏ")
            {
                if(txtThanhTien.Text !="0")
                {
                    MessageBox.Show("Bạn cần trả lại hết hàng");
                    return;
                }
                if (NhapDAO.Instance.Del(currIdNhap))
                {
                    btnConfirm.BackColor = Color.Orange;
                    btnConfirm.Text = "Xác nhận mã nhà cung cấp";
                    pnChiTietNhap.Visible = false;
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra. Vui lòng liên hệ admin");
                }
                return;
            }


            if(txtMaNhaCC.Text.Trim() == "")
            {
                MessageBox.Show("Mã không được để trống");
                return;
            }
            NhaCungCap ncc = NhaCungCapDAO.Instance.Check(txtMaNhaCC.Text);
            if(ncc == null)
            {
                MessageBox.Show("Mã nhà cung cấp này không tồn tại. Nhập vào thông tin nhà cung cấp!!!");
                myEvent(this,new EventArgs());
                //chuyển form
                return;
            }
            else
            {
                if(MessageBox.Show("Bạn có chắc chắn đang nhập hàng của nhà cung cấp có mã:"+ncc.Ma+" tên là: "+ncc.Ten,"Xác nhận",MessageBoxButtons.OKCancel)==System.Windows.Forms.DialogResult.OK)
                {
                    currNCC = NhapDAO.Instance.Add(txtMaNhaCC.Text, acc.UserName);
                    if (currNCC == 0)
                    {
                        MessageBox.Show("Có lỗi xảy ra. Liên hệ admin");
                        return;
                    }

                    //thành công
                    currIdNhap = NhapDAO.Instance.GetMaxId();
                    btnConfirm.BackColor = Color.FromArgb(21, 21, 21);
                    btnConfirm.Text = "Hủy bỏ";
                    pnChiTietNhap.Visible = true;
                    LoadDtgv();
                    dangNhapHang(this, e);

                    
                }
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!MyRegular.CheckRequired(txtMaMayTinh.Text, "Bắt buộc nhập vào mã máy tính"))
                return;

            if(txtMaMayTinh.Text.Trim() == "")
            {
                MessageBox.Show("Bắt buộc nhập trường này");
                return;
            }
            if(ChiTietNhapDAO.Instance.Add(currIdNhap,txtMaMayTinh.Text,(int)nbudSoLuong.Value))
            {
                LoadDtgv();
                LoadTxtThanhTien();
            }
            else
            {
                MessageBox.Show("Mã máy tính không đúng");
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            

            if (ChiTietNhapDAO.Instance.Del(int.Parse((dtgv.SelectedRows[0].Cells["ID"].Value).ToString())))
            {
                LoadDtgv();
                LoadTxtThanhTien();
            }
            else
            {
                MessageBox.Show("Không thể hoàn tác. Có lỗi xảy ra");
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thành tiền : " + txtThanhTien.Text + "\r\n Thanh toán:", "Xác nhận", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                daNhapHang(this, e);
                this.Close();
            }
        }
    }
}
