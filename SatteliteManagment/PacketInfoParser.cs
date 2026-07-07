using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment
{
    internal class PacketInfoParser
    {
        public static PacketInfo Parse(byte[] bytes)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            const int HeaderSize = 1 + 8 + 8 + 1 + 1 + 1 + 4 + 1 + 1;

            if (bytes.Length < HeaderSize)
                throw new InvalidDataException("Пакет слишком короткий.");

            try
            {
                int index = 0;

                PacketInfo packet = new PacketInfo();

                //Парсинг typecode
                int shift = 0;
                int mask_length = 5;
                int mask = (1 << mask_length) - 1;
                packet.AES_CRC = (byte)((bytes[index] >> shift) & mask);

                packet.BROADCAST = ((bytes[index] >> 5) & 1) == 1;
                packet.ACK_TYP = ((bytes[index] >> 6) & 1) == 1;
                packet.ACK_REQ = ((bytes[index] >> 7) & 1) == 1;

                index++;

                packet.DestAddr = BitConverter.ToUInt64(bytes, index);
                index += 8;

                packet.SourceAddr = BitConverter.ToUInt64(bytes, index);
                index += 8;

                packet.retrCount = bytes[index++];
                packet.payload_lth = bytes[index++];
                // packet.message = bytes[index++];
                index++;

                packet.ID = BitConverter.ToUInt32(bytes, index);
                index += 4;

                packet.rssi = unchecked((sbyte)bytes[index++]);
                packet.snr = unchecked((sbyte)bytes[index++]);

                //if (bytes.Length != HeaderSize + packet.payload_lth)
                //    throw new InvalidDataException("Неверная длина полезной нагрузки.");

                //packet.Payload = new byte[packet.payload_lth];

                //Array.Copy(bytes, index, packet.Payload, 0, packet.payload_lth);

                return packet;
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("Ошибка разбора пакета.", ex);
            }
        }
    }
}
