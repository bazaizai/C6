using AppData.Models;

namespace AppView.IServices
{
    public interface IProductDetailService
    {
        public Task<List<ProductDetail>> GetAll();
        public Task<ProductDetail> GetById(Guid id);
        public Task<bool> Add(ProductDetail productDetail);
        public Task<bool> Update(ProductDetail productDetail);
        public Task<bool> DeleteById(Guid id);
    }
}
