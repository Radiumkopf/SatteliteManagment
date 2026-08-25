using Microsoft.EntityFrameworkCore;
using SatteliteManagment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Repositories
{
    internal class RadioPacketRepository
    {
        private readonly AppDbContext _db;

        public RadioPacketRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(RadioPacketEntity entity)
        {
            _db.RadioPackets.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<RadioPacketEntity> GetByIdAsync(int id)
        {
            return await _db.RadioPackets
                .Include(x => x.PacketInfo)
                .Include(x => x.PacketDescription)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<RadioPacketEntity>> GetAllAsync()
        {
            return await _db.RadioPackets
                .Include(x => x.PacketInfo)
                .Include(x => x.PacketDescription)
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<List<RadioPacketEntity>> GetLastAsync(int count)
        {
            return await _db.RadioPackets
                .Include(x => x.PacketInfo)
                .Include(x => x.PacketDescription)
                .OrderByDescending(x => x.Id)
                .Take(count)
                .ToListAsync();
        }

        public async Task UpdateAsync(RadioPacketEntity entity)
        {
            _db.RadioPackets.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            RadioPacketEntity entity =
                await _db.RadioPackets.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return;

            _db.RadioPackets.Remove(entity);
            await _db.SaveChangesAsync();
        }
    }
}
