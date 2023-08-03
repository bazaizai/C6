using AppData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComboDetailController : ControllerBase
    {
        private DBContextModel context;
        public ComboDetailController()
        {
            context = new DBContextModel();
        }

        // GET: api/<ComboDetailController>
        [HttpGet]
        public IEnumerable<ComboDetail> Get()
        {
            return context.comboDetails.ToList();
        }

        // GET api/<ComboDetailController>/5
        [HttpGet("{id}")]
        public List<ComboDetail> Get(Guid id)
        {
            return context.comboDetails.Where(c=>c.IdCombo == id).ToList();
        }

        // POST api/<ComboDetailController>
        [HttpPost]
        public bool Post(Guid IdCombo, Guid IdProduct, int giaBan )
        {
            try
            {
                ComboDetail comboDetail = new ComboDetail() { Id = Guid.NewGuid(), IdCombo = IdCombo, IdProductDetail = IdProduct, GiaBan = giaBan };
                context.comboDetails.Add(comboDetail);
                context.SaveChanges();
                return true;


            }
            catch (Exception)
            {
                return false;
            }
        }

        // PUT api/<ComboDetailController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, Guid idCombo, Guid idProduct, int giaBan)
        {
            try
            {
                var comboDetail = context.comboDetails.FirstOrDefault(c => c.Id == id);
                comboDetail.IdProductDetail = idProduct;
                comboDetail.IdCombo = idCombo;
                comboDetail.GiaBan = giaBan;
                context.comboDetails.Update(comboDetail);
                context.SaveChanges();
                return true;


            }
            catch (Exception)
            {
                return false;
            }
        }

        // DELETE api/<ComboDetailController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            try
            {
                var comboDetail = context.comboDetails.FirstOrDefault(c => c.Id == id);
                context.comboDetails.Remove(comboDetail);
                context.SaveChanges();
                return true;


            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
