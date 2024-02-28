using BackEndPreguntasRespuestas.Domain.Models;

namespace BackEndPreguntasRespuestas.Domain.IRepositories
{
    public interface ILoginRepository
    {
        Task<Usuario> ValidateUser(Usuario usuario);
    }
}
