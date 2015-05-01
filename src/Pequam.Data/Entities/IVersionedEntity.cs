using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pequam.Data.Entities
{
    public interface IVersionedEntity
    {
        byte[] Version { get; set; }
    }
}
