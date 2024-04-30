using BackEndPreguntasRespuestas.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndPreguntasRespuestas.Persistence.Context
{
    public class AplicationDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           // modelBuilder.Entity<RespuestaCuestionarioDetalle>().HasKey(x => new { x.RespuestaCuestionarioId, x.RespuestaId});
            modelBuilder.Entity<RespuestaCuestionarioDetalle>().HasOne(x => x.RespuestaCuestionario).WithMany(x=> x.ListRtaCuestionarioDetalle).OnDelete(DeleteBehavior.Restrict);

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cuestionario> Cuestionario { get; set; }

        public DbSet<Pregunta> Pregunta { get; set; }

        public DbSet<Respuesta> Respuesta { get; set; }
        public DbSet<RespuestaCuestionario> RespuestaCuestionario { get; set; }
        public DbSet<RespuestaCuestionarioDetalle> RespuestaCuestionarioDetalle { get; set; }
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options)
        {

        }
    }
}
