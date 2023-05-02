using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ProjectManagementPizza
{
    public partial class Piza : Form
    {
        public Piza()
        {
            InitializeComponent();
        }
        string connstr = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=QuanLiPizza;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        // Đối tượng kết nối
        SqlConnection conn = null;
        // Đối tượng đưa dữ liệu vào Data Table SqlStore
        SqlDataAdapter adStore = null;

        // Đối tượng hiển thị dữ liệu lên Form
        DataTable dtStore = null;

        bool add = false;
        void LoadData()
        {

            try
            {
                conn = new SqlConnection(connstr);
                adStore = new SqlDataAdapter("SELECT * FROM pizza", conn);
                dtStore = new DataTable();
                adStore.Fill(dtStore);
                dtGridView.DataSource = dtStore;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không kết nối lấy được dữ liệu từ bảng Store", "Lỗi dữ liệu!");
            }
        }
        private void loadDataCategoryId()
        {
            conn = new SqlConnection(connstr);
            adStore = new SqlDataAdapter("SELECT category_id FROM category", conn);
            dtStore = new DataTable();
            adStore.Fill(dtStore);

            foreach (DataRow row in dtStore.Rows)
            {
                int provName = row.Field<int>("category_id");
                cbCID.Items.Add(provName);
            }
            cbCID.SelectedIndex = 0;
        }
        private void loadDataWarehouseId()
        {
            conn = new SqlConnection(connstr);
            adStore = new SqlDataAdapter("SELECT warehouse_id FROM warehouse", conn);
            dtStore = new DataTable();
            adStore.Fill(dtStore);

            foreach (DataRow row in dtStore.Rows)
            {
                int provName = row.Field<int>("warehouse_id");
                cbWID.Items.Add(provName);
            }
            cbWID.SelectedIndex = 0;
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Piza_Load(object sender, EventArgs e)
        {
            LoadData();
            loadDataWarehouseId();
            loadDataCategoryId();
        }
    }
}
