using BackEndPreguntasRespuestas.Domain.IRepositories;
using BackEndPreguntasRespuestas.Domain.IServices;
using BackEndPreguntasRespuestas.Domain.Models;

namespace BackEndPreguntasRespuestas.Service
{
    public class CuestionarioService : ICuestionarioService
    {
        private readonly ICuestionarioRespository _cuestionarioRespository;

        public CuestionarioService(ICuestionarioRespository cuestionarioRespository)
        {
            _cuestionarioRespository = cuestionarioRespository;
        }

        public async Task<Cuestionario> buscarCuestionario(int IdCuestionario, int userId)
        {
           return await _cuestionarioRespository.buscarCuestionario(IdCuestionario, userId);
        }

        public async Task crearCuestionario(Cuestionario cuestionario)
        {
            await _cuestionarioRespository.crearCuestionario(cuestionario);
        }

        public async Task eliminarCuestionario(Cuestionario cuestionario)
        {
             await _cuestionarioRespository.eliminarCuestionario(cuestionario);
        }

        public async Task<Cuestionario> GetCuestionario(int IdCuestionario)
        {
            return await _cuestionarioRespository.GetCuestionario(IdCuestionario);
        }

        public async Task<List<Cuestionario>> getListarCuestionarioByUser(int userId)
        {
            return await _cuestionarioRespository.getListarCuestionarioByUser(userId);
        }

        public async Task<List<Cuestionario>> getListarCuestionarios()
        {
            return await _cuestionarioRespository.getListarCuestionarios();
        }
    }
}
