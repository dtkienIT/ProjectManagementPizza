
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
            this.myProgBar = new MyUserControls.MyProgressBar();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // myProgBar
            // 
            this.myProgBar.Location = new System.Drawing.Point(45, 12);
            this.myProgBar.Maximum = 100;
            this.myProgBar.Name = "myProgBar";
            this.myProgBar.Size = new System.Drawing.Size(600, 277);
            this.myProgBar.Step = 10;
            this.myProgBar.TabIndex = 0;
            this.myProgBar.Value = 0;
            this.myProgBar.Load += new System.EventHandler(this.myProgBar_Load);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(196, 280);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 40);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(367, 280);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 40);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(534, 280);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 40);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MyProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.myProgBar);
            this.Name = "MyProgressBar";
            this.Text = "MyProgressBar";
            this.Load += new System.EventHandler(this.MyProgressBar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MyUserControls.MyProgressBar myProgBar;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Timer timer1;
    }
}