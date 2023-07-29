using AppData.Models;
using System;
using System.Collections.Generic;

namespace AppData.Models
{
    public partial class ProductDetail
    {
        public Guid Id { get; set; }

        public string Ma { get; set; }
        public string Ten { get; set; }
        public string Loai { get; set; }
        public string Anh { get; set; }
        public decimal? GiaBan { get; set; }
        public virtual IEnumerable<BillDetail> BillDetail { get; set; }
        public virtual IEnumerable<ComboDetail> ComboDetails { get; set; }

        public virtual IEnumerable<CartDetail> CartDetail { get; set; }
    }
}
