using SatteliteManagment.Repositories;
using SatteliteManagment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment
{
    internal class DbServices
    {
        public PacketInfoService PacketInfoService { get; }
        public TlmPacketService TlmPacketService { get; }
        public FileTransferPacketService FileTransferPacketService { get; }
        public PacketStoreService PacketStoreService { get; }

        public StoredFileService StoredFileService { get; }

        public DbServices(AppDbContext db)
        {
            var packetInfoRepository = new PacketInfoRepository(db);
            var tlmPacketRepository = new TlmPacketRepository(db);
            var fileTransferPacketRepository = new FileTransferPacketRepository(db);
            var storedFileRepository = new StoredFileRepository(db);

            PacketInfoService = new PacketInfoService(packetInfoRepository);
            TlmPacketService = new TlmPacketService(tlmPacketRepository);
            FileTransferPacketService = new FileTransferPacketService(fileTransferPacketRepository);
            //PacketStoreService = new PacketStoreService(packetInfoRepository);
            StoredFileService = new StoredFileService(storedFileRepository);
        }
    }
}
