using AppData.Models;
using AppData.ViewModes.CartDetail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartDetailsController : ControllerBase
    {
        private readonly DBContextModel _dbContext;
        public CartDetailsController()
        {
            _dbContext = new DBContextModel();
        }
        [HttpGet("{Id}")]
        public async Task<CartDetail> GetEntityAynsc(Guid Id)
        {
            return ((await _dbContext.CartDetails.ToListAsync()).FirstOrDefault(x => x.Id == Id));
        }

        [HttpGet("list-cartdetail/{id}")]
        public async Task<IEnumerable<CartDetailViewModel>> GetListEntityAynsc(Guid id)
        {
            return (await _dbContext.CartDetails.ToListAsync()).Where(item=>item.UserID==id).Select(item => new CartDetailViewModel
            {
                Id = item.Id,
                Dongia = item.Dongia,
                Name = item.IdCombo == null ? _dbContext.ProductDetails.FirstOrDefault(x => x.Id == item.DetailProductID).Ten : _dbContext.Combos.FirstOrDefault(x => x.Id == item.IdCombo).Ten,
                SoLuong = item.Soluong,
                Sum = item.Soluong * item.Dongia
            }) ;
        }

        [HttpPost]
        public async Task<bool> AddEntityAsync(CartDetail entity)
        {
            try
            {
                await _dbContext.CartDetails.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPut]
        public async Task<bool> UpdateEntityAsync(CartDetail entity)
        {
            try
            {
                _dbContext.CartDetails.Update(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpDelete("{Id}")]
        public async Task<bool> DeleteEntityAsync(Guid Id)
        {
            try
            {
                var obj = await GetEntityAynsc(Id);
                _dbContext.CartDetails.Remove(obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
