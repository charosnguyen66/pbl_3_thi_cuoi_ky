// QrCodeForm.cs
using System.Drawing;
using System.Windows.Forms;

namespace GUI.USER.DatBan
{
    public partial class QrCodeForm : Form
    {
        public QrCodeForm(Image qrCodeImage)
        {
            InitializeComponent();
            pictureBoxQrCode.Image = qrCodeImage;
        }
    }
}
