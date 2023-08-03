using AppData.Models;
using AppView.IServices;
using System.Net.Http;
using System.Net.Http.Json;

namespace AppView.Services
{
    public class BillServices : IBillServices
    {
        private HttpClient HttpClient;

        public BillServices(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task AddBill(Bill entity)
        {
            await HttpClient.PostAsJsonAsync("https://localhost:7075/api/Bill", entity);
        }

        public async Task DeleteBill(Guid id)
        {
            await HttpClient.DeleteAsync($"https://localhost:7075/api/Bill/Delete?id={id}");
        }

        public async Task<List<BillViewModel>> GetBill()
        {
            return await HttpClient.GetFromJsonAsync<List<BillViewModel>>("https://localhost:7075/api/Bill");
        }

        public async Task<Bill> GetBillByKey(Guid id)
        {
            return await HttpClient.GetFromJsonAsync<Bill>($"https://localhost:7075/api/Bill/GetBillByID?id={id}");
        }

        public async Task UpdateBill(Bill entity)
        {
            await HttpClient.PutAsJsonAsync("https://localhost:7075/api/Bill/Update", entity);
        }
    }
}
