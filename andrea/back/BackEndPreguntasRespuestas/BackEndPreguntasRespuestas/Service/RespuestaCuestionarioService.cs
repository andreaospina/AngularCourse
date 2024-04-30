using BackEndPreguntasRespuestas.Domain.IRepositories;
using BackEndPreguntasRespuestas.Domain.IServices;
using BackEndPreguntasRespuestas.Domain.Models;

namespace BackEndPreguntasRespuestas.Service
{
    public class RespuestaCuestionarioService : IRespuestaCuestionarioService
    {
        private readonly IRespuestaCuestionarioRepository _respuestaCuestionarioRepository;

        public RespuestaCuestionarioService(IRespuestaCuestionarioRepository respuestaCuestionarioRepository )
        {
            _respuestaCuestionarioRepository = respuestaCuestionarioRepository;
        }

        public async Task<RespuestaCuestionario> BuscarRespuestaById(int idRespuesta, int idUsuario)
        {
            return await _respuestaCuestionarioRepository.BuscarRespuestaById(idRespuesta, idUsuario);
        }

        public async Task EliminarRespuestaCuestionario(RespuestaCuestionario respuestaCuestionario)
        {
            await _respuestaCuestionarioRepository.EliminarRespuestaCuestionario(respuestaCuestionario);
        }

        public async Task GuardarRespuestaCuestionario(RespuestaCuestionario respuestaCuestionario)
        {
           await _respuestaCuestionarioRepository.GuardarRespuestaCuestionario(respuestaCuestionario);    
        }

        public async Task<List<RespuestaCuestionario>> ListRespuestaCuestionario(int idCuestionario)
        {
           return await _respuestaCuestionarioRepository.ListRespuestaCuestionario(idCuestionario);
        }

        public async Task<List<RespuestaCuestionarioDetalle>> ObtenerListadoRespuestas(int idRespuestaCuestionario)
        {
            return await _respuestaCuestionarioRepository.ObtenerListadoRespuestas(idRespuestaCuestionario);
        }
    }
}
