using SatteliteManagment.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Services
{
    internal class ServiceFactory
    {
        private static TlmPacketService tlmPacketService { get; set; }
        private static FileTransferPacketService fileTransferPacketService { get; set; }
        private static PacketInfoService packetInfoService { get; set; }

        private TlmPacketRepository tlmPacketRepository { get; set; }
        private FileTransferPacketRepository fileTransferPacketRepository { get; set; }
        private PacketInfoRepository packetInfoRepository { get; set; }

        public ServiceFactory(AppDbContext db)
        {
            tlmPacketRepository = new TlmPacketRepository(db);
            tlmPacketService = new TlmPacketService(tlmPacketRepository);
            
            fileTransferPacketRepository = new FileTransferPacketRepository(db);
            fileTransferPacketService = new FileTransferPacketService(fileTransferPacketRepository);

            packetInfoRepository = new PacketInfoRepository(db);
            packetInfoService = new PacketInfoService(packetInfoRepository);
        }

        public static TlmPacketService GetTlmPacketService()
        {
            return tlmPacketService;
        }
        public static FileTransferPacketService GetFileTransferPacketService()
        {
            return fileTransferPacketService;
        }

        public static PacketInfoService GetPacketInfoService()
        {
            return packetInfoService;
        }


    }
}
