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

        public event Action<PacketInfo> PacketReceived;

        public event Action<FileTransferPacket> AckReceived;

        public event Action<FileTransferPacket> FileReceived;

        public event Action<FileTransferPacket> LastFileReceived;

        public event Action<FileTransferPacket> ServerAddrChanged;


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

                    if (data.Length == 10) {
                        ServerAddrChanged?.Invoke(SatellitePacketParser.Parse(data));
                        continue;
                    }

                    byte[] packetInfoHeaderBytes = new byte[24];
                    byte[] fileTransferPackekBytes = new byte[data.Length - 24];
                    PacketInfo packetInfo;
                    FileTransferPacket packet;
                    try
                    {
                        packetInfo = PacketInfoParser.Parse(packetInfoHeaderBytes);
                        packet = SatellitePacketParser.Parse(fileTransferPackekBytes);

                        PacketReceived?.Invoke(packetInfo);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        continue;
                    }

                    switch (packet.Type)
                    {

                        case PacketType.FileSendingAck:
                            AckReceived?.Invoke(packet);
                            break;

                        case PacketType.FileRequestingAck:
                            FileReceived?.Invoke(packet);
                            break;

                        case PacketType.FileRequestingLast:
                            LastFileReceived?.Invoke(packet);
                            break;

                        case PacketType.AddressChanging:
                            ServerAddrChanged?.Invoke(packet);
                            break;
                    }
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
