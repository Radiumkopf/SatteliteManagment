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
        String currentCommand { get; set;  }

        public CommandSender(DuplexTcpClient client)
        {
            this.client = client;
            currentCommand = "default";
        }

        public async void SendComandAsync(string command, CancellationToken cancellationToken = default) 
        {
            byte[] byteCommand = Encoding.ASCII.GetBytes(command);
            while (!cancellationToken.IsCancellationRequested)
            {
                client.SendTextAsync(byteCommand, cancellationToken);
                // Ожидаем перед следующей итерацией
                await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
            }
        }




    }
}
