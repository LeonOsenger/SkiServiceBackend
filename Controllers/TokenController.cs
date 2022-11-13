using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjektarbeitBackend.Models;
using SkiServiceBackend.DTO;
using SkiServiceBackend.Services;

namespace SkiServiceBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly ILogger<ServiceAuftragDBService> _logger;

        public TokenController(ITokenService tokenService, ILogger<ServiceAuftragDBService> logger)
        {
            _tokenService = tokenService;
            _logger = logger;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO UserData)
        {
            bool login = _tokenService.CheckUser(UserData.BenutzerName, UserData.BenutzerPasswort);

            if (login)
                return new JsonResult(new { userName = UserData.BenutzerName, token = _tokenService.CreateToken(UserData.BenutzerName) });
            else
                return Unauthorized("Invalid Credentials");

        }
    }
}
