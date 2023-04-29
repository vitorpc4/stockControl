using Application.Domain.Commands.ProductsCommands;
using Application.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Base.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductCommand, Products>().ReverseMap();
            CreateMap<UpdateProductCommand, Products>().ReverseMap();
        }
    }
}
