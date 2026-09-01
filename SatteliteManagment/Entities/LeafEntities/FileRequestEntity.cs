using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Entities.LeafEntities
{
    internal class FileRequestEntity : IDbEntity
    {
        [Key]
        public int Id { get; set; }
        public int DescriptionId { get; set; }
        public PacketDescriptionEntity DescriptionEntity { get; set; }
        public CommandResult Result { get; set; } = CommandResult.NoResult;

        public byte FileId { get; set; }
        public ushort Number { get; set; }
        public byte Size { get; set; }
        public byte[] Data { get; set; } = Array.Empty<byte>();

        public FileRequestEntity(byte FileId, ushort Number, byte Size, byte[] Data)
        {
            this.FileId = FileId;
            this.Number = Number;
            this.Size = Size;
            this.Data = Data ?? Array.Empty<byte>();
        }
    }
}
