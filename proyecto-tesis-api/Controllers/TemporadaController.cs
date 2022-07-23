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
    public class TemporadaController : ControllerBase
    {

        DB_PROYECTO_HOSPEDAJEContext db = new DB_PROYECTO_HOSPEDAJEContext();

        // GET: api/<Controller>
        [HttpGet]
        public ActionResult Get()
        {
            var r = db.Temporada.ToList();
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
                var r = db.Temporada.Find(id);

                if (r is null)
                {
                    return BadRequest(new { success = false, message = "Does not exist" });
                }
                else
                {
                    return Ok(new { success = true, data = r });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message });
            }
        }

        // POST api/<Controller>
        [HttpPost]
        public ActionResult Post([FromBody] Temporada r)
        {

            try
            {
                if (r is null)
                {
                    return BadRequest(new { success = false, message = "Does not exist" });
                }
                else
                {
                    db.Temporada.Add(r);
                    db.SaveChanges();
                    return Ok(new { success = true, message = "Success", data = r });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message });
            }

        }

        // PUT api/<Controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Temporada r)
        {
            try
            {
                if (r is null)
                {
                    return BadRequest(new { success = false, message = "Does not exist" });
                }
                else
                {
                    db.Temporada.Update(r);
                    db.SaveChanges();
                    return Ok(new { success = true, message = "Success", data = r });
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
                var r = db.Temporada.Find(id);

                if (r is null)
                {
                    return BadRequest(new { success = false, message = "Does not exist" });
                }
                else
                {
                    db.Temporada.Remove(r);
                    db.SaveChanges();
                    return Ok(new { success = true, message = "Success", data = r });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message });
            }
        }
    }
}
