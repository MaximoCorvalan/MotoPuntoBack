using AutoMapper;
using MotoPuntoBack.DTOs;
using MotoPuntoBack.Models;

namespace MotoPuntoBack.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()          
        {

            CreateMap<MarcaDTO, Marca>().ForMember(dest => dest.Motos, opt => opt.Ignore());
            CreateMap<Imagen, ImagenDTO>();
            CreateMap<ImagenDTO, Imagen>();
            CreateMap<UsuarioDTO, Usuario>()
           .ForMember(dest => dest.IdrolNavigation, opt => opt.Ignore()) // Se ignora porque viene por separado o se carga en el contexto
          .ForMember(dest => dest.Consulta, opt => opt.Ignore());
            CreateMap<Consultum, ConsultaDTO>().ForMember(dest => dest.NombreUsuario, opt => opt.MapFrom(src => src.IdusuarioNavigation != null ? src.IdusuarioNavigation.Nombre : string.Empty))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.IdusuarioNavigation != null ? src.IdusuarioNavigation.Email : string.Empty))
                .ForMember(dest => dest.NumeroTelefono, opt => opt.MapFrom(src => src.IdusuarioNavigation != null ? src.IdusuarioNavigation.Numero : string.Empty))
                .ForMember(dest => dest.NombreMoto, opt => opt.MapFrom(src => src.IdmotoNavigation != null ? src.IdmotoNavigation.Nombre : string.Empty))
                .ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => src.IdusuarioNavigation.Direccion != null ? src.IdusuarioNavigation.Direccion : string.Empty))
                .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => src.Fecha != null ? src.Fecha.Value.ToString("dd/MM/yyyy") : string.Empty))
                .ForMember(dest => dest.FechaContacto, opt => opt.MapFrom(src => src.FechaContacto != null ? src.FechaContacto.Value.ToString("dd/MM/yyyy") : string.Empty));

            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<ConsultaDTOPost, Consultum>().ForMember(dest => dest.IdmotoNavigation, opt => opt.Ignore()).ForMember(dest => dest.IdusuarioNavigation, opt =>
            opt.Ignore());


            CreateMap<Moto, MotoDTO>()
                .ForMember(dest => dest.MarcaDescripcion, opt => opt.MapFrom(src => src.IdmarcaNavigation != null ? src.IdmarcaNavigation.Descripcion : string.Empty)).
                ForMember(dest=>dest.Imagens,opt=>opt.MapFrom(src=>src.Imagens));

          

              CreateMap<PostMotoDTO, Moto>()
                .ForMember(dest => dest.Idmarca, opt => opt.MapFrom(src => src.IdMarca ?? 0))
 
                .ForMember(dest => dest.Imagens, opt => opt.MapFrom(src => src.Imagenes));
 


        }
    }
}
