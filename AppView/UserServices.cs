using AppData.Models;
using Newtonsoft.Json;
using System.Net;

namespace AppView
{
    public class UserServices:IUserServices
    {
        public async Task<bool> Add(User user)
        {
            var httpClient = new HttpClient();
            string apiUrl ="";
            try
            {
                var response = await httpClient.PostAsync(apiUrl, null);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm người dùng: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> Delete(Guid id)
        {
            var httpClient = new HttpClient();
            string apiUrl = $"https://localhost:7280/api/User/Delete-User?id={id}";
            var response = await httpClient.DeleteAsync(apiUrl);
            return true;
        }

        public async Task<bool> Edit(User user)
        {
            var httpClient = new HttpClient();
            string apiUrl = $"";
            var response = await httpClient.PutAsync(apiUrl, null);
            return true;
        }

        public async Task<List<User>> GetAll()
        {
            string apiUrl = "https://localhost:7280/api/User";
            var httpClient = new HttpClient(); // tạo ra để callApi
            var response = await httpClient.GetAsync(apiUrl);
            // Lấy dữ liệu Json trả về từ Api được call dạng string
            string apiData = await response.Content.ReadAsStringAsync();
            // Đọc từ string Json vừa thu  được sang List<T>
            var users = JsonConvert.DeserializeObject<List<User>>(apiData);
            return users;
        }

        public Task<bool> GetByID(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByLogin(string taikhoan, string matkhau)
        {
            var httpClient = new HttpClient();
            //string apiUrl = $"https://localhost:7280/api/User/GetUserByName?taikhoan={taikhoan}&matkhau={matkhau}";
            string apiUrl = $"";
            var response = await httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<User>(apiData);
            return users;
        }

        public async Task<List<User>> GetByName(string name)
        {
            var httpClient = new HttpClient();
            string apiUrl = $"https://localhost:7280/api/User/name?name={name}";
            var response = await httpClient.PutAsync(apiUrl, null);
            string apiData = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<User>>(apiData);
            return users;
        }
    }
}
