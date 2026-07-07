using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment
{
    internal class Trigger
    {


        public byte[] address {  get; set; }
        public byte[] command { get; set; }
        public bool isActive {  get; set; }

        public Trigger(byte[] address, byte[] command)
        {
            this.address = address;
            this.command = command;
            this.isActive = true;
        }

        public Trigger()
        {
        }
    }
}
