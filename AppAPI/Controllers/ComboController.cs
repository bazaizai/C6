using AppData.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComboController : ControllerBase
    {
        private DBContextModel context;
        public ComboController()
        {
            context = new DBContextModel();
        }

        // GET: api/<ComboController>
        [HttpGet]
        public IEnumerable<Combo> Get()
        {
            return context.Combos.ToList();
        }

        // GET api/<ComboController>/5
        [HttpGet("{id}")]
        public Combo Get(Guid id)
        {
            return context.Combos.FirstOrDefault(c => c.Id == id);
        }

        // POST api/<ComboController>
        [HttpPost]
        public bool Post( string ten, string ma)
        {
            try
            {
                Combo combo = new Combo() { Id = Guid.NewGuid(), Ten = ten, Ma = ma };
                context.Combos.Add(combo);
                context.SaveChanges();
                return true;


            }
            catch (Exception)
            {
                return false;
            }
        }

        // PUT api/<ComboController>/5
        [HttpPut("{id}")]
        public bool Put(Guid id, string ma, string ten)
        {
            try
            {
                var combo = context.Combos.FirstOrDefault(c=>c.Id == id);
                if (combo != null) { 
                combo.Ten = ten;
                combo.Ma = ma;
                context.Combos.Update(combo);
                context.SaveChanges();
                return true;
                }
                return false;


            }
            catch (Exception)
            {
                return false;
            }
        }

        // DELETE api/<ComboController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            try
            {
                var combo = context.Combos.FirstOrDefault(c => c.Id == id);
                context.Combos.Remove(combo);
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
