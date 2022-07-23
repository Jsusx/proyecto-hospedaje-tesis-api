using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using proyecto_tesis_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace proyecto_tesis_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleReservaController : ControllerBase
    {
        DB_PROYECTO_HOSPEDAJEContext db = new DB_PROYECTO_HOSPEDAJEContext();

        // GET: api/<Controller>
        [HttpGet]
        public ActionResult Get()
        {
            var res = db.DetalleReserva.ToList();
            if (res.Count > 0)
            {
                return Ok(new { success = true, data = res });
            }
            else
            {
                return BadRequest(new { success = false, message = "No data" });
            }

        }

    
        // GET api/<Controller>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            try
            {
                var dr = db.Cliente.Find(id);

                if (dr is null)
                {
                    return BadRequest(new { success = false, message = "Does not exist" });
                }
                else
                {
                    return Ok(new { success = true, data = dr });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message });
            }
        }

        // POST api/<Controller>
        [HttpPost]
        public ActionResult Post([FromBody] DetalleReserva dr)
        {

            try
            {
                if (dr is null)
                {
                    return BadRequest(new { success = false, message = "Does not exist" });
                }
                else
                {
                    db.DetalleReserva.Add(dr);
                    db.SaveChanges();
                    return Ok(new { success = true, message = "Success", data = dr });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message });
            }

        }

        // PUT api/<Controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] DetalleReserva dr)
        {
            try
            {
                if (dr is null)
                {
                    return BadRequest(new { success = false, message = "Does not exist" });
                }
                else
                {
                    db.DetalleReserva.Update(dr);
                    db.SaveChanges();
                    return Ok(new { success = true, message = "Success", data = dr });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message });
            }

        }

        // DELETE api/<Controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {

            try
            {
                var dr = db.DetalleReserva.Find(id);

                if (dr is null)
                {
                    return BadRequest(new { success = false, message = "Does not exist" });
                }
                else
                {
                    db.DetalleReserva.Remove(dr);
                    db.SaveChanges();
                    return Ok(new { success = true, message= "Success", data = dr });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message });
            }
        }
    }
}
