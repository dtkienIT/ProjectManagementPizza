using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
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
        private static readonly string _from = "sasukeholy@gmail.com";
        private static readonly string _pass = "stbutlhdnwqtvoqn";
        private static int _r = 0;
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
            string cachecode = Convert.ToString(_r);
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
                if (txtCapcha.Text == cachecode)
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
                else 
                {
                    MessageBox.Show("Sai mã cache rồi!");
                    txtCapcha.ResetText();
                    txtCapcha.Focus();
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
        private void random()
        {
            Random b = new Random();
            int a = b.Next(1000, 10000);
            _r = a;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }

            conn.Open();
            try
            {
                string z = "SELECT email FROM login WHERE username= @tk";
                SqlCommand cmd = new SqlCommand(z);
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@tk", txtID.Text);
                SqlDataReader takemail = cmd.ExecuteReader();
                string sendto = "";
                if (takemail.Read())
                {
                    string email = takemail.GetString(0);
                    sendto = email;
                    // sử dụng biến "sendto" để gửi email đến địa chỉ email lấy được từ cơ sở dữ liệu
                }
                takemail.Close();
                random();
                string subject = "Xin chao " + txtID.Text;
                string content = "ma xac nhan cua ban la: " + _r;
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress(_from, "Pizza Company");
                    mail.To.Add(sendto);
                    mail.Subject = subject;
                    mail.IsBodyHtml = true;
                    mail.Body = content;

                    mail.Priority = MailPriority.High;

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential(_from, _pass);
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                    MessageBox.Show("Code has sent to your email");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Khong the ket noi voi du lieu SQL");
            }
            conn.Close();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) { this.Close(); return false; }
            else if (keyData == Keys.Enter) { btXacNhan.PerformClick(); return false; }
            else return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
