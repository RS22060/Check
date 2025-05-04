using CheckInApp.API.Infrastructure;
using CheckInApp.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CheckInApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckInController(CheckInAppContext context) : ControllerBase
    {
        
        // GET: api/<CheckInController>
        [HttpGet]
        public IEnumerable<CheckIn> Get()
        {
            return context.CheckIns.Include(c => c.Customer);
        }

        // GET api/<CheckInController>/5
        [HttpGet("{id}")]
        public CheckIn? Get(string id)
        {
            return context.CheckIns.Include(c => c.Customer).FirstOrDefault(c => c.CheckInId == Guid.Parse(id));
        }

        // POST api/<CheckInController>
        [HttpPost]
        public void Post([FromBody] Customer value)
        {
            context.Customers.Add(value);
            var checkIn = new CheckIn
            {
                CheckInId = Guid.NewGuid(),
                Customer = value,
                Date = DateTime.Now
            };
            
            context.CheckIns.Add(checkIn);
            context.SaveChanges();
        }

        // PUT api/<CheckInController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Customer value)
        {
            var checkIn = context.CheckIns.FirstOrDefault(c => c.CheckInId == Guid.Parse(id));
            if (checkIn == null) return;
            
            checkIn.Customer = value;
            checkIn.Date = DateTime.Now;
            context.SaveChanges();
        }

        // DELETE api/<CheckInController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var checkIn = context.CheckIns.FirstOrDefault(c => c.CheckInId == Guid.Parse(id));
            if (checkIn == null) return;
            
            var removed = context.CheckIns.Remove(checkIn);
            if (removed is null) throw new Exception("Wasn't able to remove check in. Try again later.");
            context.SaveChanges();
        }
    }
}
