using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Entities.LeafEntities
{
    internal class ModuleStatusEntity : IDbEntity
    {
        [Key]
        public int Id { get; set; }
        public int DescriptionId { get; set; }
        public PacketDescriptionEntity DescriptionEntity { get; set; }


        [Required]
        public int ModuleId { get; set; }
        public string ModuleStatus { get; set; }
    }
}
