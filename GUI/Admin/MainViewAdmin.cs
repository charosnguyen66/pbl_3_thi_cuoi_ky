using GUI.Admin.ThongKe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class MainViewAdmin : Form
    {
        ManageCustomer customer;
        ManageEmployee employee;
        ManageIngredient ingredient;
        ManageMenu menu;
        ManageStatistic statistic;
        public MainViewAdmin()
        {
            InitializeComponent();
            //mdiProp();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        //private void mdiProp()
        //{
        //    this.SetBevel(false);
        //    Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.FromArgb(232, 234, 237);
        //}
        bool menuExpand = false;

        private void menuTransition_Tick(object sender, EventArgs e)
        {
            if(menuExpand == false)
            {
                    menuContainer.Height += 10;
                if(menuContainer.Height >= 168)
                {
                    menuTransition.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                menuContainer.Height -= 10;
                if(menuContainer.Height <= 56)
                {
                    menuTransition.Stop();
                    menuExpand = false;
                }
            }
        }

        private void manage_Click(object sender, EventArgs e)
        {
            menuTransition.Start();
        }

     

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        bool sidebarExpand = true;
        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if(sidebarExpand) {
                sidebar.Width -= 10;
                if(sidebar.Width <= 51)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();

                    pnDangXuat.Width = sidebar.Width;
                    pnNguyenLieu.Width = sidebar.Width;
                    pnThongKe.Width = sidebar.Width;
                    pnThucDon.Width = sidebar.Width;
                    menuContainer.Width = sidebar.Width;
                }
                

            }
            else
            {
                sidebar.Width += 10;
                if(sidebar.Width >= 190)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();

                    pnDangXuat.Width = sidebar.Width;
                    pnNguyenLieu.Width = sidebar.Width; 
                    pnThongKe.Width = sidebar.Width;
                    pnThucDon.Width = sidebar.Width;
                    menuContainer.Width = sidebar.Width;

                }
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThucDon_Click(object sender, EventArgs e)
        {
            if(menu == null)
            {
                menu = new ManageMenu();
                menu.FormClosed += Menu_FormClosed;
                menu.MdiParent = this;
                menu.Show();
            }
            else
            {
                menu.Activate();
            }
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(employee == null)
            {
                employee = new ManageEmployee();
                employee.FormClosed += Employee_FormClosed;
                employee.MdiParent = this;
                employee.Dock = DockStyle.Fill;
                employee.Show();    
            }
            else
            {
                employee.Activate();
            }
        }

        private void Employee_FormClosed(object sender, FormClosedEventArgs e)
        {
            employee = null;
        }
        private ManageCustomer previousCustomer;

        private void button7_Click(object sender, EventArgs e)
        {
            if (customer == null)
            {
                customer = new ManageCustomer();
                customer.FormClosed += Customer_FormClosed;
                customer.MdiParent = this;
                customer.Dock = DockStyle.Fill;
                customer.Show();
            }
            else
            {
                customer.Activate();
            }
            previousCustomer = customer;
        }

        private void Customer_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (previousCustomer != null)
            {
                previousCustomer.Show();
                previousCustomer = null; // Xóa tham chiếu tới form cũ
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (statistic == null)
            {
                statistic = new ManageStatistic();
                statistic.FormClosed += Statistic_FormClosed;
                statistic.MdiParent = this;
                statistic.Show();
            }
            else
            {
                statistic.Activate();
            }
        }

        private void Statistic_FormClosed(object sender, FormClosedEventArgs e)
        {
            statistic = null;
        }
        private void btnNguyenLieu_Click(object sender, EventArgs e)
        {
            if (ingredient == null)
            {
                ingredient = new ManageIngredient();
                ingredient.FormClosed += Ingredient_FormClosed;
                ingredient.MdiParent = this;
                ingredient.Show();
            }
            else
            {
                ingredient.Activate();
            }
        }

        private void Ingredient_FormClosed(object sender, FormClosedEventArgs e)
        {
            ingredient = null;
        }

      
        private Color originalColor;

        private void MainViewAdmin_Load(object sender, EventArgs e)
        {
            // Lưu màu nền ban đầu của button
            originalColor = sidebar.BackColor;
        }

        private void MainViewAdmin_GotFocus(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = Color.Red; // Thay đổi màu nền của button trở lại thành màu đỏ khi di chuột rời khỏi
            }
            
        }

        private void MainViewAdmin_LostFocus(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = originalColor; // Thay đổi màu nền của button trở lại thành màu đỏ khi di chuột rời khỏi
            }
        }

        private void MainViewAdmin_Load_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
