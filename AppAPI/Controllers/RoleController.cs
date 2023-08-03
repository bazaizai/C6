using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        DBContextModel context = new DBContextModel();
        DbSet<Role> role;
        private DbSet<Role> dbset;
        public RoleController()
        {
            role = context.Roles;
            dbset = context.Set<Role>();
        }
        // GET: api/<RoleController>
        [HttpGet]
        public IEnumerable<Role> GetAll()
        {
            return dbset.ToList();
        }

        [HttpPost]

        public bool Create( string ten, int trangthai)
        {
            Role role = new Role();
            role.Ten = ten;
            role.TrangThai = trangthai;
            role.Id = Guid.NewGuid();
            dbset.Add(role);
            context.SaveChanges();
            return true;
        }

        [HttpPut("{id}")]
        public bool Put(Guid id, string ten, int trangthai)
        {
            var role = dbset.ToList().First(p => p.Id == id);
            role.Ten = ten;
            role.TrangThai = trangthai;
            dbset.Update(role);
            context.SaveChanges();
            return true;
        }

        // DELETE api/<SaleController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var role = dbset.ToList().First(p => p.Id == id);
            dbset.Remove(role);
            context.SaveChanges();
            return true;
        }


    }
}
