using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Pequam.Common.TypeMapping;
using Pequam.Data.Entities;
using Pequam.Web.Common;
using User = Pequam.Web.Api.Models.User;

namespace Pequam.Web.Api.AutoMappingConfiguration
{
    public class ChallengeParticipantsResolver : ValueResolver<Challenge, List<User>>
    {
        public IAutoMapper AutoMapper
        {
            get { return WebContainerManager.Get<IAutoMapper>(); }
        }

        protected override List<User> ResolveCore(Challenge source)
        {
            return source.Participants.Select(x => AutoMapper.Map<User>(x)).ToList();
        }
    }
}