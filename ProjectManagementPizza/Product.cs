using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.IO;

namespace ProjectManagementPizza
{
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }
        PizzaDataContext db = null;
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            
        }

        private void Product_Load(object sender, EventArgs e)
        {
            MySetProductInDataGridView();
            List<string> searchOptions = new List<string> { "Product Name", "Price", "Description" };
            cbSearch.Items.AddRange(searchOptions.ToArray());

        }
        private void quantityProductCurrent()
        {
            db = new PizzaDataContext();
            int quantityProductCurrent = db.products.Count();
            lblProduct.Text = quantityProductCurrent.ToString();
        }
        private void MySetProductInDataGridView()
        {
            db = new PizzaDataContext();

            var product = from p in db.products select p;
            dtGridView.DataSource = product.ToList();
            quantityProductCurrent();



        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
      
        private void btnAdd_Click(object sender, EventArgs e)
        {
            db.products.InsertOnSubmit(new product
            {              
                product_name = txtPN.Text,
                unit_price = int.Parse(txtP.Text),
                description = txtD.Text,
            });
            db.SubmitChanges();
            MySetProductInDataGridView();
            MessageBox.Show("Thêm thành công!", "Thông báo");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dtGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dtGridView.CurrentCell.RowIndex;
            string chuoi = "";
            // Chuyển thông tin từ Gridview lên các textbox ở panel
            txtPN.Text = dtGridView.Rows[r].Cells[1].Value.ToString();
            chuoi = dtGridView.Rows[r].Cells[2].Value.ToString();
            txtP.Text = chuoi.Replace(".00", "");
            txtD.Text = dtGridView.Rows[r].Cells[3].Value.ToString();
          
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) { this.Close(); return false; }
            else return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int r = dtGridView.CurrentCell.RowIndex;
            int tempDID = int.Parse(dtGridView.Rows[r].Cells[0].Value.ToString());
            
                product DistQ = db.products.Single(x => x.product_id == tempDID);
            DistQ.product_name = txtPN.Text;
                DistQ.unit_price = int.Parse(txtP.Text);
            DistQ.description = txtD.Text;

                db.SubmitChanges();
            MySetProductInDataGridView();
            MessageBox.Show("Sửa thành công!", "Thông báo");
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySetProductInDataGridView();
            txtD.Text = "";
            txtP.Text = "";
            txtPN.Text = "";
            txtSearch.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dtGridView.CurrentCell.RowIndex;
                int tempDID = int.Parse(dtGridView.Rows[r].Cells[0].Value.ToString());
                product DistQ = db.products.Single(x => x.product_id == tempDID);
                db.products.DeleteOnSubmit(DistQ);
                db.SubmitChanges();
                MySetProductInDataGridView();
                MessageBox.Show("Xóa thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchField = cbSearch.SelectedItem.ToString();
            string searchTerm = txtSearch.Text;


            var query = db.products.Where(c =>
                         searchField == "Product Name" ? c.product_name.StartsWith(searchTerm) :
                         searchField == "Price" ? c.unit_price.ToString().StartsWith(searchTerm) :
                         searchField == "Description" ? c.description.StartsWith(searchTerm) :
                         false).ToList();

            dtGridView.DataSource = query;
        }
    }
}
