using AutoMapper;
using publicApi.Model.Models;
using publicApi.Model.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace publicApi.Model.Profiles
{
    public class usuarioProfile:Profile
    {
        public usuarioProfile() 
        {
            CreateMap<usuario, usuarioDto>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.firstName, opt => opt.MapFrom(src => src.firstName))
                .ForMember(dest => dest.lastName, opt => opt.MapFrom(src => src.lastName))
                .ForMember(dest => dest.userName, opt => opt.MapFrom(src => src.userName))
                .ForMember(dest => dest.typeId, opt => opt.MapFrom(src => src.typeId))
                .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.email));
            CreateMap<usuarioDto, usuario>();
        }
    }
}
