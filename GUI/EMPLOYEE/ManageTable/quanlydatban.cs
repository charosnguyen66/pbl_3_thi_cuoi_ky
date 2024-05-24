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
    public partial class quanlydatban : Form
    {
        public quanlydatban()
        {
            InitializeComponent();
            load_DataGridView(dataGridView1);
        }

        public void load_DataGridView(DataGridView dataGridView)
        {
            

           

            dataGridView.Columns["TenKH"].HeaderText = "Tên KH";
            dataGridView.Columns["ThoiGianDat"].HeaderText = "Thời gian đặt";
            dataGridView.Columns["TenMon"].HeaderText = "Tên món";
            dataGridView.Columns["Ban"].HeaderText = "Bàn";
            dataGridView.Columns["SdtKH"].HeaderText = "Sđt KH";
            dataGridView.Columns["XacNhanDat"].HeaderText = "Xác nhận đặt";

            dataGridView.Columns["XacNhanDat"].CellTemplate = new DataGridViewCheckBoxCell();
        }


    }
}
