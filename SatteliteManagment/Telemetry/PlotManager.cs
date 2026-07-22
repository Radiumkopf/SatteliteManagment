using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SatteliteManagment.Telemetry
{
    internal class PlotManager
    {
        DuplexTcpClient client;
        TextBox[] logTexBoxes;

        public List<SensorGraph> sensors = new List<SensorGraph>() {     
            new SensorGraph("Temperature 1"),
            new SensorGraph("Temperature 2"),
            new SensorGraph("Battery Voltage"),
            new SensorGraph("PV Power 1"),
            new SensorGraph("PV Power 2"),
            new SensorGraph("PV Power 3"),
            new SensorGraph("Angular Rate"),
            new SensorGraph("Magnetic Field"),
            new SensorGraph("Battery Charge"),
            new SensorGraph("Battery Discharge"),
            new SensorGraph("Reset"),
            new SensorGraph("StatusFlag")
        };

        public PlotManager( DuplexTcpClient client, TextBox[] textBoxes)
        {
            this.client = client;

            client.TelemetryReceived += AddTelemetryPacket;

            this.logTexBoxes = textBoxes;
        }

        private void AddTelemetryPacket(TlmPacket packet)
        {
            int index = 0;

            sensors[0].Values.Add(packet.Temperature1);
            sensors[1].Values.Add(packet.Temperature2);

            sensors[2].Values.Add(packet.BatteryV);

            sensors[3].Values.Add(packet.PvPower[0]);       //later
            sensors[4].Values.Add(packet.PvPower[1]);
            sensors[5].Values.Add(packet.PvPower[2]);

            sensors[6].Values.Add(packet.AngularRate);


            sensors[7].Values.Add(packet.MagFieldAbs);

            sensors[8].Values.Add(packet.BatChargePower);
            sensors[9].Values.Add(packet.BatDischargePower);
            sensors[10].Values.Add(packet.ResetCounter);
            sensors[11].Values.Add(packet.StatusFlags);

            logTexBoxes[index++].Text = packet.Temperature1.ToString(); 
            logTexBoxes[index++].Text = packet.Temperature2.ToString();
            logTexBoxes[index++].Text = packet.BatteryV.ToString();
            index++;
            logTexBoxes[index++].Text = packet.AngularRate.ToString();
            logTexBoxes[index++].Text = packet.MagFieldAbs.ToString();
            logTexBoxes[index++].Text = packet.BatChargePower.ToString();
            logTexBoxes[index++].Text = packet.BatDischargePower.ToString();
            logTexBoxes[index++].Text = packet.ResetCounter.ToString();
            logTexBoxes[index++].Text = packet.StatusFlags.ToString();

        }




    }
}
