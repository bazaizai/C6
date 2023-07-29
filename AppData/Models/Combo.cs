
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class Combo
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public virtual List<BillDetail> BillDetails { get; set; }
        public virtual List<ComboDetail> ComboDetail { get; set; }
        public virtual List<CartDetail> CartDetails { get; set; }
    }
}
