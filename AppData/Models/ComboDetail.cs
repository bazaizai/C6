using AppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Models
{
    public class ComboDetail
    {
        public Guid Id { get; set; }
        public Guid IdProductDetail { get; set; }
        public Guid IdCombo { get; set; }
        public int GiaBan { get; set; }
        public virtual ProductDetail Product { get; set; }
        public virtual Combo Combo { get; set; }
    }
}
