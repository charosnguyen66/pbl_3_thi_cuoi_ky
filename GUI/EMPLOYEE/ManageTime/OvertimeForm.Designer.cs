//using System;
//using System.Windows.Forms;

//namespace GUI.EMPLOYEE.ManageTime
//{
//    public partial class OvertimeForm : Form
//    {
//        public int HoursOT { get; private set; }
//        public decimal CoeffSalary { get; private set; } = 30000; // Mặc định 30,000

//        public OvertimeForm()
//        {
//            InitializeComponent();
//        }

//        private void InitializeComponent()
//        {
//            this.lblHoursOT = new System.Windows.Forms.Label();
//            this.txtHoursOT = new System.Windows.Forms.TextBox();
//            this.btnSave = new System.Windows.Forms.Button();
//            this.SuspendLayout();
//            // 
//            // lblHoursOT
//            // 
//            this.lblHoursOT.AutoSize = true;
//            this.lblHoursOT.Location = new System.Drawing.Point(30, 30);
//            this.lblHoursOT.Name = "lblHoursOT";
//            this.lblHoursOT.Size = new System.Drawing.Size(85, 17);
//            this.lblHoursOT.TabIndex = 0;
//            this.lblHoursOT.Text = "Số giờ tăng ca:";
//            // 
//            // txtHoursOT
//            // 
//            this.txtHoursOT.Location = new System.Drawing.Point(120, 27);
//            this.txtHoursOT.Name = "txtHoursOT";
//            this.txtHoursOT.Size = new System.Drawing.Size(100, 22);
//            this.txtHoursOT.TabIndex = 1;
//            // 
//            // btnSave
//            // 
//            this.btnSave.Location = new System.Drawing.Point(120, 70);
//            this.btnSave.Name = "btnSave";
//            this.btnSave.Size = new System.Drawing.Size(75, 23);
//            this.btnSave.TabIndex = 2;
//            this.btnSave.Text = "Lưu";
//            this.btnSave.UseVisualStyleBackColor = true;
//            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
//            // 
//            // OvertimeForm
//            // 
//            this.ClientSize = new System.Drawing.Size(284, 111);
//            this.Controls.Add(this.btnSave);
//            this.Controls.Add(this.txtHoursOT);
//            this.Controls.Add(this.lblHoursOT);
//            this.Name = "OvertimeForm";
//            this.Text = "Đăng ký tăng ca";
//            this.ResumeLayout(false);
//            this.PerformLayout();
//        }

//        private System.Windows.Forms.Label lblHoursOT;
//        private System.Windows.Forms.TextBox txtHoursOT;
//        private System.Windows.Forms.Button btnSave;

//        private void BtnSave_Click(object sender, EventArgs e)
//        {
//            if (int.TryParse(txtHoursOT.Text, out int hoursOT))
//            {
//                HoursOT = hoursOT;
//                DialogResult = DialogResult.OK;
//                Close();
//            }
//            else
//            {
//                MessageBox.Show("Vui lòng nhập số giờ hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }
//    }
//}
