using BackEndPreguntasRespuestas.Domain.IServices;
using BackEndPreguntasRespuestas.Domain.Models;
using BackEndPreguntasRespuestas.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndPreguntasRespuestas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IConfiguration _configuration;

        public LoginController(ILoginService loginService, IConfiguration configuration)
        {
            _loginService = loginService;
            _configuration = configuration;
        }

        [HttpPost]

        public async Task<ActionResult> ValidateUser(Usuario usuario)
        {
            try
            {
                usuario.Password = Encriptar.EncriparPassword(usuario.Password);
                var user = await _loginService.ValidateUser(usuario);
                if (user == null) return BadRequest(new { Message = "usuario o contraseña Incorrectos" });
                string tokenString = JwtConfigurator.GetToken(user, _configuration);
                return Ok(new { token = tokenString});
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
