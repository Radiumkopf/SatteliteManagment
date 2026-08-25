using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Entities.LeafEntities
{
    public enum CommandResult : byte
    {
        ACK = 0,
        NACK = 1,
        NoResult = 2

    }
}
