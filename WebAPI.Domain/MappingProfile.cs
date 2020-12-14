using AutoMapper;
using WebAPI.Domain.Models;
using WebAPI.Domain.ViewModels.Relation;

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
