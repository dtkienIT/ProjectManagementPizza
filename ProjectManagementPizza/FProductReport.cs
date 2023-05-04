using System;
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
    public partial class FProductReport : Form
    {
        public FProductReport()
        {
            InitializeComponent();
        }

        private void FProductReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsProduct.product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.dsProduct.product);

            this.reportViewer1.RefreshReport();
        }

        
    }
}
