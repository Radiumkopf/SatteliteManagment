using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Entities
{
    internal class PacketDescriptionEntity : IDbEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public PacketType packetType { get; set; }

        public PacketDescriptionEntity(PacketType packetType) {  this.packetType = packetType; }

    }
}
