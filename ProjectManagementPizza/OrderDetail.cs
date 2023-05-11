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
    public partial class OrderDetail : Form
    {
        public OrderDetail()
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
                adStore = new SqlDataAdapter("SELECT * FROM order_detail", conn);
                dtStore = new DataTable();
                adStore.Fill(dtStore);
                dtGridView.DataSource = dtStore;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không kết nối lấy được dữ liệu từ bảng Store", "Lỗi dữ liệu!");
            }
        }
        private void loadDataOrderId()
        {
            conn = new SqlConnection(connstr);
            adStore = new SqlDataAdapter("SELECT order_id FROM orders", conn);
            dtStore = new DataTable();
            adStore.Fill(dtStore);

            foreach (DataRow row in dtStore.Rows)
            {
                int provName = row.Field<int>("order_id");
                cbOID.Items.Add(provName);
            }
            cbOID.SelectedIndex = 0;
        }
        private void loadDataProductId()
        {
            conn = new SqlConnection(connstr);
            adStore = new SqlDataAdapter("SELECT product_id FROM product", conn);
            dtStore = new DataTable();
            adStore.Fill(dtStore);

            foreach (DataRow row in dtStore.Rows)
            {
                int provName = row.Field<int>("product_id");
                cbPID.Items.Add(provName);
            }
            cbPID.SelectedIndex = 0;
        }
        void CheckOrderDetailIDExit()
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
                cmd.CommandText = "SELECT Count(*) FROM order_detail WHERE order_detail_id = '" +
                txtQD.Text.Trim() + "'";
                int nCount;
                nCount = Int32.Parse(cmd.ExecuteScalar().ToString());
                if (nCount > 0)
                {
                    MessageBox.Show("OrderDetailID (" + txtQD.Text.Trim() + ") đã có. Nhậplại!");
                    txtQD.ResetText();
                    txtQD.Focus();
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
        private void OrderDetail_Load(object sender, EventArgs e)
        {
            LoadData();
            loadDataProductId();
            loadDataOrderId();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CheckOrderDetailIDExit();
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
                    cmd.CommandText = "INSERT INTO order_detail VALUES('" + txtQD.Text
                    + "','" + cbOID.Text + "','" + cbPID.Text + "','" + txtQ.Text + "','" + txtP.Text + "')";
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
                    MessageBox.Show("Id đã tồn tại");
                }
            }
        
        }

        private void cbPID_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT product_name FROM product WHERE product_id = @productId", conn);
            cmd.Parameters.AddWithValue("@productId", cbPID.Text);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                txtPN.Text = reader.GetString(0);
            }

            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

       

        private void button4_Click_1(object sender, EventArgs e)
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
                cmd.CommandText = "UPDATE order_detail SET " + "order_detail_id='" +
                txtQD.Text + "', order_id ='" + cbOID.Text + "' , product_id ='" + cbPID.Text + "', quantity ='" + txtQ.Text + "', unit_price ='" + txtP.Text + "' WHERE order_detail_id = '" + strStoreID + "'";
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
                MessageBox.Show("id đã tồn tại");// "Không sửa được. Lỗi rồi!");
                conn.Close();
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
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
                    cmd.CommandText = "DELETE FROM order_detail WHERE order_detail_id='" + StoreID +
                    "'";
                    cmd.CommandType = CommandType.Text;
                    // Thực hiện lệnh truy vấn
                    cmd.ExecuteNonQuery();
                    // Cập nhật lại dữ liệu trên DataGridView
                    LoadData();
                    // Thông báo
                    MessageBox.Show("Đã xóa thành công Order_Detail_ID =" + StoreID + ".");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không xóa được Order_Detail hiện hành.");
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void dtGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dtGridView.CurrentCell.RowIndex;
            string chuoi = "";
            // Chuyển thông tin từ Gridview lên các textbox ở panel
            txtQD.Text = dtGridView.Rows[r].Cells[0].Value.ToString();
            cbOID.Text = dtGridView.Rows[r].Cells[1].Value.ToString();
            cbPID.Text = dtGridView.Rows[r].Cells[2].Value.ToString();
            chuoi = dtGridView.Rows[r].Cells[4].Value.ToString();
            txtP.Text = chuoi.Replace(".00", "");
            txtQ.Text = dtGridView.Rows[r].Cells[3].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtQD.Text = "";
            txtQD.Focus();
            txtQ.Text = "";
            txtP.Text = "";
            LoadData();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) { this.Close(); return false; }
            else return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
