using AutoMapper;
using Pequam.Common.TypeMapping;
using Pequam.Web.Api.Models;
using Challenge = Pequam.Data.Entities.Challenge;

namespace Pequam.Web.Api.AutoMappingConfiguration
{
    public class NewChallengeToChallengeEntityAutoMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<NewChallenge, Challenge>()
                .ForMember(opt => opt.Version, x => x.Ignore())
                .ForMember(opt => opt.CreatedBy, x => x.Ignore())
                .ForMember(opt => opt.ChallengeId, x => x.Ignore())
                .ForMember(opt => opt.CreatedDate, x => x.Ignore())
                .ForMember(opt => opt.CompletedDate, x => x.Ignore())
                .ForMember(opt => opt.Status, x => x.Ignore())
                .ForMember(opt => opt.Participants, x => x.Ignore());
        }
    }
}