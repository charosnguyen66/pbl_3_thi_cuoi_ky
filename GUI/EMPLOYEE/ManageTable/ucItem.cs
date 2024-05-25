using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.EMPLOYEE.ManageTable
{
    public partial class ucItem : UserControl
    {
        public ucItem()
        {
            InitializeComponent();
           
    }
        public event EventHandler OnSelect = null;

        public string nameKH
        {
            get
            {
                return lblTen.Text;
            }
            set
            {
                lblTen.Text = value;
            }
        }
        public string desss { get; set; }
        public string sdt
        {
            get
            {
                return lblSDt.Text;
            }
            set
            {
                lblSDt.Text = value;
            }
        }
        public string diaChi
        {
            get
            {
                return lblDiaChi.Text;
            }
            set
            {
                lblDiaChi.Text = value;
            }
        }
        public string maDonHang
        {
            get
            {
                return lblMaHoaDon.Text;
            }
            set
            {
                lblMaHoaDon.Text = value;
            }
        }
        public string banAn
        {
            get
            {
                return lblBan.Text;
            }
            set
            {
                lblBan.Text = value;
            }
        }
        private void ucItem_Click(object sender, EventArgs e)
        {
            OnSelect?.Invoke(this, e);
        }

        private void lblTen_Click(object sender, EventArgs e)
        {
            OnSelect?.Invoke(this, e);

        }
    }
}
