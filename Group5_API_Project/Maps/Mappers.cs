using AutoMapper;
using Group5_API_Project.DTO;
using Group5_API_Project.Models;

namespace Group5_API_Project.Maps
{
    public class Mappers : Profile
    {
        public Mappers() 
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, ProductResponseDTO>().ReverseMap();
        }
    }
}
