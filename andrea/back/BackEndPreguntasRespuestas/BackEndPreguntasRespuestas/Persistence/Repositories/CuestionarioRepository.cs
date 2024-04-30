using BackEndPreguntasRespuestas.Domain.IRepositories;
using BackEndPreguntasRespuestas.Domain.Models;
using BackEndPreguntasRespuestas.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BackEndPreguntasRespuestas.Persistence.Repositories
{
    public class CuestionarioRepository : ICuestionarioRespository
    {
        private readonly AplicationDbContext _context;

        public CuestionarioRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Cuestionario> buscarCuestionario(int IdCuestionario, int userID)
        {
            return await _context.Cuestionario.Where(x => x.Id == IdCuestionario && x.Activo == 1
                                                    && x.UsuarioId == userID).FirstOrDefaultAsync();
        }

        public async Task crearCuestionario(Cuestionario cuestionario)
        {
            _context.Add(cuestionario);
            await _context.SaveChangesAsync();
        }

        public async Task eliminarCuestionario(Cuestionario cuestionario)
        {
            cuestionario.Activo = 0;
            _context.Entry(cuestionario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Cuestionario> GetCuestionario(int IdCuestionario)
        {
            return await _context.Cuestionario.Where(x => x.Id == IdCuestionario && x.Activo == 1)
                                                     .Include(x => x.listPreguntas)
                                                     .ThenInclude(x => x.listRespuesta)
                                                     .FirstOrDefaultAsync();
        }

        public async Task<List<Cuestionario>> getListarCuestionarioByUser(int userId)
        {
            return await _context.Cuestionario.Where(x => x.Activo == 1 && x.UsuarioId == userId).ToListAsync();
        }

        public async Task<List<Cuestionario>> getListarCuestionarios()
        {
            return await _context.Cuestionario.Where(x => x.Activo == 1)
                .Select(o => new Cuestionario
                {
                    Id = o.Id,
                    Nombre = o.Nombre,
                    Descripcion = o.Descripcion,
                    FechaCreacion = o.FechaCreacion,
                    Usuario = new Usuario
                    {
                        NombreUsuario = o.Usuario.NombreUsuario
                    }
                }).ToListAsync();
        }
    }
}
