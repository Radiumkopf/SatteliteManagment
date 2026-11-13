using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;


namespace SatteliteManagment.Orientation
{
    internal class OrientationHistory
    {
        private const int MaxHistorySize = 1000;

        public Dictionary<ulong, List<ModelOrientation>> AddressOrientationTable { get; } = new Dictionary<ulong, List<ModelOrientation>>();

        // Единственный список адресов для интерфейса.
        public BindingList<ulong> AddressListUI { get; } = new BindingList<ulong>();

        // История выбранного устройства.
        public List<ModelOrientation> Items { get;  set; } = new List<ModelOrientation>();

        public ulong CurrentAddress { get; private set; } = 0;

        public int Count => Items.Count;

        public ModelOrientation this[int index] => Items[index];

        public OrientationHistory()
        {
            // Начальные адреса, которые у тебя уже использовались.
            RegisterAddress(0);

            RestoreHistory(0);
        }

        /// <summary>
        /// Регистрирует адрес, если он ещё неизвестен.
        /// Возвращает историю соответствующего устройства.
        /// </summary>
        private List<ModelOrientation> GetOrCreateHistory(ulong address)
        {
            if (AddressOrientationTable.TryGetValue(
                    address, out var list))
            {
                return list;
            }

            list = new List<ModelOrientation>();

            AddressOrientationTable.Add(address, list);

            // Обновляем привязанный к ComboBox список.
            AddressListUI.Add(address);

            return list;
        }

        private void RegisterAddress(ulong address)
        {
            GetOrCreateHistory(address);
        }

        /// <summary>
        /// Добавляет новую ориентацию устройства.
        /// </summary>
        public void AddOrientationToTable(ulong address, ModelOrientation orientation)
        {
            var list = GetOrCreateHistory(address);

            list.Add(orientation);

            if (list.Count > MaxHistorySize)
            {
                list.RemoveAt(0);
            }

            // Обновляем текущую историю, если это выбранное устройство.
            if (address == CurrentAddress)
            {
                Items = list;
            }
        }

        /// <summary>
        /// Переключает текущую историю на другое устройство.
        /// </summary>
        public void RestoreHistory(ulong newAddress)
        {
            var list = GetOrCreateHistory(newAddress);

            CurrentAddress = newAddress;
            Items = list;
        }

        public DateTime GetTime(int index)
        {
            if (index < 0 || index >= Items.Count)
                return DateTime.MinValue;

            return Items[index].Time;
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

                rotations.Add(new ModelOrientation(roll, pitch, yaw));

            }
            return rotations;

        }
    }
}
