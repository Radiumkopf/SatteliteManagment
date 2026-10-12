using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Selector
{
    public class FileRequestState
    {
        public ushort Number { get; }
        public byte Size { get; set; }

        public bool IsSent { get; set; }
        public bool IsAckReceived { get; set; }

        public FileRequestState(ushort number, byte size)
        {
            Number = number;
            Size = size;
        }
    }
}
