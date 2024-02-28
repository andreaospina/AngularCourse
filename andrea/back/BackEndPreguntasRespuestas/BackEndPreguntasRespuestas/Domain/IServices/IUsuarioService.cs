using BackEndPreguntasRespuestas.Domain.Models;

namespace BackEndPreguntasRespuestas.Domain.IServices
{
    public interface IUsuarioService
    {
        Task SaveUser(Usuario usuario);
        Task<bool> ValidateExistence(Usuario usuario);

        Task<Usuario> ValidatePassword(int idUsuario, String passwordAnterior);
        Task UpdatePassword(Usuario usuario);
    }
}
