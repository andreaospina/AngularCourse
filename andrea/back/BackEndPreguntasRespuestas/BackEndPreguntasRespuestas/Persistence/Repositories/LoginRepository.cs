﻿using BackEndPreguntasRespuestas.Domain.IRepositories;
using BackEndPreguntasRespuestas.Domain.Models;
using BackEndPreguntasRespuestas.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BackEndPreguntasRespuestas.Persistence.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AplicationDbContext _context;

        public LoginRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> ValidateUser(Usuario usuario)
        {
            var user = await _context.Usuarios.Where(x => x.NombreUsuario == usuario.NombreUsuario &&
            x.Password == usuario.Password).FirstOrDefaultAsync();
            return user;
        }
    }
}
