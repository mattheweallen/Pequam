using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Challenge = Pequam.Web.Api.Models.Challenge;

namespace Pequam.Web.Api.MaintenanceProcessing
{
    public class ChallengeCreatedActionResult : IHttpActionResult
    {
        private readonly Challenge _createdChallenge;
        private readonly HttpRequestMessage _requestMessage;

        public ChallengeCreatedActionResult(HttpRequestMessage requestMessage,
            Challenge createdChallenge)
        {
            _requestMessage = requestMessage;
            _createdChallenge = createdChallenge;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return System.Threading.Tasks.Task.FromResult(Execute());
        }

        public HttpResponseMessage Execute()
        {
            var acceptHeader = _requestMessage.Headers.Accept.FirstOrDefault();
            var mediaType = acceptHeader == null ? null : acceptHeader.MediaType;

            var responseMessage = string.IsNullOrWhiteSpace(mediaType)
                ? _requestMessage.CreateResponse(HttpStatusCode.Created, _createdChallenge)
                : _requestMessage.CreateResponse(HttpStatusCode.Created, _createdChallenge, mediaType);

            responseMessage.Headers.Location = LocationLinkCalculator.GetLocationLink(_createdChallenge);

            return responseMessage;
        }
    }
}