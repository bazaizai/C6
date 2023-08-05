using AppData.Models;
using AppView.Services;

namespace AppView.IServices
{
    public interface IBillServices
    {
        Task<List<BillViewModel>> GetBill();
        Task<Bill> GetBillByKey(Guid id);
        Task DeleteBill(Guid id);
        Task UpdateBill(Bill entity);
        Task AddBill(Bill entity);
    }
}
