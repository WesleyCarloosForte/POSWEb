using AutoMapper;
using SharedProject.DTOs;
using SharedProject.Models;

namespace Backend.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Categoria, CategoriaViewDTO>();
            CreateMap<CategoriaViewDTO, Categoria>();

            CreateMap<CategoriaCreateDTO, Categoria>();
            CreateMap<Categoria,CategoriaCreateDTO>();

            CreateMap<Rol, RolViewDTO>();
            CreateMap<RolViewDTO, Rol>();

            CreateMap<CategoriaCreateDTO, Categoria>();
            CreateMap<Categoria, CategoriaCreateDTO>();

            CreateMap<DetalleVenta, CreateDetalleVentaDTO>();

            CreateMap<CreateDetalleVentaDTO, DetalleVenta>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Venta, opt => opt.Ignore())
               .ForMember(dest => dest.Producto, opt => opt.Ignore());

            CreateMap<CreateVentaDTO, Venta>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.DetallesVenta, opt => opt.MapFrom(src => src.DetallesVenta));

            CreateMap<Venta, CreateVentaDTO>();

            CreateMap<Venta, CreateVentaDTO>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => src.Fecha))
               .ForMember(dest => dest.NumeroComprobante, opt => opt.MapFrom(src => src.NumeroComprobante))
               .ForMember(dest => dest.TotalCompra, opt => opt.MapFrom(src => src.TotalCompra))
               .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado))
               .ForMember(dest => dest.DetallesVenta, opt => opt.MapFrom(src => src.DetallesVenta))
               .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(src => src.ClienteId))
               .ForMember(dest => dest.ComprobanteId, opt => opt.MapFrom(src => src.ComprobanteId))
               .ForMember(dest => dest.Timbrado, opt => opt.MapFrom(src => src.Timbrado))
               .ForMember(dest => dest.Establecimiento, opt => opt.MapFrom(src => src.Establecimiento))
               .ForMember(dest => dest.PuntoExpedicion, opt => opt.MapFrom(src => src.PuntoExpedicion));


            CreateMap<DetalleCompra, DetalleCompraCreateDTO>();

            CreateMap<DetalleCompraCreateDTO, DetalleCompra>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Compra, opt => opt.Ignore())
               .ForMember(dest => dest.Producto, opt => opt.Ignore());

            CreateMap<CompraCreateDTO, Compra>()
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.DetallesCompra, opt => opt.MapFrom(src => src.DetallesCompra));

            CreateMap<Compra, CompraCreateDTO>();

            CreateMap<Compra, CompraViewDTO>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Proveedor, opt => opt.MapFrom(src => src.Proveedor))
               .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => src.Fecha))
               .ForMember(dest => dest.NumeroComprobante, opt => opt.MapFrom(src => src.NumeroComprobante))
               .ForMember(dest => dest.TotalCompra, opt => opt.MapFrom(src => src.TotalCompra))
               .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado))
               .ForMember(dest => dest.DetalleCompra, opt => opt.MapFrom(src => src.DetallesCompra));



            CreateMap<ProveedorCreateDTO, Proveedor>()
                       .ForMember(dest => dest.Id, opt => opt.Ignore())
                       .ForMember(dest => dest.DatosGeneralesId, opt => opt.Ignore())

                       .ForMember(dest => dest.DatosGenerales, opt => opt.MapFrom(src => new DatosGenerales
                       {
                           Nombre = src.Nombre,
                           Direccion = src.Direccion,
                           Telefono = src.Telefono,
                           DocumentoId = src.DocumentoId,
                           Email = src.Email,
                           Estado = src.Estado,
                           NumeroDocumento = src.NumeroDocumento

                       }));

            CreateMap<Proveedor, ProveedorCreateDTO>()
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.DatosGenerales.Nombre))
                .ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => src.DatosGenerales.Direccion))
                .ForMember(dest => dest.Telefono, opt => opt.MapFrom(src => src.DatosGenerales.Telefono))
                .ForMember(dest => dest.DocumentoId, opt => opt.MapFrom(src => src.DatosGenerales.DocumentoId))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.DatosGenerales.Email))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.DatosGenerales.Estado))
                .ForMember(dest => dest.NumeroDocumento, opt => opt.MapFrom(src => src.DatosGenerales.NumeroDocumento));


            CreateMap<Cliente, ClienteDTO>(); // Mapeo de Usuario a UsuarioDTO
            CreateMap<ClienteDTO, Cliente>();

            CreateMap<Cliente, ClienteViewDTO>(); // Mapeo de Usuario a UsuarioDTO
            CreateMap<ClienteViewDTO, Cliente>();

            CreateMap<Cliente, ClienteCreateDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.DatosGenerales.Nombre))
                .ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => src.DatosGenerales.Direccion))
                .ForMember(dest => dest.Telefono, opt => opt.MapFrom(src => src.DatosGenerales.Telefono))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.DatosGenerales.Email))
                .ForMember(dest => dest.NumeroDocumento, opt => opt.MapFrom(src => src.DatosGenerales.NumeroDocumento))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.DatosGenerales.Estado))
                .ForMember(dest => dest.DocumentoId, opt => opt.MapFrom(src => src.DatosGenerales.DocumentoId));

            CreateMap<ClienteCreateDTO, Cliente>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DatosGeneralesId, opt => opt.Ignore())
                .ForMember(dest => dest.DatosGenerales, opt => opt.MapFrom(src => new DatosGenerales
                {
                    Nombre = src.Nombre,
                    Direccion = src.Direccion,
                    Telefono = src.Telefono,
                    Email = src.Email,
                    NumeroDocumento = src.NumeroDocumento,
                    Estado = src.Estado,
                    DocumentoId = src.DocumentoId
                }));

            CreateMap<Proveedor, ProveedorViewDTO>().ForMember(dst=>dst.Compras,op=>op.Ignore());

            CreateMap<ProveedorViewDTO, Proveedor>().ForMember(dst => dst.Compras, op => op.Ignore()); ;



            CreateMap<Usuario, UsuarioDTO>(); // Mapeo de Usuario a UsuarioDTO
            CreateMap<UsuarioDTO, Usuario>();

            CreateMap<Usuario, UsuarioViewDTO>(); // Mapeo de Usuario a UsuarioDTO
            CreateMap<UsuarioViewDTO, Usuario>();


            CreateMap<Cliente, ClienteViewDTO>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
             .ForMember(dest => dest.DatosGeneralesId, opt => opt.MapFrom(src => src.DatosGeneralesId))
                .ForMember(dest => dest.DatosGenerales, opt => opt.MapFrom(src => src.DatosGenerales));


            CreateMap<UsuarioCreateDTO, Usuario>()
                       .ForMember(dest => dest.Id, opt => opt.Ignore())
                       .ForMember(dest => dest.DatosGeneralesId, opt => opt.Ignore())
                      
                       .ForMember(dest => dest.DatosGenerales, opt => opt.MapFrom(src => new DatosGenerales
                       {
                           Nombre = src.Nombre,
                           Direccion = src.Direccion,
                           Telefono = src.Telefono,
                           DocumentoId= src.DocumentoId,
                           Email= src.Email,
                           Estado= src.Estado,
                           NumeroDocumento = src.NumeroDocumento
                           
                       }));

            CreateMap<Usuario, UsuarioCreateDTO>()
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.DatosGenerales.Nombre))
                .ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => src.DatosGenerales.Direccion))
                .ForMember(dest => dest.Telefono, opt => opt.MapFrom(src => src.DatosGenerales.Telefono))
                .ForMember(dest => dest.DocumentoId, opt => opt.MapFrom(src => src.DatosGenerales.DocumentoId))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.DatosGenerales.Email))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.DatosGenerales.Estado))
                .ForMember(dest=>dest.NumeroDocumento,opt=>opt.MapFrom(src=>src.DatosGenerales.NumeroDocumento));
        }
    }
}
