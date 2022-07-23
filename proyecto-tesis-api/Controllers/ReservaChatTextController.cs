using Microsoft.AspNetCore.Mvc;
using proyecto_tesis_api.Models;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace proyecto_tesis_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaChatTextController : ControllerBase
    {

        DB_PROYECTO_HOSPEDAJEContext db = new DB_PROYECTO_HOSPEDAJEContext();

        // GET: api/<Controller>
        [HttpGet]
        public ActionResult Get()
        {
            var r = db.ReservaChatText.ToList();
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
                var r = db.ReservaChatText.Find(id);


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
        public ActionResult Post([FromForm] ReservaChatText r)
        {

            try
            {
                if (r is null)
                {
                    return BadRequest(new { success = false, message = "Does not exist" });
                }
                else
                {
                    var rt = db.ReservaChatText.Find(r.IdReservaChatText);

                    if (rt != null)
                    {
                        return BadRequest(new { success = false, message = "Does exist" });
                    }
                    else
                    {
                        if (r.Imagen != null)
                        {
                            var folder_name = db.Reserva.Find(db.ReservaChat.Find(r.IdReservaChat).IdReserva).Codigo;
                            var chat_dir = Directory.GetCurrentDirectory() + "/Resources/Images/Chat/" + folder_name;
                            if (!Directory.Exists(chat_dir))
                            {
                                Directory.CreateDirectory(chat_dir);
                            }

                            var file = Guid.NewGuid() + Path.GetExtension(r.Imagen.FileName);
                            var path = Path.Combine(chat_dir, file);
                            var f = System.IO.File.Create(path);
                            r.Imagen.CopyTo(f);
                            f.Close();

                            r.Formato = "image/" + Path.GetExtension(r.Imagen.FileName).Replace(".", "");
                            r.Texto = HttpContext.Request.IsHttps ? "https" : "http" + "://" + HttpContext.Request.Host.ToString() + "/resources/images/chat/" + folder_name + "/" + file;
                        }

                        r.Imagen = null;

                        db.ReservaChatText.Add(r);
                        db.SaveChanges();
                        return Ok(new { success = true, message = "Success", data = r });
                    }

                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message });
            }

        }

        // PUT api/<Controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] ReservaChatText r)
        {
            try
            {
                if (r is null)
                {
                    return BadRequest(new { success = false, message = "Does not exist" });
                }
                else
                {
                    db.ReservaChatText.Update(r);
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
                var r = db.ReservaChatText.Find(id);

                if (r is null)
                {
                    return BadRequest(new { success = false, message = "Does not exist" });
                }
                else
                {
                    db.ReservaChatText.Remove(r);
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
