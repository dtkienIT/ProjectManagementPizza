using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ProjectManagementPizza
{
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
        }
        PizzaDataContext db = null;

        private void MyCommune()
        {
            db = new PizzaDataContext();
            var Comm = from c in db.communes select c.commune_id;
            foreach (string a in Comm)
            {
                cbCommune.Items.Add(a);
            }
            cbCommune.SelectedIndex = 0;
        }
        private void MyStaff()
        {
            var Staf = from s in db.staffs
                       join Comm in db.communes on s.commune_id equals Comm.commune_id
                       where (Comm.commune_id == cbCommune.Text)
                       select s;
            dataGridView1.DataSource = Staf;
        }

        public bool checking()
        {
            int t; decimal y;
            bool a = int.TryParse(txtSID.Text, out t);
            bool b = decimal.TryParse(txtSalary.Text, out y);
            if (a == false)
            {
                MessageBox.Show("ID khong hop le! moi nhap lai! ");
                txtSID.ResetText();
                txtSID.Focus();
                return false;
            }
            else if (b == false)
            {
                MessageBox.Show("Salary khong hop le! moi nhap lai! ");
                txtSalary.ResetText();
                txtSalary.Focus();
                return false;

            }
            else
                return true;
        }
        private void Staff_Load(object sender, EventArgs e)
        {
            MyCommune();
        }

        public void resetall()
        {
            txtEmail.ResetText();
            txtSName.ResetText();
            txtSID.ResetText();
            txtPhone.ResetText();
            txtSalary.ResetText();
            txtStreet.ResetText();
        }
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) { this.Close(); return false; }
            else return base.ProcessCmdKey(ref msg, keyData);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (checking() == true)
            {
                db.staffs.InsertOnSubmit(new staff
                {
                    staff_id = Convert.ToInt32(txtSID.Text),

                    staff_name = txtSName.Text,

                    phone_number = txtPhone.Text,

                    email = txtEmail.Text,

                    street = txtStreet.Text,

                    salary = Convert.ToDecimal(txtSalary.Text),
                    commune_id = cbCommune.Text,
                });
                db.SubmitChanges();
                cbCommune.Items.Clear();
                MyCommune();
                MyStaff();
                resetall();
                MessageBox.Show("Nhap du lieu thanh cong! ");
            }
            else { }
        }

        private void btCancel_Click_1(object sender, EventArgs e)
        {
            resetall();
        }

        private void btDelete_Click_1(object sender, EventArgs e)
        {

            try
            {
                int r = dataGridView1.CurrentCell.RowIndex;
                string temp = dataGridView1.Rows[r].Cells[0].Value.ToString();
                staff s = db.staffs.Single(x => x.staff_id == Convert.ToInt32(temp));
                db.staffs.DeleteOnSubmit(s);
                db.SubmitChanges();
                MyStaff();
                MessageBox.Show("Delete thanh cong! ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khong the xoa! ");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cbCommune.Items.Clear();
            MyCommune();MyStaff();
        }

        private void btSave_Click_1(object sender, EventArgs e)
        {
            if (checking() == true)
            {
                try
                {
                    int r = dataGridView1.CurrentCell.RowIndex;
                    string tempDID = dataGridView1.Rows[r].Cells[0].Value.ToString();
                    staff s = db.staffs.Single(x => x.staff_id == Convert.ToInt32(tempDID));
                    s.staff_id = Convert.ToInt32(txtSID.Text);

                    s.staff_name = txtSName.Text;

                    s.phone_number = txtPhone.Text;

                    s.email = txtEmail.Text;

                    s.street = txtStreet.Text;

                    s.salary = Convert.ToDecimal(txtSalary.Text);

                    db.SubmitChanges();
                    MessageBox.Show("Nhap thanh cong!");
                }
                catch (Exception)
                {
                    MessageBox.Show("ID da ton tai!");
                }
            }
            else { }
        }

        private void btReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuQuanLi z = new MenuQuanLi();
            z.ShowDialog();
            this.Close();
        }

        private void btEdit_Click_1(object sender, EventArgs e)
        {
            dataGridView1_CellContentClick(null, null);
            txtSID.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;
            // Chuyển thông tin từ Gridview lên các textbox ở panel
            txtSID.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
            txtSName.Text = dataGridView1.Rows[r].Cells[1].Value.ToString();
            txtPhone.Text = dataGridView1.Rows[r].Cells[2].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[r].Cells[3].Value.ToString();
            txtStreet.Text = dataGridView1.Rows[r].Cells[4].Value.ToString();
            cbCommune.Text = dataGridView1.Rows[r].Cells[5].Value.ToString();
            txtSalary.Text = dataGridView1.Rows[r].Cells[6].Value.ToString();
        }

        private void cbCommune_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyStaff();
        }

        private void btAdd_Click_1(object sender, EventArgs e)
        {
            if (checking() == true)
            {
                try
                {
                    db.staffs.InsertOnSubmit(new staff
                    {
                        staff_id = Convert.ToInt32(txtSID.Text),

                        staff_name = txtSName.Text,

                        phone_number = txtPhone.Text,

                        email = txtEmail.Text,

                        street = txtStreet.Text,

                        salary = Convert.ToDecimal(txtSalary.Text),
                        commune_id = cbCommune.Text,
                    });
                    db.SubmitChanges();
                    MyCommune();
                    MyStaff();
                    resetall();
                    MessageBox.Show("Nhap du lieu thanh cong! ");
                }
                catch (Exception)
                {
                    MessageBox.Show("ID da ton tai!"); 
                }
            }
            else { }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtSalary_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStreet_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtCID_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
