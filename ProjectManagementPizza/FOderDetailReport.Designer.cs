
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
            this.order_detailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsProduct = new ProjectManagementPizza.dsProduct();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.order_detailTableAdapter = new ProjectManagementPizza.dsProductTableAdapters.order_detailTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.cbProduct = new System.Windows.Forms.ComboBox();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsProduct1 = new ProjectManagementPizza.dsProduct();
            this.dsProduct1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.provinceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.provinceTableAdapter = new ProjectManagementPizza.dsProductTableAdapters.provinceTableAdapter();
            this.productTableAdapter = new ProjectManagementPizza.dsProductTableAdapters.productTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.order_detailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProduct1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProduct1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.provinceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // order_detailBindingSource
            // 
            this.order_detailBindingSource.DataMember = "order_detail";
            this.order_detailBindingSource.DataSource = this.dsProduct;
            // 
            // dsProduct
            // 
            this.dsProduct.DataSetName = "dsProduct";
            this.dsProduct.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.order_detailBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ProjectManagementPizza.orderDetailReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 85);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1365, 446);
            this.reportViewer1.TabIndex = 0;
            // 
            // order_detailTableAdapter
            // 
            this.order_detailTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(190, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "List of product";
            // 
            // cbProduct
            // 
            this.cbProduct.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.productBindingSource, "product_id", true));
            this.cbProduct.DataSource = this.productBindingSource;
            this.cbProduct.DisplayMember = "product_name";
            this.cbProduct.FormattingEnabled = true;
            this.cbProduct.Location = new System.Drawing.Point(368, 25);
            this.cbProduct.Name = "cbProduct";
            this.cbProduct.Size = new System.Drawing.Size(251, 24);
            this.cbProduct.TabIndex = 2;
            this.cbProduct.ValueMember = "product_id";
            this.cbProduct.SelectedIndexChanged += new System.EventHandler(this.cbProduct_SelectedIndexChanged);
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "product";
            this.productBindingSource.DataSource = this.dsProduct1;
            // 
            // dsProduct1
            // 
            this.dsProduct1.DataSetName = "dsProduct";
            this.dsProduct1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsProduct1BindingSource
            // 
            this.dsProduct1BindingSource.DataSource = this.dsProduct1;
            this.dsProduct1BindingSource.Position = 0;
            // 
            // provinceBindingSource
            // 
            this.provinceBindingSource.DataMember = "province";
            this.provinceBindingSource.DataSource = this.dsProduct1;
            // 
            // provinceTableAdapter
            // 
            this.provinceTableAdapter.ClearBeforeFill = true;
            // 
            // productTableAdapter
            // 
            this.productTableAdapter.ClearBeforeFill = true;
            // 
            // FOderDetailReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 531);
            this.Controls.Add(this.cbProduct);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FOderDetailReport";
            this.Text = "FOderDetailReport";
            this.Load += new System.EventHandler(this.FOderDetailReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.order_detailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProduct1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsProduct1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.provinceBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource order_detailBindingSource;
        private dsProduct dsProduct;
        private dsProductTableAdapters.order_detailTableAdapter order_detailTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbProduct;
        private dsProduct dsProduct1;
        private System.Windows.Forms.BindingSource dsProduct1BindingSource;
        private System.Windows.Forms.BindingSource provinceBindingSource;
        private dsProductTableAdapters.provinceTableAdapter provinceTableAdapter;
        private System.Windows.Forms.BindingSource productBindingSource;
        private dsProductTableAdapters.productTableAdapter productTableAdapter;
    }
}