using Microsoft.AspNetCore.Mvc;

namespace docker_working.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;  
        public StatusController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet]
        public IActionResult GetStatus()
        {
            var environmnetDocker = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true";

            return Ok(new
            {
                Mensagem = "Tudo funcionando corretamente!",
                Ambiente = _env.EnvironmentName,
                RodandoNoDocker = environmnetDocker,
                HostName = Environment.MachineName,
                Timestamp = DateTime.UtcNow,
            }); 
        }
    }
}
