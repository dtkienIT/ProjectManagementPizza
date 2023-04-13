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
namespace ProjectManagementPizza
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }
        PizzaDataContext db = null;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) { this.Close(); return false; }
            else return base.ProcessCmdKey(ref msg, keyData);
        }
        private void btLogin_Click(object sender, EventArgs e)
        {
            using (db = new PizzaDataContext())
            {
                // Kiểm tra xem tài khoản đăng nhập có tồn tại trong CSDL không
                var user = (from u in db.logins
                            where u.username == txtAccount.Text.Trim() && u.password == txtPassword.Text.Trim()
                            select u).SingleOrDefault();

                if (user != null)
                {
                    // Tài khoản đăng nhập hợp lệ, tiếp tục xử lý đăng nhập ở đây
                   
                        Form ap = new Form1();
                        ap.Show();
                        this.Hide();
                  
                }
                else
                {
                    // Tài khoản đăng nhập không hợp lệ, hiển thị thông báo lỗi cho người dùng
                    MessageBox.Show("Tài khoản đăng nhập hoặc mật khẩu không hợp lệ!");

                }
            }
        }
    }
}
