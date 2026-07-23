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
            new SensorGraph("Temperature 1")
                {
                    Series = { new GraphSeries("Temperature 1") }
                },

                new SensorGraph("Temperature 2")
                {
                    Series = { new GraphSeries("Temperature 2") }
                },

                new SensorGraph("Battery Voltage")
                {
                    Series = { new GraphSeries("Battery Voltage") }
                },

                new SensorGraph("PV Power")
                {
                    Series =
                    {
                        new GraphSeries("PV1"),
                        new GraphSeries("PV2"),
                        new GraphSeries("PV3")
                    }
                },

                new SensorGraph("Angular Rate")
                {
                    Series = { new GraphSeries("Angular Rate") }
                },
                new SensorGraph("Magnetic Field")
                {
                    Series = { new GraphSeries("Magnetic Field") }
                },
                new SensorGraph("Battery Charge")
                {
                    Series = { new GraphSeries("Battery Charge") }
                },
                new SensorGraph("Battery Discharge")
                {
                    Series = { new GraphSeries("Battery Discharge") }
                },
                new SensorGraph("Reset Counter")
                {
                    Series = { new GraphSeries("Reset Counter") }
                },
                new SensorGraph("Status Flags")
                {
                    Series = { new GraphSeries("Status Flags") }
                }
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

            sensors[0].Series[0].Values.Add(packet.Temperature1);
            sensors[1].Series[0].Values.Add(packet.Temperature2);

            sensors[2].Series[0].Values.Add(packet.BatteryV);

            sensors[3].Series[0].Values.Add(packet.PvPower[0]);
            sensors[3].Series[1].Values.Add(packet.PvPower[1]);
            sensors[3].Series[2].Values.Add(packet.PvPower[2]);

            sensors[4].Series[0].Values.Add(packet.AngularRate);


            sensors[5].Series[0].Values.Add(packet.MagFieldAbs);

            sensors[6].Series[0].Values.Add(packet.BatChargePower);
            sensors[7].Series[0].Values.Add(packet.BatDischargePower);

            sensors[8].Series[0].Values.Add(packet.ResetCounter);
            sensors[9].Series[0].Values.Add(packet.StatusFlags);

            logTexBoxes[index++].Text = packet.Temperature1.ToString(); 
            logTexBoxes[index++].Text = packet.Temperature2.ToString();
            logTexBoxes[index++].Text = packet.BatteryV.ToString();

            logTexBoxes[index].Text = packet.PvPower[0].ToString() + " | ";
            logTexBoxes[index].Text = packet.PvPower[1].ToString() + " | ";
            logTexBoxes[index++].Text = packet.PvPower[2].ToString();

            logTexBoxes[index++].Text = packet.AngularRate.ToString();
            logTexBoxes[index++].Text = packet.MagFieldAbs.ToString();
            logTexBoxes[index++].Text = packet.BatChargePower.ToString();
            logTexBoxes[index++].Text = packet.BatDischargePower.ToString();
            logTexBoxes[index++].Text = packet.ResetCounter.ToString();
            logTexBoxes[index++].Text = packet.StatusFlags.ToString();

        }




    }
}
