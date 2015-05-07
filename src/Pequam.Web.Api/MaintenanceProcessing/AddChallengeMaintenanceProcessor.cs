using System.Net.Http;
using Pequam.Common.TypeMapping;
using Pequam.Data.QueryProcessors;
//using Pequam.Web.Api.LinkServices;
using Pequam.Web.Api.Models;
using Pequam.Common;

namespace Pequam.Web.Api.MaintenanceProcessing
{
    public class AddChallengeMaintenanceProcessor : IAddChallengeMaintenanceProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly IAddChallengeQueryProcessor _queryProcessor;
        //private readonly IChallengeLinkService _challengeLinkService;

        public AddChallengeMaintenanceProcessor(IAddChallengeQueryProcessor queryProcessor, IAutoMapper autoMapper)
        {
            _queryProcessor = queryProcessor;
            _autoMapper = autoMapper;
            //_taskLinkService = taskLinkService;
        }

        public Challenge AddChallenge(NewChallenge newChallenge)
        {
            var challengeEntity = _autoMapper.Map<Data.Entities.Challenge>(newChallenge);

            _queryProcessor.AddChallenge(challengeEntity);

            var challenge = _autoMapper.Map<Challenge>(challengeEntity);

            //_challengeLinkService.AddLinks(task);

            //TODO: Implement link service
            challenge.AddLink(new Link
            {
                Method = HttpMethod.Get.Method,
                Href = "http://localhost:57377/api/v1/challenges/" + challenge.ChallengeId,
                Rel = Constants.CommonLinkRelValues.Self
            });

            return challenge;
        }
    }
}