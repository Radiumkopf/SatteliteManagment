using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment
{
    public enum TriggerStatus: byte
    {
        Active = 0,
        DisableByUser = 1,
        Sent = 2
    }
    internal class Trigger
    {


        public byte[] address {  get; set; }
        public byte[] command { get; set; }
        public TriggerStatus status {  get; set; } 

        public Trigger(byte[] address, byte[] command)
        {
            this.address = address;
            this.command = command;
            this.status = TriggerStatus.Active;
        }

        public Trigger()
        {
        }

        public string StatusToString()
        {
            switch (this.status) {
                case TriggerStatus.Active:
                    return "Активен";
                case TriggerStatus.DisableByUser:
                    return "Отключен";
                case TriggerStatus.Sent:
                    return "Отправлен";
            }

            return null;
        }
    }
}
