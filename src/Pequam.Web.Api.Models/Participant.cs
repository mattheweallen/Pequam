using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pequam.Web.Api.Models
{
    public class Participant
    {
        private List<Link> _links;

        public long ParticipantId { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public List<Link> Links
        {
            get { return _links ?? (_links = new List<Link>());  }
            set { _links = value; }
        }

        public void AddLink(Link link)
        {
            Links.Add(link);
        }
    }
}
