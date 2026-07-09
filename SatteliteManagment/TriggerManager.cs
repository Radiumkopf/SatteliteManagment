using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SatteliteManagment
{
    internal class TriggerManager
    {

        private List<Trigger> triggers;

        public TriggerManager() {
            triggers = new List<Trigger>();
        }

        public Trigger GetTriggerByAddress(byte[] address)
        {
            foreach (var trigger in triggers)
            {
                if(trigger.address.SequenceEqual(address)) return trigger;
            }
            return null;
        }

        public void ChangeTriggerStatusByAddress(byte[] address, TriggerStatus status)
        {
            foreach (var trigger in triggers)
            {
                if (trigger.address.SequenceEqual(address)) trigger.status = status;
            }
        }

        public void AddTrigger(Trigger trigger)
        {
            triggers.Add(trigger);
        }

        public void DeleteTrigger(byte[] address) 
        {
            foreach (var trigger in triggers)
            {
                if (trigger.address.SequenceEqual(address))
                {
                    triggers.Remove(trigger);
                    return;
                }
            }
        }

        public void RestartTriggers()
        {
            foreach(var trigger in triggers)
            {
                if(trigger.status == TriggerStatus.Sent)
                {
                    trigger.status = TriggerStatus.Active;
                }
            }
        }


    }
}
