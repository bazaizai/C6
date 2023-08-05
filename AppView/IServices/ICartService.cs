using AppData.Models;
using AppData.ViewModes.CartDetail;

namespace AppView.IServices
{
    public interface ICartService
    {
        Task<IEnumerable<Cart>> GetListEntity(Guid id);
        Task<Cart> GetEntityByKey(Guid id);
        Task<bool> DeleteEntity(Guid id);
        Task<bool> UpdateEntity(Cart entity);
        Task<bool> AddEntity(Cart entity);
    }
}
