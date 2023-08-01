using AppData.Models;

namespace AppData.Models
{
    public class CartDetail
    {
        private readonly DBContextModel _dbContext;
        private Guid? _detailProductID;
        private Guid? _idCombo;

        public CartDetail()
        {
            _dbContext = new DBContextModel();
        }

        public Guid Id { get; set; }
        public Guid UserID { get; set; }
        public Guid? DetailProductID
        {
            get => _detailProductID;
            set
            {
                if (value.HasValue)
                {
                    var productDetail = _dbContext.ProductDetails.FirstOrDefault(x => x.Id == value.Value);

                    if (productDetail != null)
                    {
                        _detailProductID = value.Value;
                        return;
                    }
                    IdCombo = value;
                    return;
                }
                _detailProductID = null;

            }
        }
        public Guid? IdCombo
        {
            get => _idCombo;
            set
            {
                if (value.HasValue)
                {
                    var comBo = _dbContext.Combos.FirstOrDefault(x => x.Id == value.Value);

                    if (comBo != null)
                    {
                        _idCombo = value.Value;
                        return;
                    }
                    DetailProductID = value;
                    return;
                }
                _idCombo = null;
            }
        }
        public int Soluong { get; set; }
        public decimal Dongia { get; set; }
        public virtual Cart? Cart { get; set; }
        public virtual ProductDetail? ProductDetail { get; set; }
        public virtual Combo? Combo { get; set; }
    }
}
