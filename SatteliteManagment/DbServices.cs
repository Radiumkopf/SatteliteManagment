using SatteliteManagment.Repositories;
using SatteliteManagment.Repositories.LeafRepos;
using SatteliteManagment.Services;
using SatteliteManagment.Services.LeafServices;
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

        public FileRequestService FileRequestService { get; }
        public ModuleStatusService ModuleStatusService { get; }
        public MotorSpeedService MotorSpeedService { get; }
        public ReprogrammingService ReprogrammingService { get; }
        public TimeSetService TimeSetService { get; }
        public VerifyCheckSumService VerifyCheckSumService { get; }
        public CoilMagnetMomentService CoilMagnetMomentService { get; }

        public RadioPacketService RadioPacketService { get; }
        public PacketDescriptionService PacketDescriptionService { get; }

        public StoredFileService StoredFileService { get; }

       // public PacketStoreService PacketStoreService { get; }

        public DbServices(AppDbContext db)
        {
            // Repositories
            var packetInfoRepository = new PacketInfoRepository(db);
            var tlmPacketRepository = new TlmPacketRepository(db);
            var fileTransferPacketRepository = new FileTransferPacketRepository(db);

            var fileRequestRepository = new FileRequestRepository(db);
            var moduleStatusRepository = new ModuleStatusRepository(db);
            var motorSpeedRepository = new MotorSpeedRepository(db);
            var reprogrammingRepository = new ReprogrammingRepository(db);
            var timeSetRepository = new TimeSetRepository(db);
            var verifyCheckSumRepository = new VerifyCheckSumRepository(db);
            var coilMagnetMomentRepository = new CoilMagnetMomentRepository(db);

            var radioPacketRepository = new RadioPacketRepository(db);
            var packetDescriptionRepository = new PacketDescriptionRepository(db);

            var storedFileRepository = new StoredFileRepository(db);

            

            // Services
            PacketInfoService = new PacketInfoService(packetInfoRepository);
            TlmPacketService = new TlmPacketService(tlmPacketRepository);
            FileTransferPacketService =
                new FileTransferPacketService(fileTransferPacketRepository);

            FileRequestService = new FileRequestService(fileRequestRepository);
            ModuleStatusService = new ModuleStatusService(moduleStatusRepository);
            MotorSpeedService = new MotorSpeedService(motorSpeedRepository);
            ReprogrammingService = new ReprogrammingService(reprogrammingRepository);
            TimeSetService = new TimeSetService(timeSetRepository);
            VerifyCheckSumService = new VerifyCheckSumService(verifyCheckSumRepository);
            CoilMagnetMomentService =
                new CoilMagnetMomentService(coilMagnetMomentRepository);

            RadioPacketService = new RadioPacketService(radioPacketRepository);
            PacketDescriptionService =
                new PacketDescriptionService(packetDescriptionRepository);

            StoredFileService = new StoredFileService(storedFileRepository);

           //PacketStoreService = new PacketStoreService(packetInfoRepository);
        }
    }
}
