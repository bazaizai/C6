using AppData.Models;
using AppData.ViewModes.CartDetail;
using AppView.IServices;
using System.Net.Http.Json;

namespace AppView.Services
{
    public class CartDetailService : ICartDetailService
    {
        private HttpClient _httpClient;

        public CartDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AddEntity(CartDetail entity)
        {
            return await (await _httpClient.PostAsJsonAsync("api/CartDetail",entity)).Content.ReadFromJsonAsync<bool>();
        }

        public async Task<bool> DeleteEntity(Guid id)
        {
            string url = $"api/CartDetails/{id}";
            var response = await _httpClient.DeleteAsync(url);
            return await response.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<CartDetail> GetEntityByKey(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<CartDetail>($"api/CartDetails/{id}");
        }

        public async Task<IEnumerable<CartDetailViewModel>> GetListEntity(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CartDetailViewModel>>($"api/CartDetails/list-cartdetail/{id}");
        }

        public async Task<bool> UpdateEntity(CartDetail entity)
        {
            return await (await _httpClient.PutAsJsonAsync($"api/CartDetails/{entity.Id}",entity)).Content.ReadFromJsonAsync<bool>();
        }
    }
}
