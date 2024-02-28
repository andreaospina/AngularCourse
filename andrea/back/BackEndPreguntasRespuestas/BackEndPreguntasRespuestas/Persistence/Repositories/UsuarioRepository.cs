using BackEndPreguntasRespuestas.Domain.IRepositories;
using BackEndPreguntasRespuestas.Domain.Models;
using BackEndPreguntasRespuestas.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BackEndPreguntasRespuestas.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AplicationDbContext _context;

        public UsuarioRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveUser(Usuario usuario)
        {
            _context.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePassword(Usuario usuario)
        {
           _context.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> validateExistence(Usuario usuario)
        {
            var validate = await _context.Usuarios.AnyAsync(
                x => x.NombreUsuario == usuario.NombreUsuario);
            return validate;
        }

        public async Task<Usuario> ValidatePassword(int idUsuario, string passwordAnterior)
        {
            var usuario = await _context.Usuarios.Where(x => x.Id == idUsuario && x.Password == passwordAnterior).FirstOrDefaultAsync();
            return usuario;
        }


    }
}
