using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.IO;


namespace SatteliteManagment.Orientation
{
    internal class OrientationHistory
    {

        public  List<ModelOrientation> _items { get; set; } = new List<ModelOrientation>();

        public int Count => _items.Count;

        public ModelOrientation this[int index] => _items[index];

        public void Add(ModelOrientation orientation)
        {
            _items.Add(orientation);

            if (_items.Count > 1000)
                _items.RemoveAt(0);
        }


        public static List<ModelOrientation> ReadRotations(string filePath)
        {
            var rotations = new List<ModelOrientation>();

            string[] lines = File.ReadAllLines(filePath);

            ModelOrientation current = null;

            foreach (string line in lines)
            {
                string text = line.Trim();

                if (string.IsNullOrWhiteSpace(text))
                    continue;

                if (current == null)
                    current = new ModelOrientation();

                if (text.StartsWith("roll"))
                {
                    current.Roll = (float)ParseValue(text);
                }
                else if (text.StartsWith("pitch"))
                {
                    current.Pitch = (float)ParseValue(text);
                }
                else if (text.StartsWith("yaw"))
                {
                    current.Yaw = (float)ParseValue(text);

                    // yaw является последним полем записи
                    rotations.Add(current);
                    current = null;
                }
            }

            return rotations;
        }

        private static double ParseValue(string line)
        {
            // "roll = 123.45;" -> "123.45"
            string value = line
                .Split('=')[1]
                .Trim()
                .TrimEnd(';');

            return double.Parse(value, CultureInfo.InvariantCulture);
        }

        public static List<ModelOrientation> ReadQuaternions(string filePath)
        {
            var rotations = new List<ModelOrientation>();

            foreach (string line in File.ReadLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] parts = line.Split(';');

                if (parts.Length != 4)
                    continue;

                if (!float.TryParse(parts[0], NumberStyles.Float,
                        CultureInfo.InvariantCulture, out float q0))
                    continue;

                if (!float.TryParse(parts[1], NumberStyles.Float,
                        CultureInfo.InvariantCulture, out float q1))
                    continue;

                if (!float.TryParse(parts[2], NumberStyles.Float,
                        CultureInfo.InvariantCulture, out float q2))
                    continue;

                if (!float.TryParse(parts[3], NumberStyles.Float,
                        CultureInfo.InvariantCulture, out float q3))
                    continue;

                // Quaternion -> Euler angles
                var (roll, pitch, yaw) = OrientationParser.ToEulerAngles(q0, q1, q2, q3);

                rotations.Add(new ModelOrientation(roll, pitch, yaw ));
            }

            return rotations;
        }
    }
}
