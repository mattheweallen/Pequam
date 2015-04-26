using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pequam.Data.Entities
{
    public class Challenge
    {
        private readonly IList<Participant> _participants = new List<Participant>();

        public virtual long ChallengeId { get; set; }
        public virtual string Subject { get; set; }
        public virtual DateTime? StartDate { get; set; }
        public virtual DateTime? DueDate { get; set; }
        public virtual DateTime? CompletedDate { get; set; }
        public virtual Status Status { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual Participant CreatedBy { get; set; }

        public virtual IList<Participant> Participants
        {
            get { return _participants; }
        }

        public virtual byte[] Version { get; set; }
    }
}
