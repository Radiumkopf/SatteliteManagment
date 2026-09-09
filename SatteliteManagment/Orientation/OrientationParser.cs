using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Orientation
{
    internal class OrientationParser
    {
        private static readonly int stepSize = 4;
        public static (float roll, float pitch, float yaw) Parse(byte[] data, int offset)
        {
            if (data.Length < offset + 16)
            {
                throw new ArgumentException("Data array is too short to contain quaternion values.");
            }

            float q0 = BitConverter.ToSingle(data, offset);
            float q1 = BitConverter.ToSingle(data, offset + stepSize);
            float q2 = BitConverter.ToSingle(data, offset + 2 * stepSize);
            float q3 = BitConverter.ToSingle(data, offset + 3 * stepSize);

            return ToEulerAngles(q0, q1, q2, q3);
        }
        public static ModelOrientation ParseToObj(byte[] data, int offset)
        {
            if (data.Length < offset + 16)
            {
                throw new ArgumentException("Data array is too short to contain quaternion values.");
            }

            float q0 = BitConverter.ToSingle(data, offset);
            float q1 = BitConverter.ToSingle(data, offset + stepSize);
            float q2 = BitConverter.ToSingle(data, offset + 2 * stepSize);
            float q3 = BitConverter.ToSingle(data, offset + 3 * stepSize);

            (float r, float p, float y) = ToEulerAngles(q0, q1, q2, q3);
            return new ModelOrientation { Roll = r, Pitch = p, Yaw = y };
        }

        public static (float roll, float pitch, float yaw) ToEulerAngles(float q0, float q1, float q2, float q3)
        {
            float roll = (float)Math.Atan2(2.0f * (q0 * q1 + q2 * q3), 1.0f - 2.0f * (q1 * q1 + q2 * q2))*180.0f/(float)Math.PI;
            float pitch = (float)Math.Asin(Clamp(2.0f * (q0 * q2 - q1 * q3), -1.0f, 1.0f))*180.0f/(float)Math.PI;
            float yaw = (float)Math.Atan2(2.0f * (q0 * q3 + q1 * q2), 1.0f - 2.0f * (q2 * q2 + q3 * q3))*180.0f/(float)Math.PI;
            return (roll, pitch, yaw);
        }

        private static float Clamp(float v, float lo, float hi)
        {
            return (v < lo) ? lo : ((v > hi) ? hi : v);
        }
    }
}
