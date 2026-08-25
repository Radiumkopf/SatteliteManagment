using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Entities
{
    internal class PacketDescriptionEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public PacketType packetType { get; set; }


    }
}
