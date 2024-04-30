using System.ComponentModel.DataAnnotations;

namespace BackEndPreguntasRespuestas.DTO
{
    public class RespuestaDTO
    {
        public int? Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public bool EsCorrecta { get; set; }
    }
}
