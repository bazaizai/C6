using AppData.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace AppView.IServices
{
    public interface IBillDetailsServices
    {
        public Task<IEnumerable<BillDetail>> GetListBillDetails();
        public Task<IEnumerable<BillDetailsViewModel>> GetBillDetailsByIdBill(Guid id);
        public Task<BillDetail> GetBillDetailsById(Guid id);
        public Task<bool> DeleteBillDetails(Guid id);
        public Task<bool> UpdateBillDetails(BillDetail entity);
        public Task<bool> AddBilldetails(BillDetail entity);
    }
}
