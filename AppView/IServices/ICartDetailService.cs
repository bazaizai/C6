using AppData.Models;
using AppData.ViewModes.CartDetail;

namespace AppView.IServices
{
    public interface ICartDetailService
    {
        Task<IEnumerable<CartDetailViewModel>> GetListEntity(Guid id);
        Task<CartDetail> GetEntityByKey(Guid id);
        Task<bool> DeleteEntity(Guid id);
        Task<bool> UpdateEntity(CartDetail entity);
        Task<bool> AddEntity(CartDetail entity);
    }
}
