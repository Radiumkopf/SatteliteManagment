using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if(trigger.address.Equals(address)) return trigger;
            }
            return null;
        }

        public void ChangeTriggerStatusByAddress(byte[] address, TriggerStatus status)
        {
            foreach (var trigger in triggers)
            {
                if (trigger.address.Equals(address)) trigger.status = status;
            }
        }

        public void AddTrigger(Trigger trigger)
        {
            triggers.Add(trigger);
        }

    }
}
