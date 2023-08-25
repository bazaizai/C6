using AppData.Models;
using AppView.IServices;
using System.Net.Http.Json;

namespace AppView.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient _httpClient;

        public CartService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AddEntity(Cart entity)
        {
            try
            {
                return await (await _httpClient.PostAsJsonAsync("api/Carts", entity)).Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteEntity(Guid id)
        {
            try
            {
                return await (await _httpClient.DeleteAsync("api/Carts" + id)).Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<Cart> GetEntityByKey(Guid id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Cart>("api/Carts" + id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<IEnumerable<Cart>> GetListEntity(Guid id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Cart>>("api/Carts/list-cart");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<bool> UpdateEntity(Cart entity)
        {
            try
            {
                return await(await _httpClient.PutAsJsonAsync("api/Carts",entity)).Content.ReadFromJsonAsync<bool>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
