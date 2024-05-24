using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class NhanVien_DTO
    {
        public string EmployeeID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public string TypeEmployee { get; set; }
        public string Password { get; set; }
        //public double OverWage {  get; set; }
        //public DateTime overDate { get; set; }
        //public int overTimerHours {  get; set; }
        //public int overTimerMinutes { get; set;}
        //public double coeffWage {  get; set; }
    }
}
