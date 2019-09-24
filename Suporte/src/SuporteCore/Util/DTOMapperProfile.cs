using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SuporteCore.Entity;
using SuporteCore.Entity.DTO;

namespace SuporteCore.Util
{
    public class DTOMapperProfile : Profile
    {
        public DTOMapperProfile()
        {
            CreateMap<Phoebus, PhoebusDTO>();
            CreateMap<ListPaginacao<Phoebus>, ListPaginacao<PhoebusDTO>>();
        }
    }
}
