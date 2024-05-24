using BusinessLayer.DTO;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class SalaryCalculator
    {
        private PBL3Entities db = new PBL3Entities();

        public SalaryDTO CalculateSalary(string employeeId, int month, int year)
        {
            var wage = db.tb_Wage.FirstOrDefault(x => x.EmployeeID == employeeId);

            var overtimes = db.tb_OverTime
                .Where(x => x.EmployeeID == employeeId && x.OvertimeDate.HasValue && x.OvertimeDate.Value.Month == month && x.OvertimeDate.Value.Year == year)
                .ToList();

            var sickOffs = db.tb_SickOff
                .Where(x => x.EmployeeID == employeeId && x.SickDate.HasValue && x.SickDate.Value.Month == month && x.SickDate.Value.Year == year)
                .ToList();

            double basicSalary = Convert.ToDouble(wage.Wage);
            int overtimeHours = overtimes.Sum(x => x.OvertimeHours ?? 0); // Sử dụng toán tử '??' để xử lý giá trị null
            double overtimeRate = overtimes.Any() ? overtimes.Average(x => x.coeffSalary ?? 0) : 0; // Sử dụng '??' cho giá trị nullable double
            double latePenalty = 0; // Giả sử bạn có cách tính phạt trễ giờ làm
            int sickDays = sickOffs.Count;

            double dailySalary = basicSalary / 22; // Giả sử có 22 ngày làm việc trong tháng
            double totalSalary = basicSalary + (overtimeHours * overtimeRate * dailySalary) - latePenalty - (sickDays * dailySalary);

            return new SalaryDTO
            {
                BasicSalary = basicSalary,
                OvertimeHours = overtimeHours,
                LatePenalty = latePenalty,
                SickDays = sickDays,
                TotalSalary = totalSalary
            };
        }
    }
}
