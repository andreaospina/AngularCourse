using AutoMapper;
using BackEndPreguntasRespuestas.Domain.IServices;
using BackEndPreguntasRespuestas.Domain.Models;
using BackEndPreguntasRespuestas.DTO;
using BackEndPreguntasRespuestas.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BackEndPreguntasRespuestas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuestionarioController : ControllerBase
    {
        private readonly ICuestionarioService _cuestionarioService;
        private readonly IMapper _mapper;

        public CuestionarioController(ICuestionarioService cuestionarioService, IMapper mapper)
        {
            _cuestionarioService = cuestionarioService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> guardarCuestionario([FromBody] CuestionarioDTO cuestionarioDto)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int idUsuario = JwtConfigurator.GetTokenIdUsuario(identity);

                var cuestionario = _mapper.Map< Cuestionario>(cuestionarioDto);
                cuestionario.UsuarioId = idUsuario;
                cuestionario.Activo = 1;
                await _cuestionarioService.crearCuestionario(cuestionario);
                return Ok(new { message = "Se agrego el cuestionario exitosamente" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message); 
            }
        }

        [Route("getListcuestionarioByUser")]
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> getListCuestionarioByUser()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int userID = JwtConfigurator.GetTokenIdUsuario(identity);
                var listCustionario = await _cuestionarioService.getListarCuestionarioByUser(userID);
                return Ok(listCustionario);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{idCuestionario}")]
        public async Task<IActionResult> getCuestionario(int IdCuestionario)
        {
            try
            {
                var cuestionario = await _cuestionarioService.GetCuestionario(IdCuestionario);
                return Ok(cuestionario);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{idCuestionario}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> eliminarCuestionario(int idCuestionario)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int userID = JwtConfigurator.GetTokenIdUsuario(identity);
                var cuestionario = await _cuestionarioService.buscarCuestionario(idCuestionario, userID);
                if (cuestionario == null)
                {
                    return BadRequest(new { message = "No se encontro el cuestionario" });
                }

                await _cuestionarioService.eliminarCuestionario(cuestionario);
                return Ok(new { message = "Cuestionario eliminado correctamente" });

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Route("getListCuestionarios")]
        [HttpGet]
        public async Task<IActionResult> getListCuestionario()
        {
            try
            {
                var listCuestionarios = await _cuestionarioService.getListarCuestionarios();
                return Ok(listCuestionarios);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
