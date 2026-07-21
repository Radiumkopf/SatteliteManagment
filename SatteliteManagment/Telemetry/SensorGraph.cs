using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Telemetry
{
    internal class SensorGraph
    {
        public string Name { get; set; }

        public List<float> Values { get; } = new List<float>();

        public SensorGraph(string name) {
            this.Name = name;
        }
    }
}
