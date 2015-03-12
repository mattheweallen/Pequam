﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pequam.Data.Entities
{
    class User
    {
        public virtual long UserId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string UserName { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual byte[] Version { get; set; }
     }
}