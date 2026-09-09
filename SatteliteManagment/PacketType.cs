using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment
{
    public enum PacketType : byte
    {
        TimeSet = 0x0A,
        FileSending = 0x0B,
        FileRequesting = 0x0C,
        VerifyCheckSum = 0x0E,
        ReprogrammingStart = 0x0F,
        GetModuleStatus = 0x07,
        SetCoilMagnetMoment = 0x08,
        SetMotorSpeed = 0x09,


        TimeSetAck = 0x1A,
        FileSendingAck = 0x1B,
        FileSendingNack = 0x2B,
        VerifyCheckSumAck = 0x1E,

        ReprogrammingStartACK = 0x1F,
        ReprogrammingStartNACK = 0x2F,

        FileRequestingAck = 0x1C,
        FileRequestingLast = 0x2C,
        ModuleStatus = 0x17,
        SetCoilMagnetMomentAck = 0x18,
        SetCoilMagnetMomentNack = 0x28,
        SetMotorSpeedAck = 0x19,
        SetMotorSpeedNack = 0x29,
        Telemetry = 0x1D,
        OrientationPacket = 0x15,

        AddressChanging = 0xAC

    }
}
