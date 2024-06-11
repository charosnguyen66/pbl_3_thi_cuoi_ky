using BusinessLayer;
using GUI.Admin.Nhanvien;
using GUI.THUCDON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //AdminManager adminManager = new AdminManager();

            //// Tạo mới Admin
            //var newAdmin = adminManager.AddAdmin("Admin1", "Abc");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainViewAdmin());
        }
    }
}
