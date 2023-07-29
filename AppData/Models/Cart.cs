namespace AppData.Models
{
    public class Cart
    {
        public Guid UserID { get; set; }
        public virtual IEnumerable<CartDetail> cartdetail { get; set; }
        public virtual User User { get; set; }
    }
}
