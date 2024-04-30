using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndPreguntasRespuestas.DTO
{
    public class RespuestaCuestionarioDTO
    {
        public int? id { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string NombreParticipante { get; set; }

        public int CuestionarioId { get; set; }

        public List<RespuestaCuestionarioDetalleDTO> ListRtaCuestionarioDetalle { get; set; }
    }
}
