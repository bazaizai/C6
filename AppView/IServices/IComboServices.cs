using AppData.Models;

namespace AppView.IServices
{
    public interface IComboServices
    {
        Task<List<Combo>> GetAllCombo();
        Task<Combo> GetComboByKey(Guid id);
        Task DeleteCombo(Guid id);
        Task UpdateCombo(Combo entity);
        Task AddCombo(Combo entity);
    }
}
