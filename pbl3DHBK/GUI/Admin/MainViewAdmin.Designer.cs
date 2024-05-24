namespace GUI
{
    partial class MainViewAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainViewAdmin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.menuContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTaiKhoan = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.pnThongKe = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.pnThucDon = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThucDon = new System.Windows.Forms.Button();
            this.pnNguyenLieu = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNguyenLieu = new System.Windows.Forms.Button();
            this.pnDangXuat = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.menuTransition = new System.Windows.Forms.Timer(this.components);
            this.sidebarTransition = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.sidebar.SuspendLayout();
            this.menuContainer.SuspendLayout();
            this.pnThongKe.SuspendLayout();
            this.pnThucDon.SuspendLayout();
            this.pnNguyenLieu.SuspendLayout();
            this.pnDangXuat.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1617, 39);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GUI.Properties.Resources.icons8_menu_50;
            this.pictureBox1.Location = new System.Drawing.Point(3, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.sidebar.Controls.Add(this.menuContainer);
            this.sidebar.Controls.Add(this.pnThongKe);
            this.sidebar.Controls.Add(this.pnNguyenLieu);
            this.sidebar.Controls.Add(this.pnThucDon);
            this.sidebar.Controls.Add(this.pnDangXuat);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 39);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(244, 697);
            this.sidebar.TabIndex = 1;
            // 
            // menuContainer
            // 
            this.menuContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.menuContainer.Controls.Add(this.btnTaiKhoan);
            this.menuContainer.Controls.Add(this.button2);
            this.menuContainer.Controls.Add(this.button7);
            this.menuContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.menuContainer.Location = new System.Drawing.Point(3, 3);
            this.menuContainer.Name = "menuContainer";
            this.menuContainer.Size = new System.Drawing.Size(241, 75);
            this.menuContainer.TabIndex = 7;
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.btnTaiKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTaiKhoan.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiKhoan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTaiKhoan.Image = ((System.Drawing.Image)(resources.GetObject("btnTaiKhoan.Image")));
            this.btnTaiKhoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaiKhoan.Location = new System.Drawing.Point(3, 3);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(238, 70);
            this.btnTaiKhoan.TabIndex = 4;
            this.btnTaiKhoan.Text = "Quản lý tài khoản";
            this.btnTaiKhoan.UseVisualStyleBackColor = false;
            this.btnTaiKhoan.Click += new System.EventHandler(this.manage_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(247, 3);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.button2.Size = new System.Drawing.Size(261, 39);
            this.button2.TabIndex = 3;
            this.button2.Text = "Tài khoản nhân viên";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(514, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(261, 39);
            this.button7.TabIndex = 5;
            this.button7.Text = "Tài khoản khách hàng";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // pnThongKe
            // 
            this.pnThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.pnThongKe.Controls.Add(this.btnThongKe);
            this.pnThongKe.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnThongKe.Location = new System.Drawing.Point(3, 84);
            this.pnThongKe.Name = "pnThongKe";
            this.pnThongKe.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.pnThongKe.Size = new System.Drawing.Size(241, 74);
            this.pnThongKe.TabIndex = 11;
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.btnThongKe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.pnThongKe.SetFlowBreak(this.btnThongKe, true);
            this.btnThongKe.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThongKe.Image = ((System.Drawing.Image)(resources.GetObject("btnThongKe.Image")));
            this.btnThongKe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKe.Location = new System.Drawing.Point(3, 23);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(238, 35);
            this.btnThongKe.TabIndex = 5;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // pnThucDon
            // 
            this.pnThucDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.pnThucDon.Controls.Add(this.btnThucDon);
            this.pnThucDon.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnThucDon.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnThucDon.Location = new System.Drawing.Point(3, 244);
            this.pnThucDon.Name = "pnThucDon";
            this.pnThucDon.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.pnThucDon.Size = new System.Drawing.Size(241, 74);
            this.pnThucDon.TabIndex = 11;
            this.pnThucDon.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // btnThucDon
            // 
            this.btnThucDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.btnThucDon.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.btnThucDon.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnThucDon.FlatAppearance.BorderSize = 0;
            this.btnThucDon.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThucDon.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThucDon.Image = ((System.Drawing.Image)(resources.GetObject("btnThucDon.Image")));
            this.btnThucDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThucDon.Location = new System.Drawing.Point(3, 23);
            this.btnThucDon.Name = "btnThucDon";
            this.btnThucDon.Size = new System.Drawing.Size(238, 35);
            this.btnThucDon.TabIndex = 6;
            this.btnThucDon.Text = "Quản lý thực đơn";
            this.btnThucDon.UseMnemonic = false;
            this.btnThucDon.UseVisualStyleBackColor = false;
            this.btnThucDon.UseWaitCursor = true;
            this.btnThucDon.Click += new System.EventHandler(this.btnThucDon_Click);
            // 
            // pnNguyenLieu
            // 
            this.pnNguyenLieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.pnNguyenLieu.Controls.Add(this.btnNguyenLieu);
            this.pnNguyenLieu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnNguyenLieu.Location = new System.Drawing.Point(3, 164);
            this.pnNguyenLieu.Name = "pnNguyenLieu";
            this.pnNguyenLieu.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.pnNguyenLieu.Size = new System.Drawing.Size(241, 74);
            this.pnNguyenLieu.TabIndex = 11;
            // 
            // btnNguyenLieu
            // 
            this.btnNguyenLieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.btnNguyenLieu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNguyenLieu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNguyenLieu.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNguyenLieu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNguyenLieu.Image = ((System.Drawing.Image)(resources.GetObject("btnNguyenLieu.Image")));
            this.btnNguyenLieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNguyenLieu.Location = new System.Drawing.Point(3, 23);
            this.btnNguyenLieu.Name = "btnNguyenLieu";
            this.btnNguyenLieu.Size = new System.Drawing.Size(238, 35);
            this.btnNguyenLieu.TabIndex = 4;
            this.btnNguyenLieu.Text = "      Quản lý nguyên liệu";
            this.btnNguyenLieu.UseVisualStyleBackColor = false;
            this.btnNguyenLieu.Click += new System.EventHandler(this.btnNguyenLieu_Click);
            // 
            // pnDangXuat
            // 
            this.pnDangXuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.pnDangXuat.Controls.Add(this.btnDangXuat);
            this.pnDangXuat.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnDangXuat.Location = new System.Drawing.Point(3, 324);
            this.pnDangXuat.Name = "pnDangXuat";
            this.pnDangXuat.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.pnDangXuat.Size = new System.Drawing.Size(241, 74);
            this.pnDangXuat.TabIndex = 10;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.btnDangXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDangXuat.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangXuat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDangXuat.Image = ((System.Drawing.Image)(resources.GetObject("btnDangXuat.Image")));
            this.btnDangXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat.Location = new System.Drawing.Point(0, 20);
            this.btnDangXuat.Margin = new System.Windows.Forms.Padding(0);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(238, 35);
            this.btnDangXuat.TabIndex = 6;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.UseVisualStyleBackColor = false;
            // 
            // menuTransition
            // 
            this.menuTransition.Interval = 10;
            this.menuTransition.Tick += new System.EventHandler(this.menuTransition_Tick);
            // 
            // sidebarTransition
            // 
            this.sidebarTransition.Interval = 10;
            this.sidebarTransition.Tick += new System.EventHandler(this.sidebarTransition_Tick);
            // 
            // MainViewAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1617, 736);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.IsMdiContainer = true;
            this.Name = "MainViewAdmin";
            this.Text = "XIN CHÀO NGÀY MỚI, ADMIN";
            this.Load += new System.EventHandler(this.MainViewAdmin_Load_1);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.sidebar.ResumeLayout(false);
            this.menuContainer.ResumeLayout(false);
            this.pnThongKe.ResumeLayout(false);
            this.pnThucDon.ResumeLayout(false);
            this.pnNguyenLieu.ResumeLayout(false);
            this.pnDangXuat.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnNguyenLieu;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnThucDon;
        private System.Windows.Forms.FlowLayoutPanel menuContainer;
        private System.Windows.Forms.Button btnTaiKhoan;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Timer menuTransition;
        private System.Windows.Forms.FlowLayoutPanel pnDangXuat;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Timer sidebarTransition;
        private System.Windows.Forms.FlowLayoutPanel pnThucDon;
        private System.Windows.Forms.FlowLayoutPanel pnThongKe;
        private System.Windows.Forms.FlowLayoutPanel pnNguyenLieu;
    }
}