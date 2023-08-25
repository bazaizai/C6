using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public class Bill
    {
        
        public Guid Id { get; set; }
        public Guid? IdUser { get; set; }
        public string? Ma { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayThanhToan { get; set; }
        public string? DiaChi { get; set; }
        public string? Sdt { get; set; }
        public decimal? TienShip { get; set; }
        public virtual User? User { get; set; }
        public virtual List<BillDetail>? BillDetails { get; set; }
    }
}
