using AutoMapper;
using SistemaGimnasio.DTO;
using SistemaGimnasio.Model;

namespace SistemaGimnasio.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //mis mapeos de dto a las tablas 
          
            //*************************************************************************************

            // Mapeos gimnasio RMB
            CreateMap<ClienteDtoRMB, ClienteRMB>();
            CreateMap<ClienteRMB, ClienteDtoRMB>();

            // Mappeo para incluir nombres de cliente y entrenador en PlanEntrenamientoDtoRMB
            CreateMap<PlanEntrenamientoRMB, PlanEntrenamientoClienteEntranadorDtoRMB>()
                .ForMember(dest => dest.ClienteNombre, opt => opt.MapFrom(src => src.Cliente != null ? src.Cliente.Nombre + " " + src.Cliente.Apellido : null))
                .ForMember(dest => dest.EntrenadorNombre, opt => opt.MapFrom(src => src.Entrenador != null ? src.Entrenador.Nombre + " " + src.Entrenador.Apellido : null));


            CreateMap<EntrenadorDtoRMB, EntrenadorRMB>();
            CreateMap<EntrenadorRMB, EntrenadorDtoRMB>();

            CreateMap<MembresiaDtoRMB, MembresiaRMB>();
            CreateMap<MembresiaRMB, MembresiaDtoRMB>();

            CreateMap<CrearMembresiaDtoRMB, MembresiaRMB>();//-

            CreateMap<ClienteRMB, ClienteConMembresiasDtoRMB>();
            CreateMap<ClienteConMembresiasDtoRMB, ClienteRMB>();

            CreateMap<PagoDtoRMB, PagoRMB>();
            CreateMap<PagoRMB, PagoDtoRMB>();

            CreateMap<ClaseDtoRMB, ClaseRMB>();
            CreateMap<ClaseRMB, ClaseDtoRMB>();

            CreateMap<ReservaClaseDtoRMB, ReservaClaseRMB>();
            CreateMap<ReservaClaseRMB, ReservaClaseDtoRMB>();

            CreateMap<PlanEntrenamientoDtoRMB, PlanEntrenamientoRMB>();
            CreateMap<PlanEntrenamientoRMB, PlanEntrenamientoDtoRMB>();

            //***********************************************************
            
            CreateMap<MembresiaRMB, MembresiaConClienteYPagosDtoRMB>();

            // Mapeo para la información del cliente anidada
            CreateMap<ClienteRMB, ClienteInfoDtoRMB>();





        }
    }
}
