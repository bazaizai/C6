using AppData.Models;
using Newtonsoft.Json;
using System.Net;

namespace AppView
{
    public class UserServices : IUserServices
    {
        public async Task<bool> Add(User p)
        {
            var httpClient = new HttpClient();
            p.IdRole = Guid.Parse("5B6E9FC7-1E70-4FD4-0448-B983316B8374");
            string apiUrl = $"https://localhost:7075/api/User?ten={p.Ten}&IdRole={p.IdRole}&Ma={p.Ma}&DiaChi={p.DiaChi}&Sdt={p.Sdt}&MatKhau={p.MatKhau}&Email={p.Email}";
            var response = await httpClient.PostAsync(apiUrl, null);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            else return false;


        }
        public async Task<bool> Delete(Guid id)
        {
            string apiUrl = $"https://localhost:7075/api/User/{id}";
            var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else return false;
        }

        public async Task<bool> Edit(User p)
        {
            string apiUrl = $"https://localhost:7075/api/User/{p.Id}?ten={p.Ten}&IdRole={p.IdRole}&Ma={p.Ma}&DiaChi={p.DiaChi}&Sdt={p.Sdt}&MatKhau={p.MatKhau}&Email={p.Email}";
            var httpClient = new HttpClient();

            var content = new StringContent(string.Empty);

            var response = await httpClient.PutAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            else return false;
        }

        public async Task<List<User>> GetAll()
        {
            string apiUrl = "https://localhost:7075/api/User";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<User>>(apiData);
            return users;
        }

        public async Task<User> GetByID(Guid id)
        {
            return (await GetAll()).FirstOrDefault(x => x.Id == id);
        }

        public async Task<User> GetByLogin(string taikhoan, string matkhau)
        {
            var httpClient = new HttpClient();
            string apiUrl = $"https://localhost:7075/api/User/GetUserLogin?email={taikhoan}&matkhau={matkhau}";
            var response = await httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<User>(apiData);
            return users;
        }

        public async Task<List<User>> GetByName(string name)
        {
            var httpClient = new HttpClient();
            string apiUrl = $"https://localhost:7075/api/User/GetUserByName?name={name}";
            var response = await httpClient.PutAsync(apiUrl, null);
            string apiData = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<User>>(apiData);
            return users;
        }
    }
}
