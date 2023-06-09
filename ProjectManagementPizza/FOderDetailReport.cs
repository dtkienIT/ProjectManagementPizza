﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementPizza
{
    public partial class FOderDetailReport : Form
    {
        public FOderDetailReport()
        {
            InitializeComponent();
        }

        private void FOderDetailReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsProduct1.product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.dsProduct1.product);
          
            // TODO: This line of code loads data into the 'dsProduct.order_detail' table. You can move, or remove it, as needed.
            this.order_detailTableAdapter.Fill(this.dsProduct.order_detail,1);

            this.reportViewer1.RefreshReport();
           
        }

        private void cbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.order_detailTableAdapter.Fill(this.dsProduct.order_detail, (int)cbProduct.SelectedValue);
            this.reportViewer1.RefreshReport();
        }
    }
}
