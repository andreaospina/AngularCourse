using System.ComponentModel.DataAnnotations;

namespace BackEndPreguntasRespuestas.DTO
{
    public class PreguntaDTO
    {
        public int? Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public List<RespuestaDTO> listRespuesta { get; set; }
    }
}
