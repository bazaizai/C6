using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly DBContextModel _dbContext;
        public CartsController()
        {
            _dbContext = new DBContextModel();
        }
        [HttpGet]
        public async Task<Cart> GetEntityAynsc(Guid Id)
        {
            return (await _dbContext.Carts.ToListAsync()).FirstOrDefault(x => x.UserID == Id);
        }

        [HttpGet("list-cart")]
        public async Task<IEnumerable<Cart>> GetListEntityAynsc()
        {
            return await _dbContext.Carts.ToListAsync();
        }

        [HttpPost]
        public async Task<bool> AddEntityAsync(Cart entity)
        {
            try
            {
                await _dbContext.Carts.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPut]
        public async Task<bool> UpdateEntityAsync(Cart entity)
        {
            try
            {
                 _dbContext.Carts.Update(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpDelete]
        public async Task<bool> DeleteEntityAsync(Guid Id)
        {
            try
            {
                _dbContext.Carts.Remove(await GetEntityAynsc(Id));
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
