// QrCodeForm.Designer.cs
namespace GUI.USER.DatBan
{
    partial class QrCodeForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pictureBoxQrCode;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pictureBoxQrCode = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQrCode)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxQrCode
            // 
            this.pictureBoxQrCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxQrCode.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxQrCode.Name = "pictureBoxQrCode";
            this.pictureBoxQrCode.Size = new System.Drawing.Size(300, 300);
            this.pictureBoxQrCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxQrCode.TabIndex = 0;
            this.pictureBoxQrCode.TabStop = false;
            // 
            // QrCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.pictureBoxQrCode);
            this.Name = "QrCodeForm";
            this.Text = "QR Code";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQrCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
