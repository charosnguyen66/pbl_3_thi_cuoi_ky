using BusinessLayer;
using BusinessLayer.DTO;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI.USER.LichSuDat
{
    public partial class detailHistory : Form
    {
        private PBL3Entities _context;
        Invoice _invoice;
        string uu;
        public detailHistory(string name)
        {
            InitializeComponent();
            _invoice = new Invoice();
            uu = name;
            LoadInvoiceDetails();
            InitializeDataGridView();
            _context = new PBL3Entities();
        }
        private void InitializeDataGridView()
        {
            // Customize DataGridView appearance
            dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSlateGray;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10, FontStyle.Bold);

            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                e.CellStyle.BackColor = Color.LightGray;
            }
            else
            {
                e.CellStyle.BackColor = Color.White;
            }
            e.CellStyle.ForeColor = Color.Black;
            e.CellStyle.Font = new Font("Century Gothic", 9, FontStyle.Regular);
        }
        public void LoadInvoiceDetails()
        {
            List<Print_DTO> list = _invoice.getPrint(uu);
            dataGridView1.DataSource = list;
            lblHD.Text = uu;
            lblTongTien.Text = _invoice.CalculateTotalPrice(uu).ToString("N0", new System.Globalization.CultureInfo("vi-VN")) + "VND";
        }
    }
}
