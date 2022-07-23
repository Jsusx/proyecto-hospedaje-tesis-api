using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proyecto_tesis_api.Models;
using proyecto_tesis_api.Tools;
using System;
using System.Collections.Generic;
using System.Linq;


namespace proyecto_tesis_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {

        DB_PROYECTO_HOSPEDAJEContext db = new DB_PROYECTO_HOSPEDAJEContext();

        // GET: api/<Controller>
        [HttpGet]
        public ActionResult Get()
        {
            var r = db.Empleado.ToList();
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
                var em = db.Empleado.Find(id);

                if (em is null)
                {
                    return BadRequest(new { success = false, message = "Does not exist" });
                }
                else
                {
                    return Ok(new { success = true, data = em });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message });
            }
        }

        // POST api/<Controller>
        [HttpPost]
        public ActionResult Post([FromBody] Empleado em)
        {

            try
            {
                if (em is null)
                {
                    return BadRequest(new { success = false, message = "Does not exist" });
                }
                else
                {
                    db.Empleado.Add(em);
                    db.SaveChanges();
                    return Ok(new { success = true, message = "Success", data = em });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message });
            }

        }

        // PUT api/<Controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Empleado dr)
        {
            try
            {
                if (dr is null)
                {
                    return BadRequest(new { success = false, message = "Does not exist" });
                }
                else
                {
                    db.Empleado.Update(dr);
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
                var em = db.Empleado.Find(id);

                if (em is null)
                {
                    return BadRequest(new { success = false, message = "Does not exist" });
                }
                else
                {
                    db.Empleado.Remove(em);
                    db.SaveChanges();
                    return Ok(new { success = true, message = "Success", data = em });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message });
            }
        }

    }
}
