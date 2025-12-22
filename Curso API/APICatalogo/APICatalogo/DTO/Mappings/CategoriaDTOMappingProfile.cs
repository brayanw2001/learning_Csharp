using APICatalogo.Domain_Models;
using AutoMapper;

namespace APICatalogo.DTO.Mappings
{
    public class CategoriaDTOMappingProfile : Profile
    {
        public CategoriaDTOMappingProfile()
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
        }
    }
}
