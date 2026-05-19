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
            //Post mappeo para agregar


            //         origen            Destino
           //CreateMap<PostProductoDTO, Producto>();

            //tabla usuario roles credenciales
            //CreateMap<PostUsuarioRolesDTO,Usuario>();
            //CreateMap<PostUsuarioRolesDTO,RolesDetalle>();
            //CreateMap<PostUsuarioRolesDTO,Credenciales>();

            //getUsuario Roles usuario credenciales
            //CreateMap<Usuario, GetUsuarioRolesDTO>();

            //         origen        Destino
            //CreateMap<PostCamionDTO, Camion>();




            //Get mappeo para retornar
            //         origen            Destino
            //CreateMap< Producto, PostProductoDTO>();
            //CreateMap<Categoria, GetCategoriaDTO>();
            //CreateMap<Producto, GetProductoDTO>();
            //CreateMap<Roles, GetRolesAllDTO>();
            //        origen    Destino
            //CreateMap<Camion, GetCamionDTO>();
            //update
            //        origen         Destino
            //CreateMap<UpdateCamionDTO,Camion>();


    
            //*************************************************************************************

            // Mapeos gimnasio RMB
            CreateMap<ClienteDtoRMB, ClienteRMB>();
            CreateMap<ClienteRMB, ClienteDtoRMB>();

            // CAMBIO: Mappeo para incluir nombres de cliente y entrenador en PlanEntrenamientoDtoRMB
            CreateMap<PlanEntrenamientoRMB, PlanEntrenamientoDtoRMB>()
                .ForMember(dest => dest.ClienteNombre, opt => opt.MapFrom(src => src.Cliente != null ? src.Cliente.Nombre + " " + src.Cliente.Apellido : null))
                .ForMember(dest => dest.EntrenadorNombre, opt => opt.MapFrom(src => src.Entrenador != null ? src.Entrenador.Nombre + " " + src.Entrenador.Apellido : null));


            CreateMap<EntrenadorDtoRMB, EntrenadorRMB>();
            CreateMap<EntrenadorRMB, EntrenadorDtoRMB>();

            CreateMap<MembresiaDtoRMB, MembresiaRMB>();
            CreateMap<MembresiaRMB, MembresiaDtoRMB>();
            // mapping for relacionar cliente con membresias
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
            // CAMBIO: Mapeos para el DTO mejorado MembresiaConClienteYPagosDtoRMB
            // Mapeo de MembresiaRMB a MembresiaConClienteYPagosDtoRMB (usado en el servicio para relaciones)
            CreateMap<MembresiaRMB, MembresiaConClienteYPagosDtoRMB>();

            // CAMBIO: Mapeo para la información del cliente anidada
            CreateMap<ClienteRMB, ClienteInfoDtoRMB>();





        }
    }
}
