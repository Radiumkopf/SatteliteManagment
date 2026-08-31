using SatteliteManagment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment
{
    public enum DbEntityType
    {
        PacketInfo,
        TlmPacket,
        FileTransferPacket,
        FileRequest,
        ModuleStatus,
        MotorSpeed,
        Reprogramming,
        TimeSet,
        VerifyCheckSum,
        CoilMagnetMoment
    }
    internal class EntityListLoader
    {
        public static void LoadListEntityToDict(Dictionary<DbEntityType, Func<int, Task<IReadOnlyList<IDbEntity>>>> _entityLoaders, DbServices dbServices)
        {
            _entityLoaders = new Dictionary<DbEntityType, Func<int, Task<IReadOnlyList<IDbEntity>>>>
            {
                {
                    DbEntityType.PacketInfo,
                    async count => (await dbServices.PacketInfoService.GetLastAsync(count))
                        .Cast<IDbEntity>()
                        .ToList()
                },

                {
                    DbEntityType.TlmPacket,
                    async count => (await dbServices.TlmPacketService.GetLastAsync(count))
                        .Cast<IDbEntity>()
                        .ToList()
                },

                {
                    DbEntityType.FileTransferPacket,
                    async count => (await dbServices.FileTransferPacketService.GetLastAsync(count))
                        .Cast<IDbEntity>()
                        .ToList()
                },

                {
                    DbEntityType.FileRequest,
                    async count => (await dbServices.FileRequestService.GetLastAsync(count))
                        .Cast<IDbEntity>()
                        .ToList()
                },

                {
                    DbEntityType.ModuleStatus,
                    async count => (await dbServices.ModuleStatusService.GetLastAsync(count))
                        .Cast<IDbEntity>()
                        .ToList()
                },

                {
                    DbEntityType.MotorSpeed,
                    async count => (await dbServices.MotorSpeedService.GetLastAsync(count))
                        .Cast<IDbEntity>()
                        .ToList()
                },

                {
                    DbEntityType.Reprogramming,
                    async count => (await dbServices.ReprogrammingService.GetLastAsync(count))
                        .Cast<IDbEntity>()
                        .ToList()
                },

                {
                    DbEntityType.TimeSet,
                    async count => (await dbServices.TimeSetService.GetLastAsync(count))
                        .Cast<IDbEntity>()
                        .ToList()
                },

                {
                    DbEntityType.VerifyCheckSum,
                    async count => (await dbServices.VerifyCheckSumService.GetLastAsync(count))
                        .Cast<IDbEntity>()
                        .ToList()
                },

                {
                    DbEntityType.CoilMagnetMoment,
                    async count => (await dbServices.CoilMagnetMomentService.GetLastAsync(count))
                        .Cast<IDbEntity>()
                        .ToList()
                }
            };
        }
    }
}
