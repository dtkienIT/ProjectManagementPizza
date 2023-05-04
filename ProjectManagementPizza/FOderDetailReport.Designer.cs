
namespace ProjectManagementPizza
{
    partial class FOderDetailReport
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dsProduct = new ProjectManagementPizza.dsProduct();
            this.order_detailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.order_detailTableAdapter = new ProjectManagementPizza.dsProductTableAdapters.order_detailTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.order_detailBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.order_detailBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ProjectManagementPizza.orderDetailReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-2, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1272, 523);
            this.reportViewer1.TabIndex = 0;
            // 
            // dsProduct
            // 
            this.dsProduct.DataSetName = "dsProduct";
            this.dsProduct.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // order_detailBindingSource
            // 
            this.order_detailBindingSource.DataMember = "order_detail";
            this.order_detailBindingSource.DataSource = this.dsProduct;
            // 
            // order_detailTableAdapter
            // 
            this.order_detailTableAdapter.ClearBeforeFill = true;
            // 
            // FOderDetailReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 525);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FOderDetailReport";
            this.Text = "FOderDetailReport";
            this.Load += new System.EventHandler(this.FOderDetailReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.order_detailBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource order_detailBindingSource;
        private dsProduct dsProduct;
        private dsProductTableAdapters.order_detailTableAdapter order_detailTableAdapter;
    }
}