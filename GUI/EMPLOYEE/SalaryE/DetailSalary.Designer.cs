using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI.EMPLOYEE.Salary
{
    partial class DetailSalary
    {
        private System.ComponentModel.IContainer components = null;
        private DateTimePicker dtpMonthYear;
        private Button btnCalculate;
        private Label lblBasicSalary;
        private Label lblOvertimeSalary;
        private Label lblSickOffSalary;
        private Label lblTotalSalary;
        private TextBox txtBasicSalary;
        private TextBox txtOvertimeSalary;
        private TextBox txtSickOffSalary;
        private TextBox txtTotalSalary;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dtpMonthYear = new System.Windows.Forms.DateTimePicker();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblBasicSalary = new System.Windows.Forms.Label();
            this.lblOvertimeSalary = new System.Windows.Forms.Label();
            this.lblSickOffSalary = new System.Windows.Forms.Label();
            this.lblTotalSalary = new System.Windows.Forms.Label();
            this.txtBasicSalary = new System.Windows.Forms.TextBox();
            this.txtOvertimeSalary = new System.Windows.Forms.TextBox();
            this.txtSickOffSalary = new System.Windows.Forms.TextBox();
            this.txtTotalSalary = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dtpMonthYear
            // 
            this.dtpMonthYear.BackColor = System.Drawing.Color.White;
            this.dtpMonthYear.CustomFormat = "MM/yyyy";
            this.dtpMonthYear.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpMonthYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonthYear.Location = new System.Drawing.Point(161, 94);
            this.dtpMonthYear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpMonthYear.Name = "dtpMonthYear";
            this.dtpMonthYear.ShowUpDown = true;
            this.dtpMonthYear.Size = new System.Drawing.Size(140, 34);
            this.dtpMonthYear.TabIndex = 0;
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculate.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCalculate.ForeColor = System.Drawing.Color.White;
            this.btnCalculate.Location = new System.Drawing.Point(411, 85);
            this.btnCalculate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(168, 43);
            this.btnCalculate.TabIndex = 1;
            this.btnCalculate.Text = "Kiểm tra";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // lblBasicSalary
            // 
            this.lblBasicSalary.AutoSize = true;
            this.lblBasicSalary.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblBasicSalary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblBasicSalary.Location = new System.Drawing.Point(156, 159);
            this.lblBasicSalary.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBasicSalary.Name = "lblBasicSalary";
            this.lblBasicSalary.Size = new System.Drawing.Size(132, 28);
            this.lblBasicSalary.TabIndex = 2;
            this.lblBasicSalary.Text = "Lương cơ bản";
            // 
            // lblOvertimeSalary
            // 
            this.lblOvertimeSalary.AutoSize = true;
            this.lblOvertimeSalary.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblOvertimeSalary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblOvertimeSalary.Location = new System.Drawing.Point(156, 227);
            this.lblOvertimeSalary.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOvertimeSalary.Name = "lblOvertimeSalary";
            this.lblOvertimeSalary.Size = new System.Drawing.Size(137, 28);
            this.lblOvertimeSalary.TabIndex = 4;
            this.lblOvertimeSalary.Text = "Lương tăng ca";
            // 
            // lblSickOffSalary
            // 
            this.lblSickOffSalary.AutoSize = true;
            this.lblSickOffSalary.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblSickOffSalary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSickOffSalary.Location = new System.Drawing.Point(156, 296);
            this.lblSickOffSalary.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSickOffSalary.Name = "lblSickOffSalary";
            this.lblSickOffSalary.Size = new System.Drawing.Size(121, 28);
            this.lblSickOffSalary.TabIndex = 6;
            this.lblSickOffSalary.Text = "Lương bị trừ";
            // 
            // lblTotalSalary
            // 
            this.lblTotalSalary.AutoSize = true;
            this.lblTotalSalary.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblTotalSalary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTotalSalary.Location = new System.Drawing.Point(156, 360);
            this.lblTotalSalary.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalSalary.Name = "lblTotalSalary";
            this.lblTotalSalary.Size = new System.Drawing.Size(106, 28);
            this.lblTotalSalary.TabIndex = 8;
            this.lblTotalSalary.Text = "Tổng cộng";
            // 
            // txtBasicSalary
            // 
            this.txtBasicSalary.BackColor = System.Drawing.Color.White;
            this.txtBasicSalary.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtBasicSalary.Location = new System.Drawing.Point(378, 159);
            this.txtBasicSalary.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBasicSalary.Name = "txtBasicSalary";
            this.txtBasicSalary.Size = new System.Drawing.Size(201, 34);
            this.txtBasicSalary.TabIndex = 3;
            // 
            // txtOvertimeSalary
            // 
            this.txtOvertimeSalary.BackColor = System.Drawing.Color.White;
            this.txtOvertimeSalary.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtOvertimeSalary.Location = new System.Drawing.Point(378, 227);
            this.txtOvertimeSalary.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtOvertimeSalary.Name = "txtOvertimeSalary";
            this.txtOvertimeSalary.Size = new System.Drawing.Size(201, 34);
            this.txtOvertimeSalary.TabIndex = 5;
            // 
            // txtSickOffSalary
            // 
            this.txtSickOffSalary.BackColor = System.Drawing.Color.White;
            this.txtSickOffSalary.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSickOffSalary.Location = new System.Drawing.Point(378, 296);
            this.txtSickOffSalary.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSickOffSalary.Name = "txtSickOffSalary";
            this.txtSickOffSalary.Size = new System.Drawing.Size(201, 34);
            this.txtSickOffSalary.TabIndex = 7;
            // 
            // txtTotalSalary
            // 
            this.txtTotalSalary.BackColor = System.Drawing.Color.White;
            this.txtTotalSalary.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTotalSalary.Location = new System.Drawing.Point(378, 360);
            this.txtTotalSalary.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTotalSalary.Name = "txtTotalSalary";
            this.txtTotalSalary.Size = new System.Drawing.Size(201, 34);
            this.txtTotalSalary.TabIndex = 9;
            // 
            // DetailSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(835, 445);
            this.Controls.Add(this.txtTotalSalary);
            this.Controls.Add(this.lblTotalSalary);
            this.Controls.Add(this.txtSickOffSalary);
            this.Controls.Add(this.lblSickOffSalary);
            this.Controls.Add(this.txtOvertimeSalary);
            this.Controls.Add(this.lblOvertimeSalary);
            this.Controls.Add(this.txtBasicSalary);
            this.Controls.Add(this.lblBasicSalary);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.dtpMonthYear);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "DetailSalary";
            this.Text = "Detail Salary";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
