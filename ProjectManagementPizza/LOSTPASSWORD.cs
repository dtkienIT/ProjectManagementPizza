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
    public partial class LOSTPASSWORD : Form
    {
        public LOSTPASSWORD()
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
                accouter = new SqlDataAdapter("SELECT * FROM login", conn);
                accountt = new DataTable();
                accouter.Fill(accountt);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được dữ liệu", "Lỗi dữ liệu!");
            }
        }
        void SetbtOn()
        {
            return;
            btXacNhan.Enabled = true;
        }
        private bool Checktk()
        {

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
                cmd.CommandText = "SELECT Count(*) FROM login WHERE username = @tk";
                cmd.Parameters.AddWithValue("@tk", txtID.Text.Trim());
                int nCount;
                nCount = Int32.Parse(cmd.ExecuteScalar().ToString());
                if (nCount > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi truy vấn dữ liệu!");
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        private void btXacNhan_Click(object sender, EventArgs e)
        {
            LoadData();
            LogIn r = new LogIn();
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            SetbtOn();
            if (txtcheck.Text == txtMK.Text)
            {
                try
                { // Thực hiện lệnh



                    string z = "UPDATE login SET password=@mk WHERE username= @tk";
                    SqlCommand cmd = new SqlCommand(z);
                    cmd.Connection = conn;
                    // Tham số @tk và @mk
                    cmd.Parameters.AddWithValue("@tk", txtID.Text);
                    cmd.Parameters.AddWithValue("@mk", txtMK.Text);

                    cmd.ExecuteNonQuery();
                    // Thông báo
                    int check = Int32.Parse(cmd.ExecuteNonQuery().ToString());
                    if (check > 0)
                    {
                        MessageBox.Show("Đổi Tài Khoản thành công!");
                        this.Hide();
                        r.ShowDialog();
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Tai khoan khong ton tai!");
                    }
                }
                catch (SqlException)
                {
                    MessageBox.Show("KHONG TON TAI!!!"); txtID.Focus();
                }
            }
            else
            {
                MessageBox.Show("Xác nhận mật khẩu không khớp, mời nhập lại!");
                txtcheck.ResetText();
                txtcheck.Focus();
            }
            conn.Close();
        }

        private void btHuyBo_Click(object sender, EventArgs e)
        {
            this.Hide();
            LogIn z= new LogIn();
            z.ShowDialog();
            this.Close();
        }
    }
}
