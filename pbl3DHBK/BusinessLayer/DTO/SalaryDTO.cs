using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class SalaryDTO
    {
        public double BasicSalary { get; set; }
        public int OvertimeHours { get; set; }
        public double LatePenalty { get; set; }
        public int SickDays { get; set; }
        public double TotalSalary { get; set; }
    }
}
