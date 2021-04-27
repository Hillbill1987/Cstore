using DeliveryService.Database;
using DeliveryService.Database.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeliveryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        DatabaseContext db;

        public DeliveryController()
        {
            db = new DatabaseContext();
        }
        // GET: api/<DeliveryController>
        [HttpGet]
        public IEnumerable<Delivery> Get()
        {
            return db.deliveries.ToList();
        }

        // GET api/<DeliveryController>/5
        [HttpGet("{id}")]
        public Delivery Get(int id)
        {
            return db.deliveries.Find(id);
        }

        // POST api/<DeliveryController>
        [HttpPost]
        public IActionResult Post([FromBody] Delivery model)
        {
            try
            {
                db.deliveries.Add(model);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, model);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<DeliveryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Delivery model)
        {
            try
            {
                db.deliveries.Update(model);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, model);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<DeliveryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                Delivery delivery = db.deliveries.Find(id);
                if (delivery is not null)
                {
                    db.deliveries.Remove(delivery);
                    db.SaveChanges();
                    return StatusCode(StatusCodes.Status200OK, delivery);
                }
                return StatusCode(StatusCodes.Status404NotFound);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
