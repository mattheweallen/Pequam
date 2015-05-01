using System.Net.Http;
using System.Web.Http;
using Pequam.Web.Api.Models;
using Pequam.Web.Common.Routing;

namespace Pequam.Web.Api.Controllers.V1
{
    [ApiVersion1RoutePrefix("challenges")]
    public class ChallengesController : ApiController
    {
        [Route("", Name = "AddChallengeRoute")]
        [HttpPost]
        public Challenge AddChallenge(HttpRequestMessage requestMessage, Challenge newChallenge)
        {
            return new Challenge
            {
                Subject = "In v1, newChallenge.Subject = " + newChallenge.Subject
            };
        }
    }
}
