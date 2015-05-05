using AutoMapper;
using Pequam.Common.TypeMapping;
using Pequam.Data.Entities;

namespace Pequam.Web.Api.AutoMappingConfiguration
{
    public class ChallengeEntityToChallengeAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Challenge, Models.Challenge>()
                .ForMember(opt => opt.Links, x => x.Ignore())
                .ForMember(opt => opt.Participants, x => x.ResolveUsing<ChallengeParticipantsResolver>());
        }
    }
}