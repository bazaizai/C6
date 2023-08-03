using AppData.Models;

namespace AppView
{
    public interface IUserServices
    {
        public Task<List<User>> GetAll();
       
        public Task<bool> GetByID(Guid id);
        public Task<User> GetByLogin(string Email, string matkhau);
        public Task<List<User>> GetByName(string name);
        public Task<bool> Add(User user);
        public Task<bool> Edit(User user);
        public Task<bool> Delete(Guid id);
    }
}
