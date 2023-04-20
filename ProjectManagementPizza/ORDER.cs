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
    public partial class ORDER : Form
    {
        public ORDER()
        {
            InitializeComponent();
        }
        PizzaDataContext db = null;
        private void MyStaff()
        {
            db = new PizzaDataContext();

            var Staf = from s in db.staffs select s.staff_id;
            foreach (int a in Staf)
            {
                cbStaff.Items.Add(a);
            }
            cbStaff.SelectedIndex = 0;
        }
        private void MyCustomer()
        {
            db = new PizzaDataContext();

            var Cus = from c in db.customers select c.customer_id;
            foreach (int a in Cus)
            {
                cbCustomer.Items.Add(a);
            }
            cbCustomer.SelectedIndex = 0;
        }
        private void MyOrder()
        {
            int a;
            bool a1 = int.TryParse(cbCustomer.Text, out a);
            int b;
            bool b1 = int.TryParse(cbStaff.Text, out b);
            if (b1 == true && a1 == true)
            {
                a = Convert.ToInt32(cbCustomer.Text); b = Convert.ToInt32(cbStaff.Text);
                var Ord = from o in db.orders
                          join c in db.customers on o.customer_id equals c.customer_id
                          join s in db.staffs on o.staff_id equals s.staff_id
                          where (c.customer_id == a && s.staff_id == b)
                          select o;
                dataGridView1.DataSource = Ord;
            }
        }
        public void resetall()
        {
            txtSID.ResetText();
            dtOrderDate.ResetText();
            txtCusID.ResetText();
            txtOID.ResetText();
            txtTotal.ResetText();
            cbStatus.ResetText();
        }

        private bool checking()
        {
            int t; decimal y;
            bool a = int.TryParse(txtSID.Text, out t);
            bool b = decimal.TryParse(txtTotal.Text, out y);
            bool c = int.TryParse(txtOID.Text, out t);
            bool d = int.TryParse(txtCusID.Text, out t);
            if (a == false)
            {
                MessageBox.Show("Staff ID khong hop le! moi nhap lai! ");
                txtSID.ResetText();
                txtSID.Focus();
                return false;
            }
            else if (b == false)
            {
                MessageBox.Show("Total khong hop le! moi nhap lai! ");
                txtTotal.ResetText();
                txtTotal.Focus();
                return false;

            }
            else if (c == false)
            {
                MessageBox.Show("Order ID khong hop le! moi nhap lai! ");
                txtOID.ResetText();
                txtTotal.Focus();
                return false;
            }
            else if (d == false)
            {
                MessageBox.Show("Customer khong hop le! moi nhap lai! ");
                txtTotal.ResetText();
                txtTotal.Focus();
                return false;
            }
            else
                return true;
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            if (checking() == true)
            {
                db.orders.InsertOnSubmit(new order
                {
                    order_id = Convert.ToInt32(txtOID.Text),

                    customer_id = Convert.ToInt32(cbCustomer.Text),

                    staff_id = Convert.ToInt32(cbStaff.Text),

                    order_date = dtOrderDate.Value,

                    total = Convert.ToDecimal(txtTotal.Text),

                    status = cbStatus.Text,
                });
                cbStaff.Items.Clear();
                cbCustomer.Items.Clear();
                db.SubmitChanges();
                MyOrder();
                MyStaff();
                MyCustomer();
                resetall();
                MessageBox.Show("Nhập dữ liệu thành công!");
            }
            else { }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;
            // Chuyển thông tin từ Gridview lên các textbox ở panel
            txtOID.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
            txtCusID.Text = dataGridView1.Rows[r].Cells[1].Value.ToString();
            txtSID.Text = dataGridView1.Rows[r].Cells[2].Value.ToString();
            dtOrderDate.Text = dataGridView1.Rows[r].Cells[3].Value.ToString();
            txtTotal.Text = dataGridView1.Rows[r].Cells[4].Value.ToString();
            cbStatus.Text = dataGridView1.Rows[r].Cells[5].Value.ToString();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            dataGridView1_CellContentClick(null, null);
            txtOID.Focus();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dataGridView1.CurrentCell.RowIndex;
                string temp = dataGridView1.Rows[r].Cells[0].Value.ToString();
                order ord = db.orders.Single(x => x.order_id == Convert.ToInt32(temp));
                db.orders.DeleteOnSubmit(ord);
                db.SubmitChanges();
                MyOrder();
                MessageBox.Show("Xoa du lieu thanh cong!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khong the xoa! ");
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (checking() == true)
            {
                int r = dataGridView1.CurrentCell.RowIndex;
                string tempDID = dataGridView1.Rows[r].Cells[0].Value.ToString();
                order o = db.orders.Single(x => x.order_id == Convert.ToInt32(tempDID));

                o.order_id = Convert.ToInt32(txtOID.Text);

               

                

                o.order_date = dtOrderDate.Value;

                o.total = Convert.ToDecimal(txtTotal.Text);

                o.status = cbStatus.Text;
                db.SubmitChanges();
                MessageBox.Show("Nhap thanh cong!");
            }
            else { }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) { this.Close(); return false; }
            else if (keyData == Keys.Enter) { btAdd.PerformClick(); return false; }
            else return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ORDER_Load(object sender, EventArgs e)
        {
            MyStaff();
            MyCustomer();
        }

        private void cbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyOrder();
        }

        private void cbStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyOrder();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            resetall();
        }

        private void btReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuQuanLi z = new MenuQuanLi();
            z.ShowDialog();
            this.Close();
        }
    }
}
