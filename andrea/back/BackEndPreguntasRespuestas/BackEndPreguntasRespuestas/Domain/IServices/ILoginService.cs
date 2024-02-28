using BackEndPreguntasRespuestas.Domain.Models;

namespace BackEndPreguntasRespuestas.Domain.IServices
{
    public interface ILoginService
    {
        //public Task<string> Login(string username, string password);
         Task<Usuario> ValidateUser(Usuario usuario);
    }
}
