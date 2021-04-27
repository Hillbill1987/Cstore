using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesService.Database;
using SalesService.Database.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        DatabaseContext db;

        public SalesController()
        {
            db = new DatabaseContext();
        }
        // GET: api/<SalesController>
        [HttpGet]
        public IEnumerable<Sales> Get()
        {
            return db.sales.ToList();
        }

        // GET api/<SalesController>/5
        [HttpGet("{id}")]
        public Sales Get(int id)
        {
            return db.sales.Find(id);
        }

        // POST api/<SalesController>
        [HttpPost]
        public IActionResult Post([FromBody] Sales model)
        {
            try
            {
                db.sales.Add(model);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, model);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<SalesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Sales model)
        {
            try
            {
                db.sales.Update(model);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, model);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<SalesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
             try
            {
                Sales sale = db.sales.Find(id);
                if (sale is not null)
                {
                    db.sales.Remove(sale);
                    db.SaveChanges();
                    return StatusCode(StatusCodes.Status200OK, sale);
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
