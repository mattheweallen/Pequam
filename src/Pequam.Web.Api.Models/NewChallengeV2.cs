using System;

namespace Pequam.Web.Api.Models
{
    public class NewChallengeV2
    {
        public string Subject { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? DueDate { get; set; }

        public User Participant { get; set; }
    }
}
