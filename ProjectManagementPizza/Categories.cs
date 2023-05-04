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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectManagementPizza
{
    public partial class Categories : Form
    {
        public Categories()
        {
            InitializeComponent();
        }
        string consstr = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=QuanliPizza;Integrated Security=True;Pooling=False";
        SqlConnection conn = null;
        DataTable accountt = null;
        SqlDataAdapter accouter = null;

        void LoadData()
        {
            try
            {
                conn = new SqlConnection(consstr);
                conn.Open();
                accouter = new SqlDataAdapter("SELECT * FROM category", conn);
                accountt = new DataTable();
                accouter.Fill(accountt);
                dtGridView.DataSource = accountt;
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được dữ liệu", "Lỗi dữ liệu!");
            }
        }
        private void Resettext()
        {
            txtCID.ResetText();
            txtCName.ResetText();  
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            LoadData();
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }


            SqlCommand cmd = new SqlCommand();
            int a;
            bool check =int.TryParse(txtCID.Text, out a);
            if (check)
            {
                try
                { // Thực hiện lệnh
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    // Lệnh Insert InTo
                    cmd.CommandText = "INSERT INTO category (category_id,category_name) VALUES ( @category_id,@category_name)";

                    // Tham số 

                    cmd.Parameters.AddWithValue("@category_id", txtCID.Text);
                    cmd.Parameters.AddWithValue("@category_name", txtCName.Text);
                    cmd.ExecuteNonQuery();
                    // Thông báo
                    LoadData();
                    MessageBox.Show("Đã Thêm Nhãn Hiệu thành công!!!");
                    Resettext();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Nhãn đã tồn tại!!!");
                }
                finally
                {
                    conn.Close();
                }
            }
            else { MessageBox.Show("nhap id khong hop le!"); }
        }

        private void btReload_Click(object sender, EventArgs e)
        {
            LoadData();
            Resettext();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dtGridView_CellContentClick(null, null);
            txtCName.Focus();
        }

        private void dtGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int r = dtGridView.CurrentCell.RowIndex;
            // Chuyển thông tin từ Gridview lên các textbox ở panel
            txtCID.Text = dtGridView.Rows[r].Cells[0].Value.ToString();
            txtCName.Text = dtGridView.Rows[r].Cells[1].Value.ToString();
        }

        private void txtDelete_Click(object sender, EventArgs e)
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


                    // Store_ID của record hiện hành



                    // Lệnh truy vấn SQL

                    cmd.CommandText = "DELETE FROM category WHERE category_name='" + txtCName.Text +

                    "'";

                    cmd.CommandType = CommandType.Text;
                    // Thực hiện lệnh truy vấn
                    cmd.ExecuteNonQuery();

                    // Cập nhật lại dữ liệu trên DataGridView

                    LoadData();
                    // Thông báo
                    MessageBox.Show("Đã xóa thành công categories name =" + txtCName.Text + ".");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không xóa được Store hiện hành.");
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            int a;
            bool check = int.TryParse(txtCID.Text, out a);
            if (check)
            {
                try
                {
                    conn = new SqlConnection(consstr);
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    conn.Open();
                    int r = dtGridView.CurrentCell.RowIndex;

                    // Store_ID của record hiện hành

                    string StoreID = dtGridView.Rows[r].Cells[0].Value.ToString();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE category SET category_name = @cate_name WHERE category_id = @cate_id";

                    cmd.Parameters.AddWithValue("@cate_name", txtCName.Text);

                    cmd.Parameters.AddWithValue("@cate_id", StoreID);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Đã thêm dữ liệu thành công!");

                    LoadData();
                    Resettext();
                    conn.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi SQL: " + ex.Number + ". " + ex.Message);
                }
            }
            else { MessageBox.Show("ID khong hop le! "); }
        }

        private void txtreturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuQuanLi r = new MenuQuanLi();
            r.ShowDialog();
            this.Close();
        }
    }
}
