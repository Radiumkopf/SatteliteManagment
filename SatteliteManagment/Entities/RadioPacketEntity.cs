using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Entities
{
    internal class RadioPacketEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime dateTime { get; set; } = DateTime.Now;

        public PacketInfoEntity PacketInfo { get; set; }
        public int PacketInfoId { get; set; }

        public PacketDescriptionEntity PacketDescription { get; set; }
        public int DescriptionId { get; set; }

        public string SenderName { get; set; }
        public string ReceiverName { get; set; }

    }
}
