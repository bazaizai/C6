using AppData.Models;
using AppView.IServices;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Net.Http;
using System.Net.Http.Json;

namespace AppView.Services
{
    public class ProductDetailService : IProductDetailService
    {
        HttpClient _httpClient;
        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> Add(ProductDetail productDetail)
        {
            return await(await _httpClient.PostAsJsonAsync($"https://localhost:7075/api/ProductDetail?Id={productDetail.Id}&ma={productDetail.Ma}&ten={productDetail.Ten}&loai={productDetail.Loai}&anh={productDetail.Anh}&giaBan={productDetail.GiaBan}", productDetail)).Content.ReadFromJsonAsync<bool>();
        }

        public async Task<bool> DeleteById(Guid id)
        {
            return await(await _httpClient.DeleteAsync($"api/ProductDetail/{id}")).Content.ReadFromJsonAsync<bool>();
        }

        public async Task<List<ProductDetail>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<List<ProductDetail>>("api/ProductDetail/list");
        }

        public async Task<ProductDetail> GetById(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<ProductDetail>($"api/ProductDetail/{id}");
        }

        public async Task<bool> Update(ProductDetail productDetail)
        {
            string apiUrl = $"https://localhost:7075/api/ProductDetail?Id={productDetail.Id}&ma={productDetail.Ma}&ten={productDetail.Ten}&loai={productDetail.Loai}&anh={productDetail.Anh}&giaBan={productDetail.GiaBan}\r\n";
            var httpClient = new HttpClient();
            var response = await httpClient.PutAsync(apiUrl, null);

            return true;//await(await _httpClient.PutAsJsonAsync($"https://localhost:7075/api/ProductDetail?Id={productDetail.Id}&ma={productDetail.Ma}&ten={productDetail.Ten}&loai={productDetail.Loai}&anh={productDetail.Anh}&giaBan={productDetail.GiaBan}",productDetail)).Content.ReadFromJsonAsync<bool>();
        }
    }
}
