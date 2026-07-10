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

        public TimeSpan delay { get; set; }

        public int repeatCount { get; set; }
        public CommandSender(DuplexTcpClient client)
        {
            this.client = client;
            currentCommand = "default";
            repeatCount = -1;
            delay = TimeSpan.Zero;
        }


        
        public async void SendCommandAsyncEndless(byte[] byteCommand, CancellationToken cancellationToken = default) 
        {

            while (!cancellationToken.IsCancellationRequested)
            {
                await client.SendTextAsync(byteCommand, cancellationToken);
                // Ожидаем перед следующей итерацией
                await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
            }
        }



        public async Task SendCommandAsync(byte[] command, CancellationToken cancellationToken = default)
        {
            if(repeatCount == -1)
            {
                repeatCount = 1;
            }
            for (int i = 0; i < repeatCount; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                await client.SendTextAsync(command, cancellationToken);

                if (i < repeatCount - 1)
                    await Task.Delay(delay, cancellationToken);
            }
        }



    }
}
