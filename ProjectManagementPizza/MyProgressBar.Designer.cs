
namespace ProjectManagementPizza
{
    partial class MyProgressBar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyProgressBar));
            this.myProgBar = new MyUserControls.MyProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // myProgBar
            // 
            this.myProgBar.BackColor = System.Drawing.Color.Transparent;
            this.myProgBar.Location = new System.Drawing.Point(105, 84);
            this.myProgBar.Maximum = 100;
            this.myProgBar.Name = "myProgBar";
            this.myProgBar.Size = new System.Drawing.Size(600, 277);
            this.myProgBar.Step = 10;
            this.myProgBar.TabIndex = 0;
            this.myProgBar.Value = 0;
            this.myProgBar.Load += new System.EventHandler(this.myProgBar_Load);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MyProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(797, 450);
            this.Controls.Add(this.myProgBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MyProgressBar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyProgressBar";
            this.Load += new System.EventHandler(this.MyProgressBar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MyUserControls.MyProgressBar myProgBar;
        private System.Windows.Forms.Timer timer1;
    }
}