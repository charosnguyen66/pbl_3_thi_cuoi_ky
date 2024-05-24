using System;

namespace BusinessLayer.DTO
{
    public class DetailInvoice_DTO
    {
        public string ProductName { get; set; } // Tên món ăn
        public decimal Price { get; set; } // Đơn giá
        public int Quantity { get; set; } // Số lượng
        public decimal TotalPrice { get; set; } // Tổng tiền
    }
}
