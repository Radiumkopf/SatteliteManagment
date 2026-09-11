using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Orientation
{
    internal class ModelOrientation
    {
        public float Roll { get; set; }
        public float Pitch { get; set; }
        public float Yaw { get; set; }

        public ModelOrientation()
        {
            Roll = 0;
            Pitch = 0;
            Yaw = 0;
        }
        public ModelOrientation(float roll, float pitch, float yaw)
        {
            Roll = roll;
            Pitch = pitch;
            Yaw = yaw;
        }
    }
}
