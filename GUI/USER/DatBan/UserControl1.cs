using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.USER.DatBan
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        private string _tableName;

        public string TableName
        {
            get { return _tableName; }
            set
            {
                _tableName = value;
                UpdateUI();
            }
        }

        private void UpdateUI()
        {
            lblNameTable.Text = _tableName;
        }
        public event EventHandler TableClicked;

        // Khi người dùng click vào control, kích hoạt sự kiện click tùy chỉnh này
        private void UserControl1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            TableClicked?.Invoke(this, e);
        }
    }
}
