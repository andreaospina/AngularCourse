using BackEndPreguntasRespuestas.Domain.Models;

namespace BackEndPreguntasRespuestas.Domain.IServices
{
    public interface ICuestionarioService
    {
        Task crearCuestionario(Cuestionario cuestionario);
        Task<List<Cuestionario>> getListarCuestionarioByUser(int userId);

        Task<Cuestionario> GetCuestionario(int IdCuestionario);

        Task<Cuestionario> buscarCuestionario(int IdCuestionario, int userId);

        Task eliminarCuestionario(Cuestionario cuestionario);

        Task<List<Cuestionario>> getListarCuestionarios();


    }
}
