using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Navigation;

namespace GUI.USER.DatBan
{
    public partial class ucProduct : UserControl
    {

        public ucProduct()
        {
            InitializeComponent();
        }

        public event EventHandler OnSelect = null;

        public string id { get; set; }
        public double Price
        {
            get
            {
                return Convert.ToDouble(btnPrice.Text);
            }
            set
            {
                btnPrice.Text = value.ToString();
            }
        }

        public int star { get; set; }
        public string category { get; set; }
        public string name
        {
            get
            {
                return btnName.Text;
            }
            set
            {
                btnName.Text = value;
            }
        }

        public Image image
        {
            get
            {
                return btnPic.Image;
            }
            set
            {
                btnPic.Image = value;
            }
        }

        private void btnPic_Click(object sender, EventArgs e)
        {
            OnSelect?.Invoke(this, e);
        }
    }
}
