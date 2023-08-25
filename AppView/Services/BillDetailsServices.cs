using AppData.Models;
using AppView.IServices;
using System.Net.Http.Json;

namespace AppView.Services
{
    public class BillDetailsServices : IBillDetailsServices
    {
        public HttpClient _httpClient;
        public BillDetailsServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> AddBilldetails(BillDetail obj)
        {

            var httpClient = new HttpClient();
            string apiUrl = $"https://localhost:7075/api/BillDetails/Add?IdBill={obj.IdBill}&IdProduct={obj.IdProductDetail}&IdCombo={obj.IdCombo}&soluong={obj.SoLuong}&dongia={obj.DonGia}\r\n";
            var response = await httpClient.PostAsync(apiUrl, null);
            return true;
        }

        public async Task<bool> DeleteBillDetails(Guid id)
        {
            var httpClient = new HttpClient();
            string apiUrl = $"https://localhost:7075/api/BillDetails/Delete/{id}";
            var response = await httpClient.DeleteAsync(apiUrl);
            return true;
        }

        public Task<BillDetail> GetBillDetailsById(Guid id)
        {
            return _httpClient.GetFromJsonAsync<BillDetail>($"https://localhost:7075/api/BillDetails/GetBillDetails/{id}");
        }

        public async Task<IEnumerable<BillDetailsViewModel>> GetBillDetailsByIdBill(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<List<BillDetailsViewModel>>($"api/BillDetails/idBill/{id}");
        }

        public async Task<IEnumerable<BillDetail>> GetListBillDetails()
        {
            return await _httpClient.GetFromJsonAsync<List<BillDetail>>("api/BillDetails");
        }

        public async Task<bool> UpdateBillDetails(BillDetail obj)
        {
            string apiUrl = $"https://localhost:7075/api/BillDetails/{obj.Id}?IdBill={obj.IdBill}&IdProduct={obj.IdProductDetail}&IdCombo={obj.IdCombo}&soluong={obj.SoLuong}&dongia={obj.DonGia}\r\n";
            var httpClient = new HttpClient();
            var response = await httpClient.PutAsync(apiUrl, null);
            return true;
        }
    }
}
