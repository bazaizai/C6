using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillDetailsController : ControllerBase
    {
        private readonly DBContextModel _dbcontext;
        public BillDetailsController()
        {
            _dbcontext = new DBContextModel();
        }
        // GET: api/<BillDetailsController>
        [HttpGet]
        public async Task<IEnumerable<BillDetail>> Get()
        {
            return await _dbcontext.BillDetails.ToListAsync();
        }

        [HttpGet("GetBillDetails/{id}")]
        public BillDetail GetBillDetailbyID(Guid id)
        {
            return _dbcontext.BillDetails.ToList().FirstOrDefault(x => x.Id == id);
        }

        [HttpGet("idBill/{id}")]
        public IEnumerable<BillDetailsViewModel> GetByBill(Guid id)
        {
            var billDetails = _dbcontext.BillDetails.Where(c => c.IdBill == id)
                .Include(c => c.Bill).Include(c => c.ProductDetail).Include(c => c.Combo).ToList();
            var result = billDetails.Select(c => new BillDetailsViewModel()
            {
                Id = c.Id,
                MaBill = c.Bill.Ma,
                TenMonAn = c.ProductDetail.Ten,
                Anh = c.ProductDetail.Anh,
                Combo = c.Combo.Ten,
                SoLuong = c.SoLuong,
                DonGia = c.DonGia
            });
            return result;
        }

        // POST api/<BillDetailsController>
        [HttpPost("Add")]
        public string Post(Guid IdBill, Guid IdProduct, Guid? IdCombo, int soluong, decimal dongia)
        {
            // Tạo một đối tượng mới
            var billDetail = new BillDetail()
            {
                Id = new Guid(),
                IdBill = IdBill,
                IdProductDetail = IdProduct,
                IdCombo = IdCombo,
                SoLuong = soluong,
                DonGia = dongia
            };

            // Thêm đối tượng mới vào bảng BillDetail
            _dbcontext.BillDetails.Add(billDetail);
            _dbcontext.SaveChanges();

            return "Success";
        }

        // PUT api/<BillDetailsController>/5
        [HttpPut("{id}")]
        public string Put(Guid id, Guid IdBill, Guid IdProduct, Guid? IdCombo, int soluong, decimal dongia)
        {
            var billDetail = _dbcontext.BillDetails.Find(id);
            if (billDetail == null)
            {
                return "BillDetails không tồn tại";
            }
            // Sửa
            billDetail.IdBill = IdBill;
            billDetail.IdProductDetail = IdProduct;
            billDetail.IdCombo = IdCombo;
            billDetail.SoLuong = soluong;
            billDetail.DonGia = dongia;
            // Đánh dấu đối tượng BillDetail là "được sửa đổi" 
            _dbcontext.Entry(billDetail).State = EntityState.Modified;
            _dbcontext.SaveChanges();

            return "Success";
        }
        // DELETE api/<BillDetailsController>/5
        [HttpDelete("Delete/{id}")]
        public string Delete(Guid id)
        {
            var billDetail = _dbcontext.BillDetails.Find(id);
            if (billDetail == null)
            {
                return "BillDetails không tồn tại";
            }
            _dbcontext.BillDetails.Remove(billDetail);
            _dbcontext.SaveChanges();
            return "Success";
        }
    }
}
