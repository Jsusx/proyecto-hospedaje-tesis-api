using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto_tesis_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace proyecto_tesis_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionController : ControllerBase
    {

        DB_PROYECTO_HOSPEDAJEContext db = new DB_PROYECTO_HOSPEDAJEContext();

        // GET: api/<Controller>
        [HttpGet]
        public ActionResult Get()
        {
            var r = db.Habitacion.ToList();
            if (r.Count > 0)
            {
                return Ok(new { success = true, data = r });
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
                var h = db.Habitacion.Find(id);

                if (h is null)
                {
                    return BadRequest(new { success = false, message = "Does not exist" });
                }
                else
                {
                    return Ok(new { success = true, data = h });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message });
            }
        }

        // POST api/<Controller>
        [HttpPost]
        public ActionResult Post([FromBody] Habitacion h)
        {

            try
            {
                if (h is null)
                {
                    return BadRequest(new { success = false, message = "Does not exist" });
                }
                else
                {
                    db.Habitacion.Add(h);
                    db.SaveChanges();
                    return Ok(new { success = true, message = "Success", data = h });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message });
            }

        }

        // PUT api/<Controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Habitacion h)
        {
            try
            {
                if (h is null)
                {
                    return BadRequest(new { success = false, message = "Does not exist" });
                }
                else
                {
                    db.Habitacion.Update(h);
                    db.SaveChanges();
                    return Ok(new { success = true, message = "Success", data = h });
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
                var h = db.Habitacion.Find(id);

                if (h is null)
                {
                    return BadRequest(new { success = false, message = "Does not exist" });
                }
                else
                {
                    db.Habitacion.Remove(h);
                    db.SaveChanges();
                    return Ok(new { success = true, message = "Success", data = h });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message });
            }
        }

    }
}
