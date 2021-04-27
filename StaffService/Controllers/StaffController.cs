using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StaffService.Database;
using StaffService.Database.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StaffService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        DatabaseContext db;
        // GET: api/<StaffController>
        public StaffController()
        {
            db = new DatabaseContext();
        }
        [HttpGet]
        public IEnumerable<Staff> Get()
        {
            return db.staffs.ToList();
        }

        // GET api/<StaffController>/5
        [HttpGet("{id}")]
        public Staff Get(int id)
        {
            return db.staffs.Find(id);
        }

        // POST api/<StaffController>
        [HttpPost]
        public IActionResult Post([FromBody] Staff model)
        {
            try
            {
                db.staffs.Add(model);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, model);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }

        // PUT api/<StaffController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Staff model)
        {
            try
            {
                db.staffs.Update(model);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, model);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<StaffController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                Staff staff = db.staffs.Find(id);
                if (staff is not null)
                {
                    db.staffs.Remove(staff);
                    db.SaveChanges();
                    return StatusCode(StatusCodes.Status200OK, id);
                }
                return StatusCode(StatusCodes.Status404NotFound, id);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
