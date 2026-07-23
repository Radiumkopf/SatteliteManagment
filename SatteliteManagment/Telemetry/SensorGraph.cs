using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Telemetry
{
    internal class GraphSeries
    {
        public string Name { get; }

        public List<float> Values  = new List<float>();

        public GraphSeries(string name)
        {
            Name = name;
        }
    }

    internal class SensorGraph
    {
        public string Name { get; set; }

        public List<GraphSeries> Series { get; } = new List<GraphSeries>();

        public SensorGraph(string name) {
            this.Name = name;
        }

        
        override public string ToString()
        {
            return Name;
        }
    }
}
