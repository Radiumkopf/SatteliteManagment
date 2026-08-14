using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment
{
    internal class Crc32
    {
        private const int BufferSize = 512;

        private const uint Polynomial = 0x04C11DB7;
        private const uint InitialValue = 0xFFFFFFFF;

        public static uint CalculateFile(string filePath)
        {
            uint crc = InitialValue;

            byte[] buffer = new byte[BufferSize];

            FileStream file = new FileStream(
                filePath,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read
            );

            int bytesRead;

            while ((bytesRead = file.Read(buffer, 0, BufferSize)) > 0)
            {
                for (int i = 0; i < bytesRead; i++)
                {
                    crc ^= (uint)buffer[i] << 24;

                    for (int bit = 0; bit < 8; bit++)
                    {
                        if ((crc & 0x80000000) != 0)
                            crc = (crc << 1) ^ Polynomial;
                        else
                            crc <<= 1;
                    }
                }
            }

            return crc;
        }

        /// <summary>
        /// Second ver of CRC
        /// </summary>

        public static uint CalculateFileVer2(string filePath)
        {
            const int BufferSize = 512;

            uint crc = 0xFFFFFFFF;

            byte[] buffer = new byte[BufferSize];

            FileStream file = new FileStream(
                filePath,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read
            );

            int bytesRead;

            while ((bytesRead = file.Read(buffer, 0, BufferSize)) > 0)
            {
                int i = 0;

                // Точно как CRC_Handle_8() в STM32 HAL:
                // 4 байта объединяются в uint32_t
                while (i + 4 <= bytesRead)
                {
                    uint word =
                        ((uint)buffer[i] << 24) |
                        ((uint)buffer[i + 1] << 16) |
                        ((uint)buffer[i + 2] << 8) |
                        buffer[i + 3];

                    crc = ProcessWord(crc, word);

                    i += 4;
                }

                // Обработка последних 1-3 байт
                while (i < bytesRead)
                {
                    crc = ProcessByte(crc, buffer[i]);
                    i++;
                }
            }

            return crc;
        }

        private static uint ProcessWord(uint crc, uint word)
        {
            for (int bit = 0; bit < 32; bit++)
            {
                bool topBit = (crc & 0x80000000) != 0;

                crc <<= 1;

                if (topBit ^ ((word & 0x80000000) != 0))
                    crc ^= 0x04C11DB7;

                word <<= 1;
            }

            return crc;
        }

        private static uint ProcessByte(uint crc, byte data)
        {
            for (int bit = 0; bit < 8; bit++)
            {
                bool topBit = (crc & 0x80000000) != 0;
                bool dataBit = (data & 0x80) != 0;

                crc <<= 1;

                if (topBit ^ dataBit)
                    crc ^= 0x04C11DB7;

                data <<= 1;
            }

            return crc;
        }
    }
}
