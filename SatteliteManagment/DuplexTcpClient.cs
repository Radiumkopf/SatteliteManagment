using SatteliteManagment.Telemetry;
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

        public event Action<TlmPacket> TelemetryReceived;

        private const int OFFSET = 25;


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

                    //if (data.Length == 10)
                    //{
                    //    ServerAddrChanged?.Invoke(SatellitePacketParser.Parse(data));
                    //    continue;
                    //}

                    byte[] packetInfoHeaderBytes = new byte[28];

                    Array.Copy(data, packetInfoHeaderBytes, OFFSET);
                    PacketType packetType = SatellitePacketParser.GetPacketType(data[OFFSET]);

                    if (packetType != PacketType.AddressChanging )
                    {
                        PacketInfo packetInfo;
                        try
                        {
                            packetInfo = PacketInfoParser.Parse(packetInfoHeaderBytes);

                            PacketReceived?.Invoke(packetInfo);

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            continue;
                        }
                    }


                    FileTransferPacket packet;
                    switch (packetType)
                    {

                        case PacketType.FileSendingAck:
                            packet = SatellitePacketParser.Parse(data, OFFSET);
                            AckReceived?.Invoke(packet);
                            break;

                        case PacketType.FileRequestingAck:
                            packet = SatellitePacketParser.Parse(data, OFFSET);
                            FileReceived?.Invoke(packet);
                            break;

                        case PacketType.FileRequestingLast:
                            packet = SatellitePacketParser.Parse(data, OFFSET);
                            LastFileReceived?.Invoke(packet);
                            break;

                        case PacketType.AddressChanging:
                            packet = SatellitePacketParser.Parse(data, OFFSET);
                            ServerAddrChanged?.Invoke(packet);
                            break;

                        case PacketType.Telemetry:
                            TlmPacket telemetryPacket = TlmPacket.Parse(data, OFFSET+1);
                            TelemetryReceived?.Invoke(telemetryPacket);
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
