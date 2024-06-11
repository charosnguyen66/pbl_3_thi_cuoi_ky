namespace GUI.Admin.ThongKe
{
    partial class ManageStatistic
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
            this.chartMon = new LiveCharts.WinForms.CartesianChart();
            this.cbb1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbThang = new System.Windows.Forms.ComboBox();
            this.lblThang = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // chartMon
            // 
            this.chartMon.Location = new System.Drawing.Point(575, 29);
            this.chartMon.Name = "chartMon";
<<<<<<< HEAD
            this.chartMon.Size = new System.Drawing.Size(756, 292);
=======
            this.chartMon.Size = new System.Drawing.Size(756, 338);
>>>>>>> 64de7580e291ace885cd111372303e1c5a33b3ef
            this.chartMon.TabIndex = 0;
            this.chartMon.Text = "cartesianChart1";
            // 
            // cbb1
            // 
            this.cbb1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbb1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb1.FormattingEnabled = true;
            this.cbb1.Location = new System.Drawing.Point(64, 127);
            this.cbb1.Name = "cbb1";
            this.cbb1.Size = new System.Drawing.Size(185, 29);
            this.cbb1.TabIndex = 1;
            this.cbb1.SelectedIndexChanged += new System.EventHandler(this.cbb1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 34);
            this.label1.TabIndex = 2;
            this.label1.Text = "THỐNG KÊ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
<<<<<<< HEAD
            this.dataGridView1.Location = new System.Drawing.Point(35, 342);
=======
            this.dataGridView1.Location = new System.Drawing.Point(35, 373);
>>>>>>> 64de7580e291ace885cd111372303e1c5a33b3ef
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1296, 336);
            this.dataGridView1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Chọn loại thông kê";
            // 
            // cbbThang
            // 
            this.cbbThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbThang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbbThang.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbThang.FormattingEnabled = true;
            this.cbbThang.Location = new System.Drawing.Point(329, 127);
            this.cbbThang.Name = "cbbThang";
            this.cbbThang.Size = new System.Drawing.Size(151, 29);
            this.cbbThang.TabIndex = 5;
            this.cbbThang.Visible = false;
            this.cbbThang.SelectedIndexChanged += new System.EventHandler(this.cbbThang_SelectedIndexChanged_1);
            // 
            // lblThang
            // 
            this.lblThang.AutoSize = true;
            this.lblThang.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThang.Location = new System.Drawing.Point(325, 92);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(125, 20);
            this.lblThang.TabIndex = 6;
            this.lblThang.Text = "Chọn một tháng";
            this.lblThang.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(837, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Top 3 món ăn yêu thích nhất\r\n";
            // 
            // ManageStatistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
<<<<<<< HEAD
            this.ClientSize = new System.Drawing.Size(1458, 677);
=======
            this.ClientSize = new System.Drawing.Size(1390, 721);
>>>>>>> 64de7580e291ace885cd111372303e1c5a33b3ef
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblThang);
            this.Controls.Add(this.cbbThang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbb1);
            this.Controls.Add(this.chartMon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManageStatistic";
            this.Text = "ManageStatistic";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart chartMon;
        private System.Windows.Forms.ComboBox cbb1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbThang;
        private System.Windows.Forms.Label lblThang;
        private System.Windows.Forms.Label label3;
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 64de7580e291ace885cd111372303e1c5a33b3ef
