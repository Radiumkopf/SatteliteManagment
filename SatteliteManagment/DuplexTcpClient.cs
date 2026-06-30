using SBandSerialReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SatteliteManagment
{
    internal class DuplexTcpClient
    {
        private TcpClient _client;
        private NetworkStream _stream;
        private CancellationTokenSource _cts;

        public event Action<string> TextReceived;

        public async Task ConnectAsync(string ip, int port)
        {
            _client = new TcpClient();
            await _client.ConnectAsync(ip, port);
            _stream = _client.GetStream();
            _cts = new CancellationTokenSource();

            _ = ReceiveLoop(_cts.Token);
        }

        public async Task SendTextAsync(byte[] bytes, CancellationToken token = default)
        {
            await PacketProtocol.WritePacketAsync(_stream, bytes, token);
        }

        private async Task ReceiveLoop(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    byte[] data = await PacketProtocol.ReadPacketAsync(_stream, token);
                    string text = Encoding.ASCII.GetString(data);
                    TextReceived?.Invoke(text);
                }
            }
            catch
            {
            }
        }

        public void Close()
        {
            try { _cts?.Cancel(); } catch { }
            try { _stream?.Close(); } catch { }
            try { _client?.Close(); } catch { }
        }
    }
}
