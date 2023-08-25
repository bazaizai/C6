using AppData.Models;

namespace AppData.Models
{
    public class CartDetail
    {
        public Guid Id { get; set; }
        public Guid UserID { get; set; }
        public Guid? DetailProductID { get; set; }
        public Guid ?IdCombo { get; set; }
        public int Soluong { get; set; }
        public decimal Dongia { get; set; }
        public virtual Cart? Cart { get; set; }
        public virtual ProductDetail? ProductDetail { get; set; }
        public virtual Combo? Combo { get; set; }
    }
}
