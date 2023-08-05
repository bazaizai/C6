using AppData.Models;
using Newtonsoft.Json;

namespace AppView
{
    public class RoleServices : IRoleServices
    {
        public async Task<bool> Add(Role p)
        {
            string apiUrl = $"https://localhost:7075/api/Role?ten={p.Ten}&trangthai={p.TrangThai}";
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsync(apiUrl, null);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else return false;
        }


        public async Task<bool> Delete(Guid id)
        {
            string apiUrl = $"https://localhost:7075/api/Role/{id}";
            var httpClient = new HttpClient();
            var response = await httpClient.DeleteAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else  return false;

        }

        public async Task<bool> Edit(Role p)
        {
            string apiUrl = $"https://localhost:7075/api/Role/{p.Id}?ten={p.Ten}&trangthai={p.TrangThai}";
            var httpClient = new HttpClient();
            var content = new StringContent(string.Empty);
            var response = await httpClient.PutAsync(apiUrl, content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else return false;
        }


        public async Task<List<Role>> GetAllRole()
        {
            string apiUrl = "https://localhost:7075/api/Role";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var p = JsonConvert.DeserializeObject<List<Role>>(apiData);
            return p;
        }

        public async Task<Role> GetByID(Guid id)
        {
            return (await GetAllRole()).FirstOrDefault(x => x.Id == id);
        }

    }
}
