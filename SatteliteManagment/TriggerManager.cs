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
        private TriggerGridViewManager triggerGridViewManager;
        public TriggerManager() {
            triggers = new List<Trigger>();
        }

        public TriggerManager(TriggerGridViewManager gridViewManager)
        {
            triggers = new List<Trigger>();
            this.triggerGridViewManager = gridViewManager;
            triggerGridViewManager.StatusChange += ChangeTriggerStatusByAddress;
            triggerGridViewManager.AddressChanged += OnTriggerAddressChanged;
            triggerGridViewManager.CommandChanged += OnTriggerCommandChanged;
        }


        public Trigger GetTriggerByAddress(byte[] address)
        {
            return triggers.FirstOrDefault(t => t.address.SequenceEqual(address));

        }
        private void OnTriggerAddressChanged(byte[] oldAddress, byte[] newAddress)
        {
            Trigger trigger = GetTriggerByAddress(oldAddress);

            if (trigger != null)
            {
                trigger.address = newAddress;
            }
        }
        private void OnTriggerCommandChanged(byte[] address, byte[] newCommand)
        {
            Trigger trigger = GetTriggerByAddress(address);

            if (trigger != null)
            {
                trigger.command = newCommand;
            }
        }

        public void ChangeTriggerStatusByAddress(byte[] address, TriggerStatus status)
        {
            foreach (var trigger in triggers)
            {
                if (trigger.address.SequenceEqual(address)) trigger.status = status;
            }
        }

        public void ChangeTriggerStatus(Trigger trigger, TriggerStatus status)
        {
            trigger.status = status;
            triggerGridViewManager.SetRowStatusByAddress(trigger.address, status);
        }

        public void AddTrigger(Trigger trigger)
        {
            triggers.Add(trigger);
            triggerGridViewManager.AddRow(trigger);
        }

        public void DeleteTrigger(byte[] address) 
        {
            foreach (var trigger in triggers)
            {
                if (trigger.address.SequenceEqual(address))
                {
                    triggers.Remove(trigger);
                    triggerGridViewManager.RemoveRow(address);
                    return;
                }
            }
            Console.WriteLine("Указанный триггер не найден");
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

            triggerGridViewManager.RestartTriggers();
        }


    }
}
