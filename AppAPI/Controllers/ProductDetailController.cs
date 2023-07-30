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
            return DBContextModel.ProductDetails.FirstOrDefault(x=>x.Id == id);
        }
        [HttpGet]
        public async Task<IEnumerable<ProductDetail>> Get()
        {
            return await DBContextModel.ProductDetails.ToListAsync();
        }
        [HttpPost]
        public async void Create(Guid Id,string ma,string ten,string loai,string anh)
        {
            ProductDetail productDetail = new ProductDetail()
            { 
                Id = Id,
                Anh = anh,
                Ma = ma,
                Ten = ten,
                Loai = loai

            };
            DBContextModel.ProductDetails.Add(productDetail);
            DBContextModel.SaveChanges();
        }
        [HttpPut]
        public async void Update(Guid Id, string ma, string ten, string loai, string anh)
        {

            var a = DBContextModel.ProductDetails.Find(Id);
            a.Ma= ma;
            a.Ten= ten;
                a.Loai= loai;
            a.Anh= anh;
            DBContextModel.ProductDetails.Update(a);
            DBContextModel.SaveChanges();
        }
        [HttpDelete]
        public async void Delete(Guid Id)
        {
            var a = DBContextModel.ProductDetails.Find(Id);
            DBContextModel.ProductDetails.Remove(a);
            DBContextModel.SaveChanges();
        }
    }
}
