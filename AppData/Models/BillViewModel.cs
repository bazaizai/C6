using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class BillViewModel
    {
        public Guid Id { get; set; }
        public Guid? IdUser { get; set; }
        public string TenNV { get; set; }
        public string? Ma { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayThanhToan { get; set; }
        public string? DiaChi { get; set; }
        public string? Sdt { get; set; }
        public decimal? TienShip { get; set; }
    }
}
