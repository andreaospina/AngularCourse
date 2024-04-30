using AutoMapper;
using BackEndPreguntasRespuestas.Domain.Models;
using BackEndPreguntasRespuestas.DTO;

namespace BackEndPreguntasRespuestas.Utils
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CuestionarioDTO, Cuestionario>();
            CreateMap<PreguntaDTO, Pregunta>();
            CreateMap<RespuestaDTO, Respuesta>();
            CreateMap<RespuestaCuestionarioDTO, RespuestaCuestionario>();
            CreateMap<RespuestaCuestionarioDetalleDTO, RespuestaCuestionarioDetalle>();
        }
    }
}
