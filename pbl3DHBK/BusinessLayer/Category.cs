using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLayer
{
    public class Category
    {
        private PBL3Entities db = new PBL3Entities();
        public List<tb_Category> GetAccountsFromTable(string f)
        {

            return db.tb_Category.ToList();

        }
        public List<tb_Category> GetAccountsFromTable()
        {

            return db.tb_Category.ToList();

        }
        public  string switchToID(string name)
        {

            var category = db.tb_Category.FirstOrDefault(c => c.CategoryName == name);

            // Nếu tìm thấy, trả về ID của thể loại, nếu không, trả về -1 hoặc một giá trị khác để chỉ ra rằng không tìm thấy
            return category != null ? category.CategoryID : "";
        }
        public void setCBB(ComboBox cbbTheLoai)
        {
            Category category = new Category();
            List<tb_Category> categories = category.GetAccountsFromTable();

            cbbTheLoai.Items.Clear();

            foreach (tb_Category cat in categories)
            {
                cbbTheLoai.Items.Add(cat.CategoryName.Trim());
            }
            if (cbbTheLoai.Items.Count > 0)
            {
                cbbTheLoai.SelectedIndex = 0;
            }
        }


    }
}
