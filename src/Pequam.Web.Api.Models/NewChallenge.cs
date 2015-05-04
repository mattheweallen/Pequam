using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;

namespace Pequam.Web.Api.Models
{
    public class NewChallenge
    {
        //[Required(AllowEmptyStrings = false)]
        public string Subject { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? DueDate { get; set; }

        public List<User> Participants { get; set; }
    }
}
