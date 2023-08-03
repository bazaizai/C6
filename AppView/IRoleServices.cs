using AppData.Models;

namespace AppView
{
    public interface IRoleServices
    {
        public Task<List<Role>> GetAllRole();

        public Task<List<Role>> GetByName(string name);
        public Task<bool> GetByID(Guid id);
        public Task<bool> Edit(Role P);
        public Task<bool> Add(Role p);
        public Task<bool> Delete(Guid id);
    }
}
