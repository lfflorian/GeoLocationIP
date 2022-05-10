using AutoMapper;
using GeoAPI.Entities;
using GeoAPI.webapi.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoAPI.webapi.Middleware
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            this.CreateMap<IPLocation, IPLocationDto>(MemberList.None)
                .ForMember(identity => identity.IP, dto => dto.MapFrom(model => model.IP))
                .ForMember(identity => identity.Geolocation, dto => dto.MapFrom(model => model.Geolocation));
        }
    }
}
