using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class BillDetailsViewModel
    {
        public Guid Id { get; set; }
        public string MaBill { get; set; }
        public string TenMonAn { get; set; }
        public string? Combo { get; set; }
        public string? Anh { get; set; }
        public int? SoLuong { get; set; }
        public decimal? DonGia { get; set; }
    }
}
