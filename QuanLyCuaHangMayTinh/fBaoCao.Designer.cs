namespace QuanLyCuaHangMayTinh
{
    partial class fBaoCao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.uspGetHoaDonNhapByTimeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QLCHMTDataSet = new QuanLyCuaHangMayTinh.QLCHMTDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.uspGetHoaDonNhapByTimeTableAdapter = new QuanLyCuaHangMayTinh.QLCHMTDataSetTableAdapters.uspGetHoaDonNhapByTimeTableAdapter();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.QLCHMTDataSet1 = new QuanLyCuaHangMayTinh.QLCHMTDataSet1();
            this.uspGetHoaDonXuatByTimeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uspGetHoaDonXuatByTimeTableAdapter = new QuanLyCuaHangMayTinh.QLCHMTDataSet1TableAdapters.uspGetHoaDonXuatByTimeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.uspGetHoaDonNhapByTimeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLCHMTDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLCHMTDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspGetHoaDonXuatByTimeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // uspGetHoaDonNhapByTimeBindingSource
            // 
            this.uspGetHoaDonNhapByTimeBindingSource.DataMember = "uspGetHoaDonNhapByTime";
            this.uspGetHoaDonNhapByTimeBindingSource.DataSource = this.QLCHMTDataSet;
            // 
            // QLCHMTDataSet
            // 
            this.QLCHMTDataSet.DataSetName = "QLCHMTDataSet";
            this.QLCHMTDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.uspGetHoaDonNhapByTimeBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyCuaHangMayTinh.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(814, 595);
            this.reportViewer1.TabIndex = 0;
            // 
            // uspGetHoaDonNhapByTimeTableAdapter
            // 
            this.uspGetHoaDonNhapByTimeTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.uspGetHoaDonXuatByTimeBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "QuanLyCuaHangMayTinh.Report2.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(814, 595);
            this.reportViewer2.TabIndex = 1;
            // 
            // QLCHMTDataSet1
            // 
            this.QLCHMTDataSet1.DataSetName = "QLCHMTDataSet1";
            this.QLCHMTDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uspGetHoaDonXuatByTimeBindingSource
            // 
            this.uspGetHoaDonXuatByTimeBindingSource.DataMember = "uspGetHoaDonXuatByTime";
            this.uspGetHoaDonXuatByTimeBindingSource.DataSource = this.QLCHMTDataSet1;
            // 
            // uspGetHoaDonXuatByTimeTableAdapter
            // 
            this.uspGetHoaDonXuatByTimeTableAdapter.ClearBeforeFill = true;
            // 
            // fBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(814, 595);
            this.Controls.Add(this.reportViewer2);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fBaoCao";
            this.Text = "fBaoCao";
            this.Load += new System.EventHandler(this.fBaoCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uspGetHoaDonNhapByTimeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLCHMTDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLCHMTDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uspGetHoaDonXuatByTimeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource uspGetHoaDonNhapByTimeBindingSource;
        private QLCHMTDataSet QLCHMTDataSet;
        private QLCHMTDataSetTableAdapters.uspGetHoaDonNhapByTimeTableAdapter uspGetHoaDonNhapByTimeTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource uspGetHoaDonXuatByTimeBindingSource;
        private QLCHMTDataSet1 QLCHMTDataSet1;
        private QLCHMTDataSet1TableAdapters.uspGetHoaDonXuatByTimeTableAdapter uspGetHoaDonXuatByTimeTableAdapter;

    }
}