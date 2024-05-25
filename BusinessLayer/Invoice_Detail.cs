    using BusinessLayer.DTO;
    using DataLayer;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace BusinessLayer
    {
        public class Invoice_Detail
        {
            private PBL3Entities db = new PBL3Entities();

            public List<tb_Invoice_Detail> GetAccountsFromTable(string tableName)
            {

                return db.tb_Invoice_Detail.ToList();

            }
        public List<THONGKE_DTO> gett(int targetMonth)
        {
            using (var db = new PBL3Entities())
            {
                var query = from id in db.tb_Invoice_Detail
                            join p in db.tb_Product on id.ProductID equals p.ProductID
                            join i in db.tb_Invoice on id.InvoiceID equals i.InvoiceID
                            where i.OrderDate.Value.Month == targetMonth // Lọc theo tháng được chỉ định
                            group new { id, p, i } by new { i.OrderDate.Value.Year, i.OrderDate.Value.Month, p.ProductID, p.ProductName } into g
                            let totalRevenue = g.Sum(x => x.id.Quanlity * x.p.Price)
                            orderby g.Key.Year, g.Key.Month, totalRevenue descending
                            select new
                            {
                                Year = g.Key.Year,
                                Month = g.Key.Month,
                                ProductID = g.Key.ProductID,
                                ProductName = g.Key.ProductName,
                                TotalRevenue = totalRevenue,
                                OrderDate = g.Select(x => x.i.OrderDate).FirstOrDefault()
                            };

                var allItemsByMonth = query
                    .Select(x => new THONGKE_DTO
                    {
                        tenMon = x.ProductName,
                        tongTien = (double)x.TotalRevenue,
                        thoigian = x.OrderDate.ToString()
                    })
                    .ToList();

                return allItemsByMonth;
            }
        }



        public List<THONGKE_DTO> getTop3ByMonth(int thang)
        {
            using (var db = new PBL3Entities())
            {
                var query = from id in db.tb_Invoice_Detail
                            join p in db.tb_Product on id.ProductID equals p.ProductID
                            join i in db.tb_Invoice on id.InvoiceID equals i.InvoiceID
                            where i.OrderDate.Value.Month == thang // so sánh phần tháng của OrderDate với tháng được truyền vào
                            group new { id, p, i } by new { i.OrderDate.Value.Year, i.OrderDate.Value.Month, p.ProductID, p.ProductName } into g
                            let totalRevenue = g.Sum(x => x.id.Quanlity * x.p.Price)
                            orderby g.Key.Year, g.Key.Month, totalRevenue descending
                            select new
                            {
                                Year = g.Key.Year,
                                Month = g.Key.Month,
                                ProductID = g.Key.ProductID,
                                ProductName = g.Key.ProductName,
                                TotalRevenue = totalRevenue,
                                OrderDate = g.Select(x => x.i.OrderDate).FirstOrDefault()
                            };

                var top3ByMonth = query
                    .GroupBy(x => new { x.Year, x.Month })
                    .SelectMany(g => g.OrderByDescending(x => x.TotalRevenue).Take(3)) // Lấy 3 mục hàng có tổng doanh thu cao nhất trong mỗi tháng
                    .Select(x => new THONGKE_DTO
                    {
                        tenMon = x.ProductName,
                        tongTien = (double)x.TotalRevenue,
                        thoigian = x.OrderDate.ToString()
                    })
                    .ToList();

                return top3ByMonth;
            }
        }




        public string GetLastInvoiceID()
            {
                var lastInvoice = db.tb_Invoice_Detail.OrderByDescending(i => i.ID).FirstOrDefault();
                return lastInvoice?.ID;
            }
            public tb_Invoice_Detail getItem(string id) { return db.tb_Invoice_Detail.FirstOrDefault(x => x.ID == id); }
            public bool checkExist(string username)
            {
                List<tb_Invoice_Detail> tb_Employee = GetAccountsFromTable("tb_Invoice_Detail");

                foreach (var account in tb_Employee)
                {
                    if (account.InvoiceID.Trim() == username)
                    {
                        return true;
                    }
                }

                return false;
            }
            public tb_Invoice_Detail AddNew(tb_Invoice_Detail customer)
            {
                try
                {
                    db.tb_Invoice_Detail.Add(customer);
                    db.SaveChanges();
                    return customer;
                }
                catch (DbUpdateException ex)
                {
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine("Inner Exception Message: " + ex.InnerException.Message);
                    }

                    throw;
                }

            }
            public tb_Invoice_Detail Update(tb_Invoice_Detail customer)
            {
                try
                {
                    var _dt = db.tb_Invoice_Detail.FirstOrDefault(x => x.ID == customer.ID);
                    //_dt.ID = customer.ID;
                    _dt.InvoiceID = customer.InvoiceID;
                    _dt.ProductID = customer.ProductID;
                    _dt.Quanlity = customer.Quanlity;
                    _dt.Discount = customer.Discount;
            
                    db.SaveChanges();

                    return customer;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            public void Delete(string id)
            {
                try
                {
                    var _dt = db.tb_Invoice_Detail.FirstOrDefault(x => x.ID == id);
                    db.tb_Invoice_Detail.Remove(_dt);
                    db.SaveChanges();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
