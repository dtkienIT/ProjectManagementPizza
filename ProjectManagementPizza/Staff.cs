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

        }

        private void btCancel_Click_1(object sender, EventArgs e)
        {

        }

        private void btDelete_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btSave_Click_1(object sender, EventArgs e)
        {

        }

        private void btReturn_Click(object sender, EventArgs e)
        {

        }

        private void btEdit_Click_1(object sender, EventArgs e)
        {

        }
    }
}
