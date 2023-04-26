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
    public partial class MenuQuanLi : Form
    {
        public MenuQuanLi()
        {
            InitializeComponent();
        }

        private void MenuQuanLi_Load(object sender, EventArgs e)
        {

        }

      
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void returnToLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn z = new LogIn();
            z.ShowDialog();
            this.Close();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) { this.Close(); return false; }
            else return base.ProcessCmdKey(ref msg, keyData);
        }

        private void createStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Staff z= new Staff();
            z.ShowDialog();
            this.Close();
        }

        private void createCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Form ap = new Customer();
            ap.ShowDialog();
            
        }

        private void createOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ORDER z = new ORDER();  
            z.ShowDialog();
            this.Close();
        }

        private void createProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ap = new Product();
            ap.ShowDialog();
        }
    }
}
