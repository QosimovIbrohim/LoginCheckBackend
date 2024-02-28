using EmailSender.Application.DTOs;
using EmailSender.Application.Services.LoginServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public ILoginService _log;
        public LoginController(ILoginService log)
        {
            _log = log;
        }

        [HttpGet]
        public async Task<IActionResult> Login([FromForm] LoginDTO lg)
        {
            return Ok(_log.Login(lg).Result);
        }
    }
}
