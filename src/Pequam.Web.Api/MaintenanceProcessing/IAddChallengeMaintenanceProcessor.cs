using Pequam.Web.Api.Models;

namespace Pequam.Web.Api.MaintenanceProcessing
{
    public interface IAddChallengeMaintenanceProcessor
    {
        Challenge AddChallenge(NewChallenge newChallenge);
    }
}
