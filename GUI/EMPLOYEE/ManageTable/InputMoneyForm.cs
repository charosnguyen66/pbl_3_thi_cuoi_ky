using GUI.EMPLOYEE.ManageTable;
using System;
using System.Windows.Forms;

public partial class InputMoneyForm : Form
{
    public decimal MoneyReceived { get; private set; }

    public InputMoneyForm()
    {
        InitializeComponent();
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
        if (decimal.TryParse(txtMoney.Text, out decimal money))
        {
            MoneyReceived = money;
            InvoiceSession.tienKhachDua = money;
            InvoiceSession.tienKhachDua = MoneyReceived;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        else
        {
            MessageBox.Show("Vui lòng nhập số tiền hợp lệ.");
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }
}
