using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Entities
{
    internal class StoredFileEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public byte[] Address { get; set; }

        [Required]
        public byte[] FileData { get; set; }

        [Required]
        public DateTime CreatedAtUtc { get; set; }

        public string FileName { get; set; }
        public string ContentType { get; set; }
    }
}
