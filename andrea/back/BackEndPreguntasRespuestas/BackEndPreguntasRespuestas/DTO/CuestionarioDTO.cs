using System.ComponentModel.DataAnnotations;

namespace BackEndPreguntasRespuestas.DTO
{
    public class CuestionarioDTO
    {
        public int? Id { get; set; }
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Required]
        public List<PreguntaDTO> ListPreguntas { get; set; }

        //public int Activo { get { return 1; } set {} }



        //    public int Activo
        //{
        //        get { return 1; }
        //        set { Activo = value; }
        //    }


    }
}
