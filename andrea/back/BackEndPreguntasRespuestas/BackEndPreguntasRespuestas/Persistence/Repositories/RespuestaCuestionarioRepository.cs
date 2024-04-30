using BackEndPreguntasRespuestas.Domain.IRepositories;
using BackEndPreguntasRespuestas.Domain.Models;
using BackEndPreguntasRespuestas.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BackEndPreguntasRespuestas.Persistence.Repositories
{
    public class RespuestaCuestionarioRepository : IRespuestaCuestionarioRepository
    {
        private readonly AplicationDbContext _context;

        public RespuestaCuestionarioRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RespuestaCuestionario> BuscarRespuestaById(int idRespuesta, int idUsuario)
        {
            var respuestaCuestionario = await _context.RespuestaCuestionario.Where(x=> x.Id == idRespuesta 
                                              && x.Cuestionario.UsuarioId == idUsuario && x.Activo == true).FirstOrDefaultAsync();
            return respuestaCuestionario;
        }

        public async Task EliminarRespuestaCuestionario(RespuestaCuestionario respuestaCuestionario)
        {
            respuestaCuestionario.Activo = false;
            _context.Entry(respuestaCuestionario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task GuardarRespuestaCuestionario(RespuestaCuestionario respuestaCuestionario)
        {
            respuestaCuestionario.Activo = true;
            respuestaCuestionario.Fecha = DateTime.Now;
            _context.Add(respuestaCuestionario);
            await _context.SaveChangesAsync();
        }

        public async Task<List<RespuestaCuestionario>> ListRespuestaCuestionario(int idCuestionario)
        {
            var listRespuestaCuestionario = await _context.RespuestaCuestionario.Where(x => x.CuestionarioId == idCuestionario && x.Activo == true)
                .OrderByDescending(x => x.Fecha).ToListAsync();
            return listRespuestaCuestionario;
        }

        public async Task<List<RespuestaCuestionarioDetalle>> ObtenerListadoRespuestas(int idRespuestaCuestionario)
        {
            var listRespuestas = await _context.RespuestaCuestionarioDetalle.Where(x => x.RespuestaCuestionarioId == idRespuestaCuestionario)
                                                        .Select(x => new RespuestaCuestionarioDetalle
                                                        {
                                                            RespuestaId = x.RespuestaId
                                                        }).ToListAsync();
            return listRespuestas;
        }
    }
}
