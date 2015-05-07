using System.Net.Http;
using System.Web.Http;
using Pequam.Web.Api.Models;
using Pequam.Web.Common.Routing;
using Pequam.Web.Common;
using Pequam.Web.Api.MaintenanceProcessing;

namespace Pequam.Web.Api.Controllers.V1
{
    [ApiVersion1RoutePrefix("challenges")]
    [UnitOfWorkActionFilter]
    public class ChallengesController : ApiController
    {
        private readonly IAddChallengeMaintenanceProcessor _addChallengeMaintenanceProcessor;

        public ChallengesController(IAddChallengeMaintenanceProcessor addChallengeMaintenanceProcessor)
        {
            _addChallengeMaintenanceProcessor = addChallengeMaintenanceProcessor;
        }

        [Route("", Name = "AddChallengeRoute")]
        [HttpPost]
        public IHttpActionResult AddChallenge(HttpRequestMessage requestMessage, NewChallenge newChallenge)
        {
            var challenge = _addChallengeMaintenanceProcessor.AddChallenge(newChallenge);
            var result = new ChallengeCreatedActionResult(requestMessage, challenge);
            return result;
        }
    }
}
