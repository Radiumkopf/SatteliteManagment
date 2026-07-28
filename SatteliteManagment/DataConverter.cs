using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment
{
    internal class DataConverter
    {

        public static string ByteArrayToStringASCII(byte[] data)
        {
            return System.Text.Encoding.ASCII.GetString(data);
        }
        public static string ByteToStringASCII(byte data)
        {
            return System.Text.Encoding.ASCII.GetString(new byte[] { data });
        }


        public static string ByteArrayToStringHEX(byte[] data)
        {
            return BitConverter.ToString(data).Replace("-", "");
        }
        public static string ByteToStringHEX(byte data)
        {
            return BitConverter.ToString(new byte[] { data }).Replace("-", "");
        }


        public static byte[] ASCIIStringToByteArray(string ascii)
        {
            return Encoding.ASCII.GetBytes(ascii);
        }
        public static byte ASCIIStringToByte(string ascii)
        {
            byte[] data = Encoding.ASCII.GetBytes(ascii);
            return data[0];
        }


        public static byte[] HEXStringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
        public static byte[] HexStringToBytes(string hex)
        {
            if (string.IsNullOrWhiteSpace(hex))
                return Array.Empty<byte>();

            // Убираем пробелы, тире и двоеточия
            hex = hex.Replace(" ", "")
                     .Replace("-", "")
                     .Replace(":", "");

            if (hex.Length % 2 != 0)
                throw new FormatException("Количество HEX-символов должно быть четным.");

            byte[] bytes = new byte[hex.Length / 2];

            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }

            return bytes;
        }

        public static bool IsHexString(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            text = text.Replace(" ", "")
                       .Replace("-", "")
                       .Replace(":", "");

            if (text.Length % 2 != 0)
                return false;

            foreach (char c in text)
            {
                bool digit = c >= '0' && c <= '9';
                bool hexLower = c >= 'a' && c <= 'f';
                bool hexUpper = c >= 'A' && c <= 'F';

                if (!digit && !hexLower && !hexUpper)
                    return false;
            }

            return true;
        }
        public static byte HEXStringToByte(string hex)
        {
            byte[] data = Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
            return data[0];
        }


        public static string HEXStringToASCIIString(string hex)
        {
            byte[] data = HEXStringToByteArray(hex);
            return ByteArrayToStringASCII(data);
        }

        public static string ASCIIStringToHexString(string ascii)
        {
            byte[] data = ASCIIStringToByteArray(ascii);
            return ByteArrayToStringHEX(data);
        }
    }

}
