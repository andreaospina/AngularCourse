using AutoMapper;
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
    public class RespuestaCuestionarioController : ControllerBase
    {
        private readonly IRespuestaCuestionarioService _respuestaCuestionarioService;
        private readonly IMapper _mapper;
        private readonly ICuestionarioService _cuestionarioService;

        public RespuestaCuestionarioController(IRespuestaCuestionarioService respuestaCuestionarioService, IMapper mapper, ICuestionarioService cuestionarioService)
        {
            _respuestaCuestionarioService = respuestaCuestionarioService;
            _mapper = mapper;
            _cuestionarioService = cuestionarioService;
        }

        [HttpPost]
        public async Task<IActionResult> guardarRespuesta([FromBody] RespuestaCuestionarioDTO respuestaCuestionarioDTO)
        {
            try
            {
                var respuestaCuestionario = _mapper.Map<RespuestaCuestionario>(respuestaCuestionarioDTO);
                await _respuestaCuestionarioService.GuardarRespuestaCuestionario(respuestaCuestionario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{idCuestionario}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> listRespuestaCuestionario(int idCuestionario)
        {
            try
            {
                var listRespuestaCuestionario = await _respuestaCuestionarioService.ListRespuestaCuestionario(idCuestionario);
                if (listRespuestaCuestionario == null)
                {
                    return BadRequest(new { message = "Error al uscar cuestionario" });
                }

                return Ok(listRespuestaCuestionario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<IActionResult> eliminarCuestionario(int id)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                var respuestaCuestionario = await _respuestaCuestionarioService.BuscarRespuestaById(id, idUsuario);
                if (respuestaCuestionario == null)
                {
                    return BadRequest(new { message = "error al buscar la respuesta del cuestionario" });
                }

                await _respuestaCuestionarioService.EliminarRespuestaCuestionario(respuestaCuestionario);
                return Ok(new {message = "la respuesta del cuestionario ha sido eliminada correctamente"});
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Route("RespuestaCuestionarioById/{idRespuesta}")]
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> obtenerRespuestaCuestionarioById(int idRespuesta)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                RespuestaCuestionario respuestaCuestionario = await _respuestaCuestionarioService.BuscarRespuestaById(idRespuesta, idUsuario);
                var cuestionario = await _cuestionarioService.GetCuestionario(respuestaCuestionario.CuestionarioId);

                var listRespuestas = await _respuestaCuestionarioService.ObtenerListadoRespuestas(idRespuesta);

                return Ok(new {cuestionario = cuestionario, listRespuestas = listRespuestas});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
