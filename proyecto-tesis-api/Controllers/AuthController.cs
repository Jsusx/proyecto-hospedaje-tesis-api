using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using proyecto_tesis_api.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace proyecto_tesis_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {


        public class GeneratedToken
        {
            public DateTime expires { get; set; }
            public string token { get; set; }
        }


        DB_PROYECTO_HOSPEDAJEContext db = new DB_PROYECTO_HOSPEDAJEContext();

        private IConfiguration config;

        public AuthController(IConfiguration conf)
        {
            config = conf;
        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login([FromBody] Authentication value)
        {
            var e = Authenticate(value);

            if (e != null)
            {
                var token = Generate(e);
                return Ok(new { success = true, session = new { data = e, type = "empleado", token = token.token, expires = token.expires.ToString("yyyy-MM-dd HH:mm:ss") } });
            }
            else
            {
                var c = ReAuthenticate(value);

                if (c != null)
                {
                    var token = Generate(null, c);
                    return Ok(new { success = true, session = new { data = c, type = "cliente", token = token.token, expires = token.expires.ToString("yyyy-MM-dd HH:mm:ss") } });
                }

            }

            Console.WriteLine("test:v");

            return NotFound();
        }


        private GeneratedToken Generate(Empleado e = null, Cliente c = null)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            Claim[] claims = null;

            if (e != null)
            {
                claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, e.IdEmpleado),
                    new Claim(ClaimTypes.Email, e.Correo),
                    new Claim(ClaimTypes.Authentication, e.IdTipoEmpleado),
                    new Claim(ClaimTypes.Role, "Empleado")
                };
            }

            if (c != null)
            {
                claims = new[]
{
                    new Claim(ClaimTypes.NameIdentifier, c.IdCliente),
                    new Claim(ClaimTypes.Email, c.Correo),
                    new Claim(ClaimTypes.Authentication, c.IdTipoCliente),
                    new Claim(ClaimTypes.Role, "Cliente")
                };
            }

            var expires = DateTime.Now.AddMinutes(60);

            var token = new JwtSecurityToken(config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims,
                expires: expires,
                signingCredentials: credentials);

            return new GeneratedToken { expires = expires, token = new JwtSecurityTokenHandler().WriteToken(token) };
        }

        private Empleado Authenticate(Authentication login)
        {
            var user = db.Empleado.FirstOrDefault(o => o.Correo == login.email && o.Password == login.password);
            if (user != null)
            {
                return user;
            }
            

            return null;
        }

        private Cliente ReAuthenticate(Authentication login)
        {
            var user = db.Cliente.FirstOrDefault(o => o.Correo == login.email && o.Password == login.password);
            if (user != null)
            {
                return user;
            }


            return null;
        }

    }
}
