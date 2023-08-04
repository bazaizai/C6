using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly DBContextModel _dbContext;
        public BillController()
        {
            _dbContext = new DBContextModel();
        }
        // GET: api/<BillController>
        [HttpGet]
        public async Task<IEnumerable<BillViewModel>> GetBill()
        {
            return (await _dbContext.Bills.ToListAsync()).Select(c => new BillViewModel
            {
                Id = c.Id,
                Ma = c.Ma,
                IdUser = c.IdUser,
                TenNV = _dbContext.Users.ToList().FirstOrDefault(a => a.Id == c.IdUser).Ten,
                NgayTao = c.NgayTao,
                DiaChi = c.DiaChi,
                NgayThanhToan = c.NgayThanhToan,
                Sdt = c.Sdt,
                TienShip = c.TienShip,
            });
        }

        // GET api/<BillController>/5
        [HttpGet("GetBillByID")]
        public async Task<Bill> GetBillByID(Guid id)
        {
            return await _dbContext.Bills.FirstOrDefaultAsync(c => c.Id == id);
        }

        // POST api/<BillController>
        [HttpPost]
        public async void CreateBill(Bill obj)
        {

            //if (_dbContext.Bills.Count() == null)
            //{
            //    obj.Ma = "Bill1";
            //}
            //else
            //{
            //    obj.Ma = "Bill" + (_dbContext.Bills.Count() + 1);
            //}
            Bill bill = new Bill()
            {
                Id = Guid.NewGuid(),
                IdUser = obj.IdUser,
                Ma = obj.Ma,
                NgayTao = obj.NgayTao,
                NgayThanhToan = obj.NgayThanhToan,
                DiaChi = obj.DiaChi,
                Sdt = obj.DiaChi,
                TienShip = obj.TienShip,
            };
            _dbContext.Bills.Add(bill);
            _dbContext.SaveChanges();
        }

        // PUT api/<BillController>/5
        [HttpPut("Update")]
        public async void PutAsync(Bill obj)
        {
            var bill = (await _dbContext.Bills.ToListAsync()).First(p => p.Id == obj.Id);
            bill.IdUser = obj.IdUser;
            bill.Ma = obj.Ma;
            bill.NgayTao = obj.NgayTao;
            bill.NgayThanhToan = obj.NgayThanhToan;
            bill.DiaChi = obj.DiaChi;
            bill.Sdt = obj.Sdt;
            bill.TienShip = obj.TienShip;
            _dbContext.Bills.Update(bill);
            await _dbContext.SaveChangesAsync();
        }

        // DELETE api/<BillController>/5
        [HttpDelete("Delete")]
        public async void Delete(Guid id)
        {
            var bill = (await _dbContext.Bills.ToListAsync()).First(p => p.Id == id);
            _dbContext.Bills.Remove(bill);
            await _dbContext.SaveChangesAsync();
        }
    }
}
