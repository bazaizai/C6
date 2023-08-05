using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.ViewModes.Combo
{
    public class DetailComboModel
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string Loai { get; set; }
        public string Anh { get; set; }
        public decimal? GiaBan { get; set; }
    }
}
