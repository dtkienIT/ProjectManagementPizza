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
using System.Text.RegularExpressions;
namespace ProjectManagementPizza
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }
        PizzaDataContext db = null;
        private void MySetProvince()
        {
            db = new PizzaDataContext();
            var ProvQ = from ProvList in db.provinces select ProvList.province_name;
            foreach (string ProvName in ProvQ)
            {
                cbProv.Items.Add(ProvName);
            }
            cbProv.SelectedIndex = 0;

        }
        private void MySetDistrict()
        {
            string selectedProvince = cbProv.Text;
            var DistQ = from DistList in db.districts
                        join ProvList in db.provinces on DistList.province_id equals ProvList.province_id
                        where ProvList.province_name == selectedProvince
                        select DistList.district_name;

            cbDis.Items.Clear();
            foreach (string DistrictName in DistQ)
            {
                cbDis.Items.Add(DistrictName);
            }
            if (cbDis.Items.Count > 0)
            {
                cbDis.SelectedIndex = 0;
            }
        }
        private void MySetCommune()
        {
            var ComQ = from CommuneName in db.communes
                       join DisList in db.districts on CommuneName.district_id equals

                       DisList.district_id

                       where (DisList.district_name == cbDis.Text)

                       select CommuneName.commune_name;
            cbCom.Items.Clear();
            foreach (string CommuneName in ComQ)
            {
                cbCom.Items.Add(CommuneName);
            }
            if (cbCom.Items.Count > 0)
            {
                cbCom.SelectedIndex = 0;
            }


        }
        private void MySetCustomerInDataGridView()
        {
            db = new PizzaDataContext();

            var customer = from p in db.customers select p;
            dtGridView.DataSource = customer.ToList();
            quantityCusCurrent();
        }
        private void quantityCusCurrent()
        {
            db = new PizzaDataContext();
            int quantityCusCurrent = db.customers.Count();
            lblQuantity.Text = quantityCusCurrent.ToString();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Customer_Load(object sender, EventArgs e)
        {
            MySetProvince();
            MySetCustomerInDataGridView();


            List<string> searchOptions = new List<string> { "Customer Name","Phone", "Email" };
            cbSearch.Items.AddRange(searchOptions.ToArray());


        }

        private void cbProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySetDistrict();
        }

        private void cbDis_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySetCommune();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string selectedCommuneName = cbCom.Text;
            var selectedCommuneId = db.communes
                                            .Where(c => c.commune_name == selectedCommuneName)
                                            .Select(c => c.commune_id)
                                            .FirstOrDefault();
            if (isEmail(txtE.Text))
            {
                db.customers.InsertOnSubmit(new customer
                {
                    customer_id = int.Parse(txtCusId.Text),
                    customer_name = txtCusN.Text,
                    phone_number = txtP.Text,
                    email = txtE.Text,
                    street = txtS.Text,
                    commune_id = selectedCommuneId
                });
                db.SubmitChanges();
                MySetCustomerInDataGridView();
                MessageBox.Show("Thêm thành công!", "Thông báo");
            }
            else
            {
                MessageBox.Show("Email phải hợp lệ!");
            }
        }






        public static bool isEmail(string inputEmail)
        {
            inputEmail = inputEmail ?? string.Empty;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) { this.Close(); return false; }
            else return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dtGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int r = dtGridView.CurrentCell.RowIndex;
            // Chuyển thông tin từ Gridview lên các textbox ở panel
            txtCusId.Text = dtGridView.Rows[r].Cells[0].Value.ToString();
            txtCusN.Text = dtGridView.Rows[r].Cells[1].Value.ToString();
            txtP.Text = dtGridView.Rows[r].Cells[2].Value.ToString();
            txtE.Text = dtGridView.Rows[r].Cells[3].Value.ToString();
            txtS.Text = dtGridView.Rows[r].Cells[4].Value.ToString();

            string selectedCommuneId = dtGridView.Rows[r].Cells[5].Value.ToString();
            var selectedCommuneName = db.communes
                                            .Where(c => c.commune_id == selectedCommuneId)
                                            .Select(c => c.commune_name)
                                            .FirstOrDefault();
            cbCom.Text = selectedCommuneName;



            
        }
        private void cbCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int r = dtGridView.CurrentCell.RowIndex;
            int tempDID = int.Parse(dtGridView.Rows[r].Cells[0].Value.ToString());
            string selectedCommuneName = cbCom.Text;
            var selectedCommuneId = db.communes
                                            .Where(c => c.commune_name == selectedCommuneName)
                                            .Select(c => c.commune_id)
                                            .FirstOrDefault();
            if (isEmail(txtE.Text))
            {
                customer DistQ = db.customers.Single(x => x.customer_id == tempDID);
                DistQ.customer_id = int.Parse(txtCusId.Text);
                DistQ.customer_name = txtCusN.Text;
                DistQ.phone_number = txtP.Text;
                DistQ.email = txtE.Text;
                DistQ.street = txtS.Text;
                DistQ.commune_id = selectedCommuneId;
               
                db.SubmitChanges();
                MySetCustomerInDataGridView();
                MessageBox.Show("Sửa thành công!", "Thông báo");
            }
            else
            {
                MessageBox.Show("Email phải hợp lệ!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dtGridView.CurrentCell.RowIndex;
                int tempDID = int.Parse(dtGridView.Rows[r].Cells[0].Value.ToString());
                customer DistQ = db.customers.Single(x => x.customer_id == tempDID);
                db.customers.DeleteOnSubmit(DistQ);
                db.SubmitChanges();
                MySetCustomerInDataGridView();
                MessageBox.Show("Xóa thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtCusId.Focus();
            txtCusId.Text = "";
            txtCusN.Text = "";
            txtE.Text = "";
            txtP.Text = "";
            txtS.Text = "";
            cbSearch.Text = "";
            txtSearch.Text = "";
            MySetCustomerInDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchField = cbSearch.SelectedItem.ToString();
            string searchTerm = txtSearch.Text;

           
                var query = db.customers.Where(c =>
                             searchField == "Customer Name" ? c.customer_name.StartsWith(searchTerm) :
                             searchField == "Phone" ? c.phone_number.StartsWith(searchTerm) :
                             searchField == "Email" ? c.email.StartsWith(searchTerm) :
                             false).ToList();

                dtGridView.DataSource = query;
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

        
}
