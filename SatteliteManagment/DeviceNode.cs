using System.Collections.Generic;

namespace SatteliteManagment
{
    internal class DeviceNode
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Status { get; set; } = "Unknown";
        public Dictionary<string, string> Meta { get; } = new Dictionary<string, string>();
        public List<DeviceNode> Children { get; } = new List<DeviceNode>();
    }
}
