﻿namespace ProjectManagementPizza
{
    partial class LOSTPASSWORD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOSTPASSWORD));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMK = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btXacNhan = new System.Windows.Forms.Button();
            this.btHuyBo = new System.Windows.Forms.Button();
            this.txtcheck = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btsend = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCapcha = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 29);
            this.label2.TabIndex = 17;
            this.label2.Text = "Mật khẩu mới";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 29);
            this.label1.TabIndex = 16;
            this.label1.Text = "Tài Khoản";
            // 
            // txtMK
            // 
            this.txtMK.Location = new System.Drawing.Point(303, 181);
            this.txtMK.Name = "txtMK";
            this.txtMK.Size = new System.Drawing.Size(313, 22);
            this.txtMK.TabIndex = 15;
            this.txtMK.UseSystemPasswordChar = true;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(303, 111);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(313, 22);
            this.txtID.TabIndex = 14;
            // 
            // btXacNhan
            // 
            this.btXacNhan.Location = new System.Drawing.Point(167, 378);
            this.btXacNhan.Name = "btXacNhan";
            this.btXacNhan.Size = new System.Drawing.Size(130, 42);
            this.btXacNhan.TabIndex = 13;
            this.btXacNhan.Text = "Xác Nhận";
            this.btXacNhan.UseVisualStyleBackColor = true;
            this.btXacNhan.Click += new System.EventHandler(this.btXacNhan_Click);
            // 
            // btHuyBo
            // 
            this.btHuyBo.Location = new System.Drawing.Point(411, 378);
            this.btHuyBo.Name = "btHuyBo";
            this.btHuyBo.Size = new System.Drawing.Size(117, 42);
            this.btHuyBo.TabIndex = 12;
            this.btHuyBo.Text = "Hủy bỏ";
            this.btHuyBo.UseVisualStyleBackColor = true;
            this.btHuyBo.Click += new System.EventHandler(this.btHuyBo_Click);
            // 
            // txtcheck
            // 
            this.txtcheck.Location = new System.Drawing.Point(303, 235);
            this.txtcheck.Name = "txtcheck";
            this.txtcheck.Size = new System.Drawing.Size(313, 22);
            this.txtcheck.TabIndex = 18;
            this.txtcheck.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 29);
            this.label3.TabIndex = 19;
            this.label3.Text = "Xác nhận mật khẩu";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btsend);
            this.panel1.Controls.Add(this.btHuyBo);
            this.panel1.Controls.Add(this.btXacNhan);
            this.panel1.Controls.Add(this.txtMK);
            this.panel1.Controls.Add(this.txtcheck);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtCapcha);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(72, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(711, 478);
            this.panel1.TabIndex = 22;
            // 
            // btsend
            // 
            this.btsend.Location = new System.Drawing.Point(556, 298);
            this.btsend.Name = "btsend";
            this.btsend.Size = new System.Drawing.Size(60, 37);
            this.btsend.TabIndex = 24;
            this.btsend.Text = "Send";
            this.btsend.UseVisualStyleBackColor = true;
            this.btsend.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(35, 298);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 29);
            this.label5.TabIndex = 23;
            this.label5.Text = "Code check:";
            // 
            // txtCapcha
            // 
            this.txtCapcha.Location = new System.Drawing.Point(303, 305);
            this.txtCapcha.Name = "txtCapcha";
            this.txtCapcha.Size = new System.Drawing.Size(225, 22);
            this.txtCapcha.TabIndex = 22;
            this.txtCapcha.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(92, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(553, 46);
            this.label4.TabIndex = 25;
            this.label4.Text = "CREATE NEW PASSWORD";
            // 
            // LOSTPASSWORD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Maroon;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(875, 605);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LOSTPASSWORD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOSTPASSWORD";
            this.Load += new System.EventHandler(this.LOSTPASSWORD_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMK;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btXacNhan;
        private System.Windows.Forms.Button btHuyBo;
        private System.Windows.Forms.TextBox txtcheck;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btsend;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCapcha;
        private System.Windows.Forms.Label label4;
    }
}