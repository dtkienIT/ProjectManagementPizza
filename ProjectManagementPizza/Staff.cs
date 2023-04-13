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
        void SetBtEdit_On()
        {
            return;
            btAdd.Enabled = true;
            btSave.Enabled = true;
           
           
            // Enable các control Add, Edit, Delete, Exit...
            btAdd.Enabled = false;
            btEdit.Enabled = false;
            btDelete.Enabled = false;
            btReturn.Enabled = false;
            dataGridView1.Enabled = false;
        }
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
            int t, y;
            bool a = int.TryParse(txtSID.Text,out t);
            bool b =int.TryParse(txtSalary.Text,out y);
            if (a == false)
            {
                MessageBox.Show("ID khong hop le! moi nhap lai! ");
                txtSID.ResetText();
                txtSID.Focus();
                return false;
            }
            else if (b ==false)
            {
                MessageBox.Show("Salary khong hop le! moi nhap lai! ");
                txtSalary.ResetText();
                txtSalary.Focus();
                return false;

            }
            else
            return true;
        }
        
        private void button1_Click(object sender, EventArgs e)
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

                    salary = Convert.ToInt32(txtSalary.Text),
                    commune_id = cbCommune.Text,
                });
                db.SubmitChanges();
                MyCommune();
                MyStaff();
                resetall();
            }   
            else { }
        }

        private void cbCommune_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyStaff();
        }

        private void Staff_Load(object sender, EventArgs e)
        {
            MyCommune();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuQuanLi z= new MenuQuanLi();
            z.ShowDialog();
            this.Close();
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
            txtSalary.Text = dataGridView1.Rows[r].Cells[5].Value.ToString();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dataGridView1.CurrentCell.RowIndex;
                string temp = dataGridView1.Rows[r].Cells[0].Value.ToString();
                staff s = db.staffs.Single(x => x.staff_id == Convert.ToInt32(temp));
                db.staffs.DeleteOnSubmit(s);
                db.SubmitChanges();
                MyStaff();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khong the xoa! ");
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            dataGridView1_CellContentClick(null, null);
            txtSID.Focus();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (checking() == true)
            {
                int r = dataGridView1.CurrentCell.RowIndex;
                string tempDID = dataGridView1.Rows[r].Cells[0].Value.ToString();
                staff s = db.staffs.Single(x => x.staff_id == Convert.ToInt32(tempDID));
                s.staff_id = Convert.ToInt32(txtSID.Text);

                s.staff_name = txtSName.Text;

                s.phone_number = txtPhone.Text;

                s.email = txtEmail.Text;

                s.street = txtStreet.Text;

                s.salary = Convert.ToInt32(txtSalary.Text);
                s.commune_id = cbCommune.Text;
                db.SubmitChanges();
                MessageBox.Show("Nhap thanh cong!");
            }
            else 
            { }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MyStaff();
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
        private void btCancel_Click(object sender, EventArgs e)
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
    }
}
