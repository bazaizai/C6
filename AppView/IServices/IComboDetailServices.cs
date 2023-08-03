using AppData.Models;

namespace AppView.IServices
{
    public interface IComboDetailServices
    {
        Task<List<ComboDetail>> GetComboDetail();
        Task<ComboDetail> GetComboDetailByKey(Guid id);
        Task DeleteComboDetail(Guid id);
        Task UpdateComboDetail(ComboDetail entity);
        Task AddComboDetail(ComboDetail entity);
    }
}
