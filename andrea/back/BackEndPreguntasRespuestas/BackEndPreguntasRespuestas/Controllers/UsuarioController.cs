using BackEndPreguntasRespuestas.Domain.IServices;
using BackEndPreguntasRespuestas.Domain.Models;
using BackEndPreguntasRespuestas.DTO;
using BackEndPreguntasRespuestas.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BackEndPreguntasRespuestas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> GuardarUsuario([FromBody]Usuario usuario)
        {
            try
            {
                var existe = await _usuarioService.ValidateExistence(usuario);

                if (existe)
                {
                    return BadRequest(new { Message = "el usuario " + usuario.NombreUsuario + " ya existe" });
                }

                usuario.Password = Encriptar.EncriparPassword(usuario.Password);

                await _usuarioService.SaveUser(usuario);

                return Ok(new { message = "Usuario registrado con exito" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Route("CambiarPassword")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        public async Task<IActionResult> CambiarPassword([FromBody] CambiarPasswordDTO cambiarPassword)
        {
            try
            {
                //obtener el id del usuario del token
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                var encriptarPassword = Encriptar.EncriparPassword(cambiarPassword.PasswordAnterior);
                var usuario = await _usuarioService.ValidatePassword(idUsuario, encriptarPassword);

                if (usuario == null)
                {
                    return BadRequest(new { message = "contraseña incorrecta" });
                }
                else
                {
                    usuario.Password = Encriptar.EncriparPassword(cambiarPassword.NuevaPassword);
                    await _usuarioService.UpdatePassword(usuario);
                    return Ok(new { Message = "la contrseña fue actualizada" });
                }
                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
