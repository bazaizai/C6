using AppData;
using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepo<User> repos;
        DBContextModel dbContextModel = new DBContextModel();
        DbSet<User> Users;
        public UserController()
        {
            Users = dbContextModel.Users;        
            Repo<User> all = new Repo<User>(dbContextModel, Users);    
            repos = all;
            
        }
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return repos.GetAll();
        }

        [HttpPost]

        public bool Create(string ten, Guid IdRole, string Ma, string DiaChi , string Sdt, string MatKhau, string Email)
        {
            User user = new User();
            user.IdRole = IdRole;
            user.Ten = ten;
            user.Ma = Ma;
            user.DiaChi = DiaChi;
            user.Sdt = Sdt;
            user.MatKhau = MatKhau;
            user.Email = Email;
            user.Id = Guid.NewGuid();
            return repos.AddItem(user);
        }

        [HttpPut("{id}")]
        public bool Edit(Guid id, string ten, Guid IdRole, string Ma, string DiaChi, string Sdt, string MatKhau, string Email)
        {
            var user =repos.GetAll().First(p => p.Id == id);
            user.Ten = ten;
            user.IdRole = IdRole;
            user.Ma = Ma;
            user.DiaChi= DiaChi;
            user.Sdt = Sdt;
            user. MatKhau = MatKhau;
            user.Email = Email;
            return repos.EditItem(user);
        }

        // DELETE api/<SaleController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var user = repos.GetAll().First(p => p.Id == id);
            return repos.RemoveItem(user);
        }
        [HttpGet("GetUserLogin")]
        public User GetUserByLogin(string email, string matkhau)
        {
            return repos.GetAll().FirstOrDefault(c => c.Email == email && c.MatKhau == matkhau);
        }
    }
}
