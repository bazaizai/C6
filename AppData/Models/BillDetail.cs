using AppData.Models;
using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class BillDetail
    {
        public Guid Id { get; set; }
        public Guid? IdBill { get; set; }
        public Guid? IdProductDetail { get; set; }
        public Guid? IdCombo { get; set; }
        public int? SoLuong { get; set; }
        public decimal? DonGia { get; set; }
        public virtual Bill Bill { get; set; }
        public virtual ProductDetail ProductDetail { get; set; }
        public virtual Combo Combo { get; set; }

    }
}
