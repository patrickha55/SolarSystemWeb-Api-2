using AutoMapper;
using Data.DTOs;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<Region, RegionDTO>().ReverseMap();
        }
    }
}
