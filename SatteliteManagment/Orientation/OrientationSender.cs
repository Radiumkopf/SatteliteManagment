using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Orientation
{
    internal class OrientationSender
    {
        public DuplexTcpClient client { get; set; }

        public OrientationSender(DuplexTcpClient client)
        {
            this.client = client;
        }

        //FIXME Получить кватернион из Эйлера
        public Task SendNewRPY(float roll, float pitch, float yaw)
        {
            if (client != null)
            {
                //FIXME Update when packet structure is defined
                // Convert the roll, pitch, and yaw values to bytes
                byte[] rollBytes = BitConverter.GetBytes((short)(roll * 100)); // Convert to hundredths of a degree
                byte[] pitchBytes = BitConverter.GetBytes((short)(pitch * 100)); // Convert to hundredths of a degree
                byte[] yawBytes = BitConverter.GetBytes((short)(yaw * 100)); // Convert to hundredths of a degree

                byte[] dataToSend = new byte[6];
                Array.Copy(rollBytes, 0, dataToSend, 0, 2);
                Array.Copy(pitchBytes, 0, dataToSend, 2, 2);
                Array.Copy(yawBytes, 0, dataToSend, 4, 2);
                // Send the data asynchronously
                return client.SendTextAsync(dataToSend);
            }
            else
            {
                throw new InvalidOperationException("Client is not connected.");
            }
        }

    }
}
