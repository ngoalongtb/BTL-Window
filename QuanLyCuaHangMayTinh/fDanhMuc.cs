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
    public partial class fDanhMuc : Form
    {
        public fDanhMuc()
        {
            InitializeComponent();
        }

        private BindingSource bds = new BindingSource();

        private void fDanhMuc_Load(object sender, EventArgs e)
        {
            LoadDtgv();
            dtgv.DataSource = bds;
            ChangHeader();
            LoadDataBinding();
        }

        public void LoadDtgv()
        {
            bds.DataSource = DanhMucDAO.Instance.GetAll();
        }
        public void ChangHeader()
        {
            dtgv.Columns["TenDanhMuc"].HeaderText = "Tên danh mục";

        }
        public void LoadDataBinding()
        {
            txtId.DataBindings.Add("Text", dtgv.DataSource, "Id",true,DataSourceUpdateMode.Never);
            txtTen.DataBindings.Add("Text", dtgv.DataSource, "TenDanhMuc", true, DataSourceUpdateMode.Never);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!MyRegular.CheckRequired(txtTen.Text, "Bắt buộc nhập vào tên danh mục"))
                return;
            //else
            if (DanhMucDAO.Instance.Add(txtTen.Text))
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
            if (!MyRegular.CheckRequired(txtId.Text, "Bạn phải nhập vào mã cần sửa"))
                return;
            if (!MyRegular.CheckRequired(txtTen.Text, "Bắt buộc nhập vào tên danh mục"))
                return;
            //else
            if (DanhMucDAO.Instance.Edit(int.Parse(txtId.Text),txtTen.Text))
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
            if (!MyRegular.CheckRequired(txtId.Text, "Bạn phải nhập vào mã cần xóa"))
                return;
            //else
            if (DanhMucDAO.Instance.Del(int.Parse(txtId.Text)))
            {
                MessageBox.Show("Xóa thành công");
                LoadDtgv();

            }
            else
            {
                MessageBox.Show("Tồn tại Máy tính trong danh mục này");
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadDtgv();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (!MyRegular.CheckRequired(txtTimKiem.Text, "Bạn hãy nhập vào từ khóa cần tìm kiếm"))
                return;
            //else
            bds.DataSource = DanhMucDAO.Instance.Find(txtTimKiem.Text);
        }
        
    }
}
