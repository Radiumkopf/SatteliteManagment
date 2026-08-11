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
    }
}
