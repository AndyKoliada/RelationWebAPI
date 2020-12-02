using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ModelsConnected;
using WebAPI.ModelsConnected.ViewModel;

namespace WebAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Relation, RelationDetailsViewModel>();
            CreateMap<Relation, RelationDetailsCreateModel>();
            CreateMap<Relation, RelationDetailsEditModel>();
        }
    }
}
