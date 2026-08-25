using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Entities.LeafEntities
{
    internal class MotorSpeedEntity : IDbEntity
    {
        [Key]
        public int Id { get; set; }
        public int DescriptionId { get; set; }
        public PacketDescriptionEntity DescriptionEntity { get; set; }
        public CommandResult Result { get; set; } = CommandResult.NoResult;


        [Required]
        public ushort Speed { get; set; }
    }
}
