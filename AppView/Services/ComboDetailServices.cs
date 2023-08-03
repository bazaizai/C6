using AppData.Models;
using AppView.IServices;
using System.Net.Http.Json;

namespace AppView.Services
{
    public class ComboDetailServices : IComboDetailServices
    {
        public async Task AddComboDetail(ComboDetail entity)
        {
            HttpClient httpClient = new HttpClient();
            var reponse = await httpClient.PostAsync($"https://localhost:7075/api/ComboDetail?IdCombo={entity.IdCombo}&IdProduct={entity.IdProductDetail}&giaBan={entity.GiaBan}", null);
        }

        public async Task DeleteComboDetail(Guid id)
        {
            HttpClient httpClient = new HttpClient();
            var reponse = await httpClient.DeleteAsync($"https://localhost:7075/api/ComboDetail/{id}");
        }

        public async Task<List<ComboDetail>> GetComboDetail()
        {
            HttpClient httpClient = new HttpClient();
            return await httpClient.GetFromJsonAsync<List<ComboDetail>>($"https://localhost:7075/api/ComboDetail");
        }

        public async Task<ComboDetail> GetComboDetailByKey(Guid id)
        {
            HttpClient httpClient = new HttpClient();
            return await httpClient.GetFromJsonAsync<ComboDetail>($"https://localhost:7075/api/ComboDetail/{id}");
        }

        public async Task UpdateComboDetail(ComboDetail entity)
        {
            HttpClient httpClient = new HttpClient();
            var reponse = await httpClient.PutAsync($"https://localhost:7075/api/ComboDetail/{entity.Id}?idCombo={entity.IdCombo}&idProduct={entity.IdProductDetail}&giaBan={entity.GiaBan}", null);
        }
    }
}
