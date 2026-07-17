using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment
{
    internal static class TxOperator
    {

        //данные для регистра, пока что инвариантны
        const byte DeviceAddress = 0x80;
        const byte RegisterStart = 7;
        const byte RegistersAmount = 5;

        public static byte[] RegisterWrite( //byte deviceAddress, byte RegisterStart, byte RegistersAmount, 
            byte[] RegisterData)
        {
            byte[] transmitData = new byte[5 + RegistersAmount];
            transmitData[0] = DeviceAddress;
            transmitData[1] = 0x00; //Write reg cmd
            transmitData[2] = RegisterStart;
            transmitData[3] = RegistersAmount;

            for (int i = 0; i < RegistersAmount; i++)
            {
                transmitData[4 + i] = RegisterData[i];
            }

            transmitData[4 + RegistersAmount] = CRC(transmitData, 4 + RegistersAmount);

            return transmitData;
        }


        public static byte CRC(byte[] data, int length)
        {
            byte crc = 0;

            for (int i = 0; i < length; i++)
            {
                crc = (byte)(crc + data[i]);
            }

            return crc;
        }
    }
}
