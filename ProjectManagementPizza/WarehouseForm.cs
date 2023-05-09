using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagementPizza
{
    public partial class WarehouseForm : Form
    {
        public WarehouseForm()
        {
            InitializeComponent();
        }
        string consstr = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=QuanliPizza;Integrated Security=True;Pooling=False";
        SqlConnection conn = null;
        DataTable accountt = null;
        SqlDataAdapter accouter = null;

        private void ResetTextAll()
        {
            txtWID.ResetText();
            txtWname.ResetText();
            txtStreet.ResetText();
        }

        void LoadData()
        {
            try
            {
                conn = new SqlConnection(consstr);
                conn.Open();
                accouter = new SqlDataAdapter("SELECT * FROM warehouse", conn);
                accountt = new DataTable();
                accouter.Fill(accountt);
                dataGridView1.DataSource = accountt;

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được dữ liệu", "Lỗi dữ liệu!");
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) { this.Close(); return false; }
            else if (keyData == Keys.Enter) { btAdd.PerformClick(); return false; }
            else return base.ProcessCmdKey(ref msg, keyData);
        }
        void LoadDataComm()
        {
            try
            {
                conn = new SqlConnection(consstr);
                conn.Open();
                accouter = new SqlDataAdapter("SELECT commune_id FROM commune", conn);
                accountt = new DataTable();
                accouter.Fill(accountt);
                dataGridView1.DataSource = accountt;
                foreach (DataRow row in accountt.Rows)
                {
                    cbCID.Items.Add(row["commune_id"]);
                }
                cbCID.SelectedIndex = 0;

            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được dữ liệu", "Lỗi dữ liệu!");
            }
        }
        private void btReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuQuanLi z = new MenuQuanLi();
            z.ShowDialog();
            this.Close();
        }

        private void WarehouseForm_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadDataComm();
        }

        private void btReload_Click(object sender, EventArgs e)
        {
            cbCID.Items.Clear();
            LoadDataComm();
            LoadData();
            ResetTextAll();
        }

        private void cbCID_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            LoadData();
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }


            SqlCommand cmd = new SqlCommand();

            try
            { // Thực hiện lệnh
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                // Lệnh Insert InTo
                cmd.CommandText = "INSERT INTO warehouse (warehouse_id, warehouse_name, street, commune_id) VALUES ( @DID, @DName, @Street,@CID)";


                cmd.Parameters.AddWithValue("@DID", txtWID.Text);
                cmd.Parameters.AddWithValue("@DName", txtWname.Text);
                cmd.Parameters.AddWithValue("@Street", txtStreet.Text);
                cmd.Parameters.AddWithValue("@CID", cbCID.Text);

                cmd.ExecuteNonQuery();
                // Thông báo
                LoadData();
                MessageBox.Show("Đã Thêm Nhãn Hiệu thành công!!!");
            }
            catch (SqlException)
            {
                MessageBox.Show("TNhãn hiệu đã tồn tại!!!"); ResetTextAll();
            }
            finally
            {
                conn.Close();
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            dataGridView1_CellContentClick(null, null);

            txtWID.Focus();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            ResetTextAll();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dataGridView1.CurrentCell.RowIndex;
            // Chuyển thông tin từ Gridview lên các textbox ở panel
            txtWID.Text = dataGridView1.Rows[r].Cells[0].Value.ToString();
            txtWname.Text = dataGridView1.Rows[r].Cells[1].Value.ToString();
            txtStreet.Text = dataGridView1.Rows[r].Cells[2].Value.ToString();
            cbCID.Text = dataGridView1.Rows[r].Cells[3].Value.ToString();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            LoadData();
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = conn;

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "UPDATE warehouse SET  warehouse_name= @warehouse_name, street= @street WHERE warehouse_id = @warehouse_id";

                cmd.Parameters.AddWithValue("@warehouse_id", txtWID.Text);
                cmd.Parameters.AddWithValue("@warehouse_name", txtWname.Text);
                cmd.Parameters.AddWithValue("@street", txtStreet.Text);

                cmd.ExecuteNonQuery();
                LoadData();
                MessageBox.Show("Đã sửa xong!");

                ResetTextAll();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi sửa kho hàng: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {

            DialogResult CheckYN;
            CheckYN = MessageBox.Show("Có chắc xóa không?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (CheckYN == DialogResult.Yes)
            {
                // Mở kết nối
                LoadData();
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    cmd.CommandType = CommandType.Text;
                    // Lấy Row hiện tại
                    int r = dataGridView1.CurrentCell.RowIndex;

                    // Store_ID của record hiện hành

                    string StoreID = dataGridView1.Rows[r].Cells[0].Value.ToString();

                    // Lệnh truy vấn SQL

                    cmd.CommandText = "DELETE FROM warehouse WHERE warehouse_id='" + StoreID +

                    "'";

                    cmd.CommandType = CommandType.Text;
                    // Thực hiện lệnh truy vấn
                    cmd.ExecuteNonQuery();

                    // Cập nhật lại dữ liệu trên DataGridView

                    LoadData();
                    // Thông báo
                    MessageBox.Show("Đã xóa thành công warehouse id =" + StoreID + ".");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Không xóa được Store hiện hành.");

                    MessageBox.Show("Lỗi SQL: " + ex.Number + ". " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
