using System.Windows.Forms;

partial class InputMoneyForm
{
    private System.ComponentModel.IContainer components = null;
    private TextBox txtMoney;
    private Button btnOK;
    private Button btnCancel;

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
        this.txtMoney = new TextBox();
        this.btnOK = new Button();
        this.btnCancel = new Button();
        this.SuspendLayout();
        // 
        // txtMoney
        // 
        this.txtMoney.Location = new System.Drawing.Point(12, 12);
        this.txtMoney.Name = "txtMoney";
        this.txtMoney.Size = new System.Drawing.Size(260, 20);
        this.txtMoney.TabIndex = 0;
        // 
        // btnOK
        // 
        this.btnOK.Location = new System.Drawing.Point(116, 38);
        this.btnOK.Name = "btnOK";
        this.btnOK.Size = new System.Drawing.Size(75, 23);
        this.btnOK.TabIndex = 1;
        this.btnOK.Text = "OK";
        this.btnOK.UseVisualStyleBackColor = true;
        this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
        // 
        // btnCancel
        // 
        this.btnCancel.Location = new System.Drawing.Point(197, 38);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(75, 23);
        this.btnCancel.TabIndex = 2;
        this.btnCancel.Text = "Cancel";
        this.btnCancel.UseVisualStyleBackColor = true;
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        // 
        // InputMoneyForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(284, 71);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnOK);
        this.Controls.Add(this.txtMoney);
        this.Name = "InputMoneyForm";
        this.Text = "Nhập số tiền khách đưa vào";
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
