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
using System.IO;

namespace ProjectManagementPizza
{
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }
        PizzaDataContext db = null;
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Thiết lập các thuộc tính cho đối tượng OpenFileDialog
            openFileDialog.Title = "Chọn hình ảnh";
            openFileDialog.Filter = "JPEG files (*.jpg)|*.jpg|PNG files (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;

            // Nếu người dùng chọn OK trong hộp thoại OpenFileDialog
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn đến file hình ảnh
                string imagePath = openFileDialog.FileName;

                // Hiển thị hình ảnh trong PictureBox
                pictureBox.Image = Image.FromFile(imagePath);
            }
        }

        private void Product_Load(object sender, EventArgs e)
        {
            MySetProductInDataGridView();

        }
        private void MySetProductInDataGridView()
        {
            db = new PizzaDataContext();

            var product = from p in db.products select p;
            dtGridView.DataSource = product.ToList();


            // Thêm cột hình ảnh vào DataGridView
            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol.HeaderText = "Image";
            imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom; // tùy chỉnh để hình ảnh hiển thị đầy đủ trong ô
            dtGridView.Columns.Add(imgCol);
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
        // Phương thức chuyển đổi hình ảnh thành mảng byte
        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool checkStatus = false;
            if (radioButton1.Checked == true)
            {
                checkStatus = true;
            }
            if (radioButton2.Checked == true)
            {
                checkStatus = false;
            }


            db.products.InsertOnSubmit(new product
            {
                
                product_name = txtPN.Text,
                unit_price = int.Parse(txtP.Text),
                description = txtD.Text,
                image = ImageToByteArray(pictureBox.Image), // chuyển đổi hình ảnh thành mảng byte
            status = checkStatus
            });
            db.SubmitChanges();
            MySetProductInDataGridView();
            MessageBox.Show("Thêm thành công!", "Thông báo");
        }
        

            // Sự kiện CellFormatting để hiển thị hình ảnh từ dữ liệu kiểu byte
            private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtGridView.Columns[e.ColumnIndex].Name == "image" && e.Value != null)
            {
                byte[] imageData = (byte[])e.Value;
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    e.Value = Image.FromStream(ms);
                }
            }
        }
    }
}
