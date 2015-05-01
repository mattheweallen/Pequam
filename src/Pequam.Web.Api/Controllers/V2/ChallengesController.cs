using System.Net.Http;
using System.Web.Http;
using Pequam.Web.Api.Models;

namespace Pequam.Web.Api.Controllers.V2
{
    [RoutePrefix("api/{apiVersion:apiVersionConstraint(v2)}/challenges")]
    public class ChallengesController : ApiController
    {
        [Route("", Name = "AddChallengeRouteV2")]
        [HttpPost]
        public Challenge AddChallenge(HttpRequestMessage requestMessage, Challenge newChallenge)
        {
            return new Challenge
            {
                Subject = "In v2, newChallenge.Subject = " + newChallenge.Subject
            };
        }
    }
}
