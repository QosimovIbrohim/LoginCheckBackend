using EmailSender.Application.DTOs;
using EmailSender.Application.Services.RegisterServices;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        public IRegisterService _reg;
        public RegisterController (IRegisterService reg)
        {
            _reg = reg;
        }

        [HttpPost]
        public async Task<string> Registr(UserDTO us)
        {
            return await _reg.Create(us);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _reg.GetAll());
        }
    }
}
