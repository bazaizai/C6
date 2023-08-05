using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.ViewModes.CartDetail
{
    public class CartDetailViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int SoLuong { get; set; }

        public decimal Dongia { get; set; }  
        
        public decimal Sum { get; set; }
    }
}
