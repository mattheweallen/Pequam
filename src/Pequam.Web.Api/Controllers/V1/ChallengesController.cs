using System.Net.Http;
using System.Web.Http;
using Pequam.Web.Api.Models;
using Pequam.Web.Common.Routing;
using Pequam.Web.Common;

namespace Pequam.Web.Api.Controllers.V1
{
    [ApiVersion1RoutePrefix("challenges")]
    [UnitOfWorkActionFilter]
    public class ChallengesController : ApiController
    {
        [Route("", Name = "AddChallengeRoute")]
        [HttpPost]
        public Challenge AddChallenge(HttpRequestMessage requestMessage, NewChallenge newChallenge)
        {
            return new Challenge
            {
                Subject = "In v1, newChallenge.Subject = " + newChallenge.Subject
            };
        }
    }
}
