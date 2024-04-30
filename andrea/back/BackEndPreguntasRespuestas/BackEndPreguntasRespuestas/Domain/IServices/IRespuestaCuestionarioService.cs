using BackEndPreguntasRespuestas.Domain.Models;

namespace BackEndPreguntasRespuestas.Domain.IServices
{
    public interface IRespuestaCuestionarioService
    {
        Task GuardarRespuestaCuestionario(RespuestaCuestionario respuestaCuestionario);
        Task<List<RespuestaCuestionario>> ListRespuestaCuestionario(int idCuestionario);
        Task<RespuestaCuestionario> BuscarRespuestaById(int idRespuesta, int idUsuario);
        Task EliminarRespuestaCuestionario(RespuestaCuestionario respuestaCuestionario);
        Task<List<RespuestaCuestionarioDetalle>> ObtenerListadoRespuestas(int idRespuestaCuestionario);


    }
}
