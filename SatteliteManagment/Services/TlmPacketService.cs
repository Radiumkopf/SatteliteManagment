using SatteliteManagment.Entities;
using SatteliteManagment.Repositories;
using SatteliteManagment.Telemetry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Services
{
    internal class TlmPacketService
    {
        private readonly TlmPacketRepository _repository;

        public TlmPacketService(TlmPacketRepository repository)
        {
            _repository = repository;
        }

        public Task SaveAsync(TlmPacket packet)
        {
            TlmPacketEntity entity = MapToEntity(packet);
            return _repository.AddAsync(entity);
        }

        public async Task<TlmPacket> GetByIdAsync(int id)
        {
            TlmPacketEntity entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToModel(entity);
        }

        public async Task<List<TlmPacket>> GetAllAsync()
        {
            List<TlmPacketEntity> entities = await _repository.GetAllAsync();
            return entities.Select(MapToModel).ToList();
        }

        public async Task<List<TlmPacket>> GetLastAsync(int count)
        {
            List<TlmPacketEntity> entities = await _repository.GetLastAsync(count);
            return entities.Select(MapToModel).ToList();
        }

        public static TlmPacketEntity MapToEntity(TlmPacket packet)
        {
            return new TlmPacketEntity
            {
                Temperature1 = packet.Temperature1,
                Temperature2 = packet.Temperature2,
                BatteryV = packet.BatteryV,
                PvPower1 = packet.PvPower[0],
                PvPower2 = packet.PvPower[1],
                PvPower3 = packet.PvPower[2],
                AngularRate = packet.AngularRate,
                MagFieldAbs = packet.MagFieldAbs,
                BatChargePower = packet.BatChargePower,
                BatDischargePower = packet.BatDischargePower,
                ResetCounter = packet.ResetCounter,
                StatusFlags = packet.StatusFlags
            };
        }

        public static TlmPacket MapToModel(TlmPacketEntity entity)
        {
            return new TlmPacket
            {
                Temperature1 = entity.Temperature1,
                Temperature2 = entity.Temperature2,
                BatteryV = entity.BatteryV,
                PvPower = new float[] { entity.PvPower1, entity.PvPower2, entity.PvPower3 },
                AngularRate = entity.AngularRate,
                MagFieldAbs = entity.MagFieldAbs,
                BatChargePower = entity.BatChargePower,
                BatDischargePower = entity.BatDischargePower,
                ResetCounter = entity.ResetCounter,
                StatusFlags = entity.StatusFlags
            };
        }
    }
}
