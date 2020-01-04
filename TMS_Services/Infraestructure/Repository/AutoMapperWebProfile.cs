using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMS_Services.Models;
using TMS_Services.Models.DTO;
using TMS_Services.Models.DTO.ViewModels;

namespace TMS_Services.Infraestructure.Repository
{
    public class AutoMapperWebProfile : Profile
    {
        public static IMapper Run()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddProfile(new AutoMapperWebProfile());
                }
            );
            return config.CreateMapper();
            
        }

        // no utilzado actualmente
        public AutoMapperWebProfile()
        {
            CreateMap<CredencialApiModel,AccesoApiViewModel>()
                .ForMember(dest => dest.username, map => map.MapFrom(src => src.userName))
                .ForMember(dest => dest.password, map => map.MapFrom(src => src.password))
                .ForMember(dest => dest.relationTipoCredencialid, map => map.MapFrom(src => src.relationTipoCredencial.id));
        }
    }
}