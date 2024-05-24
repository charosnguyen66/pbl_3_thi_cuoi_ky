using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    internal class SalaryEmployee
    {
        public string EmployeeID { get; set; }
        public Nullable<System.DateTime> OvertimeDate { get; set; }
        public Nullable<int> OvertimeHours { get; set; }
        public Nullable<double> coeffSalary { get; set; }
    }
}
