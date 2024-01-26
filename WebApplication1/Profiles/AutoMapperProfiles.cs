using AutoMapper;
using WebApplication1.DomainModels;
using Models = WebApplication1.Models;

namespace WebApplication1.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Models.Product, Product>().ReverseMap();
            CreateMap<Models.User, User>().ReverseMap();
            CreateMap<UpdateProductRequest, Models.Product>().ReverseMap();
            CreateMap<AddProductRequest, Models.Product>().ReverseMap();

        }
    }
}
