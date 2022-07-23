using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace proyecto_tesis_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        // GET: api/<HomeController>
        [HttpGet]
        public string Get()
        {
            var r = "Bienvenido";
            return r;
        }

        
    }
}
