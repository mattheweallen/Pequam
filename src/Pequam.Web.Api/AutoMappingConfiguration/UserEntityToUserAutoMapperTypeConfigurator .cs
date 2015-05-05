using AutoMapper;
using Pequam.Common.TypeMapping;
using Pequam.Data.Entities;

namespace Pequam.Web.Api.AutoMappingConfiguration
{
    public class UserEntityToUserAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<User, Models.User>()
                .ForMember(opt => opt.Links, x => x.Ignore());
        }
    }
}