using BackEndPreguntasRespuestas.Domain.Models;

namespace BackEndPreguntasRespuestas.Domain.IRepositories
{
    public interface IUsuarioRepository
    {
        Task SaveUser(Usuario usuario);
        Task<bool> validateExistence(Usuario usuario);
        Task<Usuario> ValidatePassword(int idUsuario, String password);
        Task UpdatePassword(Usuario usuario);
    }
}
