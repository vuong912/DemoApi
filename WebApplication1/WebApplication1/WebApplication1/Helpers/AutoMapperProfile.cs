using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApplication1.Dtos;
using WebApplication1.Entities;
namespace WebApplication1.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<Bill, BillDto>();
            CreateMap<BillDto,Bill>();
            CreateMap<BillDetailDto, BillDetail>();
            CreateMap<BillDetail, BillDetailDto>();
            CreateMap<UserDto, Account>();
            CreateMap<Account, UserDto>();
        }
    }
}
