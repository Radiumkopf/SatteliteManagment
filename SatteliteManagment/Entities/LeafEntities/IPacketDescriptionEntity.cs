using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Entities.LeafEntities
{
    internal interface IPacketDescriptionEntity
    {
        int DescriptionId { get; set; }
        PacketDescriptionEntity DescriptionEntity { get; set; }
    }
}
