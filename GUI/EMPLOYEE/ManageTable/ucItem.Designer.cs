namespace GUI.EMPLOYEE.ManageTable
{
    partial class ucItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblBan = new System.Windows.Forms.Label();
            this.lblTen = new FontAwesome.Sharp.IconButton();
            this.lblDiaChi = new FontAwesome.Sharp.IconButton();
            this.lblSDt = new FontAwesome.Sharp.IconButton();
            this.lblMaHoaDon = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // lblBan
            // 
            this.lblBan.AutoSize = true;
            this.lblBan.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBan.Location = new System.Drawing.Point(61, 7);
            this.lblBan.Name = "lblBan";
            this.lblBan.Size = new System.Drawing.Size(66, 34);
            this.lblBan.TabIndex = 0;
            this.lblBan.Text = "Bàn";
            // 
            // lblTen
            // 
            this.lblTen.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTen.IconChar = FontAwesome.Sharp.IconChar.User;
            this.lblTen.IconColor = System.Drawing.Color.Black;
            this.lblTen.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.lblTen.IconSize = 23;
            this.lblTen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTen.Location = new System.Drawing.Point(0, 44);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(182, 38);
            this.lblTen.TabIndex = 1;
            this.lblTen.Text = "Nguyen van A";
            this.lblTen.UseVisualStyleBackColor = true;
            this.lblTen.Click += new System.EventHandler(this.lblTen_Click);
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaChi.IconChar = FontAwesome.Sharp.IconChar.LocationDot;
            this.lblDiaChi.IconColor = System.Drawing.Color.Black;
            this.lblDiaChi.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.lblDiaChi.IconSize = 23;
            this.lblDiaChi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDiaChi.Location = new System.Drawing.Point(0, 84);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(182, 76);
            this.lblDiaChi.TabIndex = 2;
            this.lblDiaChi.Text = "Quang Vinh";
            this.lblDiaChi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.lblDiaChi.UseVisualStyleBackColor = true;
            // 
            // lblSDt
            // 
            this.lblSDt.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDt.IconChar = FontAwesome.Sharp.IconChar.Phone;
            this.lblSDt.IconColor = System.Drawing.Color.Black;
            this.lblSDt.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.lblSDt.IconSize = 23;
            this.lblSDt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSDt.Location = new System.Drawing.Point(0, 166);
            this.lblSDt.Name = "lblSDt";
            this.lblSDt.Size = new System.Drawing.Size(182, 37);
            this.lblSDt.TabIndex = 3;
            this.lblSDt.Text = "090909";
            this.lblSDt.UseVisualStyleBackColor = true;
            // 
            // lblMaHoaDon
            // 
            this.lblMaHoaDon.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaHoaDon.IconChar = FontAwesome.Sharp.IconChar.Hashtag;
            this.lblMaHoaDon.IconColor = System.Drawing.Color.Black;
            this.lblMaHoaDon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.lblMaHoaDon.IconSize = 23;
            this.lblMaHoaDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMaHoaDon.Location = new System.Drawing.Point(0, 209);
            this.lblMaHoaDon.Name = "lblMaHoaDon";
            this.lblMaHoaDon.Size = new System.Drawing.Size(182, 38);
            this.lblMaHoaDon.TabIndex = 4;
            this.lblMaHoaDon.Text = "HD01";
            this.lblMaHoaDon.UseVisualStyleBackColor = true;
            // 
            // ucItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(235)))), ((int)(((byte)(159)))));
            this.Controls.Add(this.lblMaHoaDon);
            this.Controls.Add(this.lblSDt);
            this.Controls.Add(this.lblDiaChi);
            this.Controls.Add(this.lblTen);
            this.Controls.Add(this.lblBan);
            this.Name = "ucItem";
            this.Size = new System.Drawing.Size(182, 250);
            this.Click += new System.EventHandler(this.ucItem_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBan;
        private FontAwesome.Sharp.IconButton lblTen;
        private FontAwesome.Sharp.IconButton lblDiaChi;
        private FontAwesome.Sharp.IconButton lblSDt;
        private FontAwesome.Sharp.IconButton lblMaHoaDon;
    }
}
