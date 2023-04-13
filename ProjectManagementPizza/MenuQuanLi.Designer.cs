namespace ProjectManagementPizza
{
    partial class MenuQuanLi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuQuanLi));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returnToLoginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createStaffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createDataToolStripMenuItem,
            this.returnToLoginToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(901, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // returnToLoginToolStripMenuItem
            // 
            this.returnToLoginToolStripMenuItem.Name = "returnToLoginToolStripMenuItem";
            this.returnToLoginToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.returnToLoginToolStripMenuItem.Text = "Return to Login";
            this.returnToLoginToolStripMenuItem.Click += new System.EventHandler(this.returnToLoginToolStripMenuItem_Click);
            // 
            // createDataToolStripMenuItem
            // 
            this.createDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createStaffToolStripMenuItem});
            this.createDataToolStripMenuItem.Name = "createDataToolStripMenuItem";
            this.createDataToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.createDataToolStripMenuItem.Text = "Create Data";
            // 
            // createStaffToolStripMenuItem
            // 
            this.createStaffToolStripMenuItem.Name = "createStaffToolStripMenuItem";
            this.createStaffToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.createStaffToolStripMenuItem.Text = "Create Staff";
            this.createStaffToolStripMenuItem.Click += new System.EventHandler(this.createStaffToolStripMenuItem_Click);
            // 
            // MenuQuanLi
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(901, 543);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenuQuanLi";
            this.Text = "MenuQuanLi";
            this.Load += new System.EventHandler(this.MenuQuanLi_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem returnToLoginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem createDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createStaffToolStripMenuItem;
    }
}