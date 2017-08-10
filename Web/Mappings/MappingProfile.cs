using AutoMapper;
using Core.Models;
using Web.Controllers.Api.Resources;

namespace Web.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain To API
            CreateMap<Customer, CustomerResource>();
            CreateMap<Product, ProductResource>();

            // API to Domain
            CreateMap<CustomerResource, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore())
                .ForMember(c => c.Products, opt => opt.Ignore());
        }
    }
}
