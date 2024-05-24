namespace GUI.USER.DatBan
{
    partial class ucProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucProduct));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPic = new System.Windows.Forms.PictureBox();
            this.btnName = new FontAwesome.Sharp.IconButton();
            this.btnPrice = new FontAwesome.Sharp.IconButton();
            this.txtStar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPic)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(202, 255);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(221)))));
            this.panel1.Controls.Add(this.btnPic);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(202, 138);
            this.panel1.TabIndex = 1;
            // 
            // btnPic
            // 
            this.btnPic.Image = ((System.Drawing.Image)(resources.GetObject("btnPic.Image")));
            this.btnPic.Location = new System.Drawing.Point(19, 3);
            this.btnPic.Name = "btnPic";
            this.btnPic.Size = new System.Drawing.Size(162, 124);
            this.btnPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnPic.TabIndex = 0;
            this.btnPic.TabStop = false;
            this.btnPic.Click += new System.EventHandler(this.btnPic_Click);
            // 
            // btnName
            // 
            this.btnName.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnName.IconChar = FontAwesome.Sharp.IconChar.Utensils;
            this.btnName.IconColor = System.Drawing.Color.Black;
            this.btnName.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnName.IconSize = 20;
            this.btnName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnName.Location = new System.Drawing.Point(19, 203);
            this.btnName.Name = "btnName";
            this.btnName.Size = new System.Drawing.Size(168, 36);
            this.btnName.TabIndex = 3;
            this.btnName.UseVisualStyleBackColor = true;
            // 
            // btnPrice
            // 
            this.btnPrice.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrice.IconChar = FontAwesome.Sharp.IconChar.DollarSign;
            this.btnPrice.IconColor = System.Drawing.Color.Black;
            this.btnPrice.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPrice.IconSize = 20;
            this.btnPrice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrice.Location = new System.Drawing.Point(19, 165);
            this.btnPrice.Name = "btnPrice";
            this.btnPrice.Size = new System.Drawing.Size(168, 36);
            this.btnPrice.TabIndex = 4;
            this.btnPrice.UseVisualStyleBackColor = true;
            // 
            // txtStar
            // 
            this.txtStar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStar.Location = new System.Drawing.Point(72, 141);
            this.txtStar.Multiline = true;
            this.txtStar.Name = "txtStar";
            this.txtStar.Size = new System.Drawing.Size(112, 21);
            this.txtStar.TabIndex = 5;
            // 
            // ucProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtStar);
            this.Controls.Add(this.btnPrice);
            this.Controls.Add(this.btnName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ucProduct";
            this.Size = new System.Drawing.Size(202, 256);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnPic;
        private FontAwesome.Sharp.IconButton btnName;
        private FontAwesome.Sharp.IconButton btnPrice;
        private System.Windows.Forms.TextBox txtStar;
    }
}
