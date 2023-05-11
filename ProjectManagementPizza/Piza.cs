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
        void CheckPizzaIDExit()
        {
            // Mở kết nối
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            try
            {
                // Thực hiện lệnh
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                // Lệnh kiem tra thanh pho ton tai ?
                cmd.CommandText = "SELECT Count(*) FROM pizza WHERE pizza_id = '" +
                txtPID.Text.Trim() + "'";
                int nCount;
                nCount = Int32.Parse(cmd.ExecuteScalar().ToString());
                if (nCount > 0)
                {
                    MessageBox.Show("PizzaID (" + txtPID.Text.Trim() + ") đã có. Nhậplại!");
                    txtPID.ResetText();
                    txtPID.Focus();
                }
                else
                {
                    add = true;
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi truy vấn dữ liệu!");
            }

            finally
            {
                conn.Close();
            }
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CheckPizzaIDExit();
            if (add == true)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                try
                {
                    // Thực hiện lệnh
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    // Lệnh Insert InTo
                    cmd.CommandText = "INSERT INTO pizza VALUES('" + txtPID.Text
                    + "','" + txtPN.Text + "','" + txtD.Text + "','" + txtPS.Text + "','" + txtPM.Text + "','" + txtPL.Text + "','" + cbCID.Text + "','" + cbWID.Text + "')";
                    cmd.ExecuteNonQuery();
                    // Load lại dữ liệu trên DataGridView
                    LoadData();
                    // Thông báo
                    MessageBox.Show("Đã thêm dữ liệu thành công!");
                    conn.Close();
                    add = false;
                }
                catch (SqlException)
                {
                    MessageBox.Show(cmd.CommandText);
                }
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) { this.Close(); return false; }
            else return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                // Thứ tự dòng hiện hành
                int r = dtGridView.CurrentCell.RowIndex;// MaKH hiện hành
                string strStoreID =
                dtGridView.Rows[r].Cells[0].Value.ToString();
                // Câu lệnh SQL
                cmd.CommandText = "UPDATE pizza SET " + "pizza_id='" +
                txtPID.Text + "', pizza_name ='" + txtPN.Text + "' ,pizza_description ='" + txtD.Text + "', price_small ='" + txtPS.Text + "', price_medium ='" + txtPM.Text + "' ,price_large ='" + txtPL.Text+ "' ,category_id ='" + cbCID.Text+ "' ,warehouse_id ='" + cbWID.Text+ "' WHERE pizza_id = '" + strStoreID + "'";
                // Cập nhật
                cmd.ExecuteNonQuery();
                // Load lại dữ liệu trên DataGridView
                LoadData();
                // Thông báo
                MessageBox.Show("Đã sửa xong!");
                conn.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Id đã tồn tại!");// "Không sửa được. Lỗi rồi!");
                conn.Close();
            }
        }

        private void dtGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dtGridView.CurrentCell.RowIndex;
            
            // Chuyển thông tin từ Gridview lên các textbox ở panel
            txtPID.Text = dtGridView.Rows[r].Cells[0].Value.ToString();
            txtPN.Text = dtGridView.Rows[r].Cells[1].Value.ToString();
            txtD.Text = dtGridView.Rows[r].Cells[2].Value.ToString();
            string chuoi1 = dtGridView.Rows[r].Cells[3].Value.ToString();
            string chuoi2 = dtGridView.Rows[r].Cells[4].Value.ToString();
            string chuoi3 = dtGridView.Rows[r].Cells[5].Value.ToString();
            txtPS.Text = chuoi1.Replace(".00", "");
            txtPM.Text = chuoi2.Replace(".00", "");
            txtPL.Text = chuoi3.Replace(".00", "");
            cbCID.Text = dtGridView.Rows[r].Cells[6].Value.ToString();
            cbWID.Text = dtGridView.Rows[r].Cells[7].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra User có muốn xóa hàng dữ liệu
            DialogResult CheckYN;
            CheckYN = MessageBox.Show("Có chắc xóa không?", "Trảlời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (CheckYN == DialogResult.Yes)
            {
                // Mở kết nối
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    // Lấy Row hiện tại
                    int r = dtGridView.CurrentCell.RowIndex;
                    // Store_ID của record hiện hành
                    string StoreID = dtGridView.Rows[r].Cells[0].Value.ToString();
                    // Lệnh truy vấn SQL
                    cmd.CommandText = "DELETE FROM pizza WHERE pizza_id='" + StoreID +
                    "'";
                    cmd.CommandType = CommandType.Text;
                    // Thực hiện lệnh truy vấn
                    cmd.ExecuteNonQuery();
                    // Cập nhật lại dữ liệu trên DataGridView
                    LoadData();
                    // Thông báo
                    MessageBox.Show("Đã xóa thành công pizza_ID =" + StoreID + ".");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không xóa được pizza hiện hành.");
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtPID.Text = "";
            txtPN.Text = "";
            txtD.Text = "";
            txtPS.Text = "";
            txtPM.Text = "";
            txtPL.Text = "";
        }
    }
}
