using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace SatteliteManagment
{
    internal class CommandSender
    {
        DuplexTcpClient client;
        string currentCommand { get; set;  }

        public int delay { get; set; }

        public int countSending { get; set; }
        public CommandSender(DuplexTcpClient client)
        {
            this.client = client;
            currentCommand = "default";
        }

        public async void SendComandAsync(byte[] byteCommand, CancellationToken cancellationToken = default) 
        {

            while (!cancellationToken.IsCancellationRequested)
            {
                client.SendTextAsync(byteCommand, cancellationToken);
                // Ожидаем перед следующей итерацией
                await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
            }
        }




    }
}
