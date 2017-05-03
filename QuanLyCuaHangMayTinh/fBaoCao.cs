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
    public partial class fBaoCao : Form
    {
        private int type;
        private DateTime fromDay;
        private DateTime toDay;


        public fBaoCao(int type, DateTime fromDay, DateTime toDay)
        {
            InitializeComponent();
            this.Type = type;
            this.FromDay = fromDay;
            this.ToDay = toDay;
        }


        public DateTime ToDay
        {
            get { return toDay; }
            set { toDay = value; }
        }

        public DateTime FromDay
        {
            get { return fromDay; }
            set { fromDay = value; }
        }

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        private void fBaoCao_Load(object sender, EventArgs e)
        {
            if (this.Type == 1)
                reportViewer1.Hide();
            else
            {
                reportViewer2.Hide();
            }
            this.uspGetHoaDonNhapByTimeTableAdapter.Fill(QLCHMTDataSet.uspGetHoaDonNhapByTime, FromDay, ToDay);
            reportViewer1.RefreshReport();
            this.uspGetHoaDonXuatByTimeTableAdapter.Fill(QLCHMTDataSet1.uspGetHoaDonXuatByTime, FromDay, ToDay);
            this.reportViewer2.RefreshReport();
        }
    }
}
