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
        public async Task<IEnumerable<Bill>> GetBill()
        {
            return await _dbContext.Bills.ToListAsync();
        }

        // GET api/<BillController>/5
        [HttpGet("GetBillByID")]
        public async Task<Bill> GetBillByID(Guid id)
        {
            return await _dbContext.Bills.FirstOrDefaultAsync(c => c.Id == id);
        }

        // POST api/<BillController>
        [HttpPost]
        public async void CreateBill(Guid idUser, string ma, DateTime ngayTao, DateTime ngayThanhToan,
         string diaChi, string sdt, int tienShip)
        {

            if (_dbContext.Bills.Count() == null)
            {
                ma = "Bill1";
            }
            else
            {
                ma = "Bill" + (_dbContext.Bills.Count() + 1);
            }
            Bill bill = new Bill()
            {
                Id = Guid.NewGuid(),
                IdUser = idUser,
                Ma = ma,
                NgayTao = ngayTao,
                NgayThanhToan = ngayThanhToan,
                DiaChi = diaChi,
                Sdt = sdt,
                TienShip = tienShip,
            };
            _dbContext.Bills.Add(bill);
            _dbContext.SaveChanges();
        }

        // PUT api/<BillController>/5
        [HttpPut("Update")]
        public async void PutAsync(Guid id, Guid idUser, string ma, DateTime ngayTao, DateTime ngayThanhToan,
         string diaChi, string sdt, int tienShip)
        {
            var bill = (await _dbContext.Bills.ToListAsync()).First(p => p.Id == id);
            bill.IdUser = idUser;
            bill.Ma = ma;
            bill.NgayTao = ngayTao;
            bill.NgayThanhToan = ngayThanhToan;
            bill.DiaChi = diaChi;
            bill.Sdt = sdt;
            bill.TienShip = tienShip;
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
