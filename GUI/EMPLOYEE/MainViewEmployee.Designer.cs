﻿namespace GUI
{
    partial class MainViewEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainViewEmployee));
            this.panelMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
<<<<<<< HEAD
            this.btnLichLam = new FontAwesome.Sharp.IconButton();
            this.iconButton6 = new FontAwesome.Sharp.IconButton();
=======
            this.iconButton4 = new FontAwesome.Sharp.IconButton();
>>>>>>> 64de7580e291ace885cd111372303e1c5a33b3ef
            this.lblHome = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.iconButton5 = new FontAwesome.Sharp.IconButton();
            this.lblName = new System.Windows.Forms.Label();
            this.iconcurrentChildHome = new FontAwesome.Sharp.IconPictureBox();
            this.panelShadow = new System.Windows.Forms.Panel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconcurrentChildHome)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panelMenu.Controls.Add(this.panel2);
            this.panelMenu.Controls.Add(this.iconButton1);
            this.panelMenu.Controls.Add(this.iconButton3);
            this.panelMenu.Controls.Add(this.btnLichLam);
            this.panelMenu.Controls.Add(this.iconButton6);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 736);
            this.panelMenu.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnHome);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(220, 140);
            this.panel2.TabIndex = 0;
            // 
            // btnHome
            // 
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(0, 3);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(220, 134);
            this.btnHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnHome.TabIndex = 0;
            this.btnHome.TabStop = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.UserEdit;
            this.iconButton1.IconColor = System.Drawing.Color.WhiteSmoke;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 30;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(0, 140);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(0);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.iconButton1.Size = new System.Drawing.Size(220, 59);
            this.iconButton1.TabIndex = 1;
            this.iconButton1.Text = "        Chỉnh sửa thông tin ";
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click_1);
            // 
            // iconButton3
            // 
            this.iconButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton3.FlatAppearance.BorderSize = 0;
            this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.ClockRotateLeft;
            this.iconButton3.IconColor = System.Drawing.Color.WhiteSmoke;
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton3.IconSize = 30;
            this.iconButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton3.Location = new System.Drawing.Point(0, 199);
            this.iconButton3.Margin = new System.Windows.Forms.Padding(0);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.iconButton3.Size = new System.Drawing.Size(220, 59);
            this.iconButton3.TabIndex = 3;
            this.iconButton3.Text = "         Quản lý đặt bàn ";
            this.iconButton3.UseVisualStyleBackColor = true;
            this.iconButton3.Click += new System.EventHandler(this.iconButton3_Click);
            // 
            // btnLichLam
            // 
            this.btnLichLam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLichLam.FlatAppearance.BorderSize = 0;
            this.btnLichLam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLichLam.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLichLam.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLichLam.IconChar = FontAwesome.Sharp.IconChar.CalendarWeek;
            this.btnLichLam.IconColor = System.Drawing.Color.WhiteSmoke;
            this.btnLichLam.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLichLam.IconSize = 30;
            this.btnLichLam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLichLam.Location = new System.Drawing.Point(0, 258);
            this.btnLichLam.Margin = new System.Windows.Forms.Padding(0);
            this.btnLichLam.Name = "btnLichLam";
            this.btnLichLam.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.btnLichLam.Size = new System.Drawing.Size(220, 59);
            this.btnLichLam.TabIndex = 4;
            this.btnLichLam.Text = "       Quản lý lịch làm";
            this.btnLichLam.UseVisualStyleBackColor = true;
            this.btnLichLam.Click += new System.EventHandler(this.iconButton4_Click);
            // 
            // iconButton6
            // 
            this.iconButton6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton6.FlatAppearance.BorderSize = 0;
            this.iconButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton6.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.iconButton6.IconChar = FontAwesome.Sharp.IconChar.ArrowRightFromFile;
            this.iconButton6.IconColor = System.Drawing.Color.WhiteSmoke;
            this.iconButton6.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton6.IconSize = 30;
            this.iconButton6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton6.Location = new System.Drawing.Point(0, 317);
            this.iconButton6.Margin = new System.Windows.Forms.Padding(0);
            this.iconButton6.Name = "iconButton6";
            this.iconButton6.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.iconButton6.Size = new System.Drawing.Size(220, 59);
            this.iconButton6.TabIndex = 5;
            this.iconButton6.Text = "       Đăng xuất";
            this.iconButton6.UseVisualStyleBackColor = true;
            this.iconButton6.Click += new System.EventHandler(this.iconButton6_Click);
            // 
            // lblHome
            // 
            this.lblHome.AutoSize = true;
            this.lblHome.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblHome.Location = new System.Drawing.Point(43, 21);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(67, 16);
            this.lblHome.TabIndex = 1;
            this.lblHome.Text = "Trang chủ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panel1.Controls.Add(this.iconButton5);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.lblHome);
            this.panel1.Controls.Add(this.iconcurrentChildHome);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(220, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1397, 53);
            this.panel1.TabIndex = 4;
            // 
            // iconButton5
            // 
            this.iconButton5.FlatAppearance.BorderSize = 0;
            this.iconButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton5.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton5.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.iconButton5.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            this.iconButton5.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.iconButton5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton5.IconSize = 38;
            this.iconButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton5.Location = new System.Drawing.Point(928, 8);
            this.iconButton5.Name = "iconButton5";
            this.iconButton5.Size = new System.Drawing.Size(214, 39);
            this.iconButton5.TabIndex = 4;
            this.iconButton5.Text = "Xin chào nhân viên,";
            this.iconButton5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton5.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblName.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.lblName.Location = new System.Drawing.Point(1136, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(2, 21);
            this.lblName.TabIndex = 3;
            // 
            // iconcurrentChildHome
            // 
            this.iconcurrentChildHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.iconcurrentChildHome.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.iconcurrentChildHome.IconChar = FontAwesome.Sharp.IconChar.House;
            this.iconcurrentChildHome.IconColor = System.Drawing.SystemColors.ActiveBorder;
            this.iconcurrentChildHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconcurrentChildHome.Location = new System.Drawing.Point(7, 13);
            this.iconcurrentChildHome.Name = "iconcurrentChildHome";
            this.iconcurrentChildHome.Size = new System.Drawing.Size(32, 32);
            this.iconcurrentChildHome.TabIndex = 0;
            this.iconcurrentChildHome.TabStop = false;
            // 
            // panelShadow
            // 
            this.panelShadow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(58)))));
            this.panelShadow.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelShadow.Location = new System.Drawing.Point(220, 53);
            this.panelShadow.Name = "panelShadow";
            this.panelShadow.Size = new System.Drawing.Size(1397, 9);
            this.panelShadow.TabIndex = 5;
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(220, 62);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(1397, 674);
            this.panelDesktop.TabIndex = 6;
            // 
            // lblHome
            // 
            this.lblHome.AutoSize = true;
            this.lblHome.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblHome.Location = new System.Drawing.Point(43, 21);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(67, 16);
            this.lblHome.TabIndex = 1;
            this.lblHome.Text = "Trang chủ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panel1.Controls.Add(this.iconButton5);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.lblHome);
            this.panel1.Controls.Add(this.iconcurrentChildHome);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(220, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1397, 53);
            this.panel1.TabIndex = 4;
            // 
            // iconButton5
            // 
            this.iconButton5.FlatAppearance.BorderSize = 0;
            this.iconButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton5.Font = new System.Drawing.Font("MS Reference Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton5.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.iconButton5.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            this.iconButton5.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.iconButton5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton5.IconSize = 38;
            this.iconButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton5.Location = new System.Drawing.Point(928, 8);
            this.iconButton5.Name = "iconButton5";
            this.iconButton5.Size = new System.Drawing.Size(214, 39);
            this.iconButton5.TabIndex = 4;
            this.iconButton5.Text = "Xin chào nhân viên ";
            this.iconButton5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton5.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblName.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.lblName.Location = new System.Drawing.Point(1136, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(2, 21);
            this.lblName.TabIndex = 3;
            // 
            // iconcurrentChildHome
            // 
            this.iconcurrentChildHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.iconcurrentChildHome.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.iconcurrentChildHome.IconChar = FontAwesome.Sharp.IconChar.House;
            this.iconcurrentChildHome.IconColor = System.Drawing.SystemColors.ActiveBorder;
            this.iconcurrentChildHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconcurrentChildHome.Location = new System.Drawing.Point(7, 13);
            this.iconcurrentChildHome.Name = "iconcurrentChildHome";
            this.iconcurrentChildHome.Size = new System.Drawing.Size(32, 32);
            this.iconcurrentChildHome.TabIndex = 0;
            this.iconcurrentChildHome.TabStop = false;
            // 
            // panelShadow
            // 
            this.panelShadow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(58)))));
            this.panelShadow.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelShadow.Location = new System.Drawing.Point(220, 53);
            this.panelShadow.Name = "panelShadow";
            this.panelShadow.Size = new System.Drawing.Size(1397, 9);
            this.panelShadow.TabIndex = 5;
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(220, 62);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(1397, 674);
            this.panelDesktop.TabIndex = 6;
            // 
            // MainViewEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1617, 736);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelShadow);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainViewEmployee";
            this.Text = "Màn hình chính";
            this.Load += new System.EventHandler(this.MainViewCustomer_Load);
            this.panelMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconcurrentChildHome)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel panelMenu;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton btnLichLam;
        private System.Windows.Forms.PictureBox btnHome;
        private FontAwesome.Sharp.IconPictureBox iconcurrentChildHome;
        private System.Windows.Forms.Label lblHome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelShadow;
        private System.Windows.Forms.Panel panelDesktop;
        private FontAwesome.Sharp.IconButton iconButton5;
        private System.Windows.Forms.Label lblName;
        private FontAwesome.Sharp.IconButton iconButton6;
    }
}