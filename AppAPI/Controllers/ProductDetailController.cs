using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private DBContextModel DBContextModel;

        public ProductDetailController()
        {
            DBContextModel = new DBContextModel();

        }
        [HttpGet("{id}")]
        public ProductDetail Get(Guid id)
        {
            return DBContextModel.ProductDetails.FirstOrDefault(x => x.Id == id);
        }
        [HttpGet("list")]
        public async Task<IEnumerable<ProductDetail>> Get()
        {
            return await DBContextModel.ProductDetails.ToListAsync();
        }
        [HttpPost]
        public async void Create(Guid Id,string ma,string ten,string loai,string anh, int giaBan)
        {
            ProductDetail productDetail = new ProductDetail()
            { 
                Id = Id,
                Anh = anh,
                Ma = ma,
                Ten = ten,
                Loai = loai, 
                GiaBan = giaBan
            };
            DBContextModel.ProductDetails.Add(productDetail);
            DBContextModel.SaveChanges();
        }
        [HttpPut]
        public async void Update(Guid Id, string ma, string ten, string loai, string anh, int giaBan)
        {

            var a = DBContextModel.ProductDetails.Find(Id);
            a.Ma= ma;
            a.Ten= ten;
                a.Loai= loai;
            a.Anh= anh;
            a.GiaBan= giaBan;
            DBContextModel.ProductDetails.Update(a);
            DBContextModel.SaveChanges();
        }
        [HttpDelete("{id}")]
        public async void Delete(Guid Id)
        {
            var a = DBContextModel.ProductDetails.Find(Id);
            DBContextModel.ProductDetails.Remove(a);
            DBContextModel.SaveChanges();
        }
    }
}
