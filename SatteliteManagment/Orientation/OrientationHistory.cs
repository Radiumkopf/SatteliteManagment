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
        public  List<ModelOrientation> Items { get; set; } = new List<ModelOrientation>();
        //public List<DateTime> Times { get; set; } = new List<DateTime>();
        public ulong CurrentAddress { get; set; } = 0;
        public Dictionary<ulong, List<ModelOrientation>> AddressOrientationTable { get; set; } = new Dictionary<ulong, List<ModelOrientation>>();
        
        public int Count => Items.Count;

        public ModelOrientation this[int index] => Items[index];

        public DateTime GetTime(int index)
        {
            if (index> Items.Count)
            {
                return DateTime.MinValue;
            }
            return Items[index].Time;
        }
        public void Add(ModelOrientation orientation)
        {
            Items.Add(orientation);

            if (Items.Count > 1000)
            {
                Items.RemoveAt(0);
            }
        }
        public void RestoreHistory(ulong newAddress)
        {
            CurrentAddress = newAddress;
            if (AddressOrientationTable.TryGetValue(newAddress, out var _items))
            {
                Items = _items;
            }
        }
        public void AddOrientationToTable(ulong address, ModelOrientation orientation) { 
            if (!AddressOrientationTable.TryGetValue(address, out var list)) { 
                list = new List<ModelOrientation>(); 
                AddressOrientationTable[address] = list; 
            } 
            list.Add(orientation);
            if (list.Count > 1000)
            {
                list.RemoveAt(0);
            }
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
