using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment
{
    internal static class SatellitePacketParser
    {
        public static PacketType GetPacketType(byte[] bytes)
        {
            if(bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }
            try
            {
                return (PacketType)bytes[0];
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("Ошибка разбора пакета.", ex);
            }
        }

        public static PacketType GetPacketType(byte symbol)
        {
            if (symbol == null)
            {
                throw new ArgumentNullException(nameof(symbol));
            }
            try
            {
                return (PacketType)symbol;
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("Ошибка разбора пакета.", ex);
            }
        }

        public static uint ParseCRC(byte[] bytes, int offset)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            if (bytes.Length < 5)
                throw new ArgumentException("CRC packet must contain at least 5 bytes.", nameof(bytes));

            return (uint)(
                bytes[1+offset] |
                ((uint)bytes[2+ offset] << 8) |
                ((uint)bytes[3 + offset] << 16) |
                ((uint)bytes[4 + offset] << 24)
            );
        }

        public static FileTransferPacket Parse(byte[] bytes)
        {
            return Parse(bytes, 0);
        }

        public static FileTransferPacket Parse(byte[] bytes, int index)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            try
            {
                //index = 0;

                if (bytes.Length - index < 5 || index < 0)
                    throw new InvalidDataException("Пакет слишком короткий.");

                FileTransferPacket packet = new FileTransferPacket();

                packet.Type = (PacketType)bytes[index++];
                packet.id = bytes[index++];
                packet.number = (ushort) BitConverter.ToInt16(bytes, index);
                index += 2;

                byte size = bytes[index++];

                //if (bytes.Length != index + size)
                //    throw new InvalidDataException("Размер пакета не соответствует заголовку.");

                packet.size = size;

                if (packet.Type != PacketType.FileSendingAck)       
                {

                    packet.data = new byte[size];

                    Array.Copy(bytes, index, packet.data, 0, size);
                }
                else packet.data = null;

                return packet;
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("Ошибка разбора пакета.", ex);
            }
        }
    }
}
