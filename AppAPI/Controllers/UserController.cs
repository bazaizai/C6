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
        DBContextModel context = new DBContextModel();
        DbSet<User> user;
        private DbSet<User> dbset;
        public UserController()
        {
            user = context.Users;
            dbset = context.Set<User>();
        }
        // GET: api/<userController>
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return dbset.ToList();
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
            dbset.Add(user);
            context.SaveChanges();
            return true;
        }

        [HttpPut("{id}")]
        public bool Put(Guid id, string ten, Guid IdRole, string Ma, string DiaChi, string Sdt, string MatKhau, string Email)
        {
            var user = dbset.ToList().First(p => p.Id == id);
            user.Ten = ten;
            user.IdRole = IdRole;
            user.Ma = Ma;
            user.DiaChi= DiaChi;
            user.Sdt = Sdt;
            user. MatKhau = MatKhau;
            user.Email = Email; 
            dbset.Update(user);
            context.SaveChanges();
            return true;
        }

        // DELETE api/<SaleController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var user = dbset.ToList().First(p => p.Id == id);
            dbset.Remove(user);
            context.SaveChanges();
            return true;
        }
    }
}
