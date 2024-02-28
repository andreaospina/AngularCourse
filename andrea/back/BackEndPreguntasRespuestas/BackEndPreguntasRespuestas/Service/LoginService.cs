
using BackEndPreguntasRespuestas.Domain.IRepositories;
using BackEndPreguntasRespuestas.Domain.IServices;
using BackEndPreguntasRespuestas.Domain.Models;

namespace BackEndPreguntasRespuestas.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        //public Task<string> Login(string username, string password)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<Usuario> ValidateUser(Usuario usuario)
        {
           return await _loginRepository.ValidateUser(usuario);
        }
    }
}
