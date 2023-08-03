using AppData.Models;
using AppView.IServices;
using System.Net.Http.Json;

namespace AppView.Services
{
    public class ComboServices:IComboServices
    {
        public ComboServices()
        {
        }

        public async Task AddCombo(Combo entity)
        {
            HttpClient httpClient = new HttpClient();
            var reponse =  await httpClient.PostAsync($"https://localhost:7075/api/Combo?ten={entity.Ten}&ma={entity.Ma}", null);
        }

        public async Task DeleteCombo(Guid id)
        {
            HttpClient httpClient = new HttpClient();
            var reponse = await httpClient.DeleteAsync($"https://localhost:7075/api/Combo/{id}");
        }

        public async Task<List<Combo>> GetAllCombo()
        {
            HttpClient httpClient = new HttpClient();
            return await httpClient.GetFromJsonAsync<List<Combo>>($"https://localhost:7075/api/Combo");
        }

        public async Task<Combo> GetComboByKey(Guid id)
        {
            HttpClient httpClient = new HttpClient();
            return await httpClient.GetFromJsonAsync<Combo>($"https://localhost:7075/api/Combo/{id}");
        }

        public async Task UpdateCombo(Combo entity)
        {
            HttpClient httpClient = new HttpClient();
            var reponse = await httpClient.PutAsync($"https://localhost:7075/api/Combo/{entity.Id}?ma={entity.Ma}&ten={entity.Ten}", null);
        }
    }
}
