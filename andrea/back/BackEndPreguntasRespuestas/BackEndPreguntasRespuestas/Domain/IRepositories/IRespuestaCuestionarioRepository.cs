using BackEndPreguntasRespuestas.Domain.Models;

namespace BackEndPreguntasRespuestas.Domain.IRepositories
{
    public interface IRespuestaCuestionarioRepository
    {
        Task GuardarRespuestaCuestionario(RespuestaCuestionario respuestaCuestionario);
        Task<List<RespuestaCuestionario>> ListRespuestaCuestionario(int idCuestionario);
        Task<RespuestaCuestionario> BuscarRespuestaById(int idRespuesta, int idUsuario);
        Task EliminarRespuestaCuestionario(RespuestaCuestionario respuestaCuestionario);
        Task<List<RespuestaCuestionarioDetalle>> ObtenerListadoRespuestas(int idRespuestaCuestionario);
    }
}
