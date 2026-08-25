using SatteliteManagment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SatteliteManagment.Repositories
{
    internal class PacketDescriptionRepository
    {
        private readonly AppDbContext _db;

        public PacketDescriptionRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(PacketDescriptionEntity entity)
        {
            _db.PacketDescriptions.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<PacketDescriptionEntity> GetByIdAsync(int id)
        {
            return await _db.PacketDescriptions
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PacketDescriptionEntity>> GetAllAsync()
        {
            return await _db.PacketDescriptions
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<List<PacketDescriptionEntity>> GetLastAsync(int count)
        {
            return await _db.PacketDescriptions
                .OrderByDescending(x => x.Id)
                .Take(count)
                .ToListAsync();
        }

        public async Task UpdateAsync(PacketDescriptionEntity entity)
        {
            _db.PacketDescriptions.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            PacketDescriptionEntity entity =
                await _db.PacketDescriptions.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return;

            _db.PacketDescriptions.Remove(entity);
            await _db.SaveChangesAsync();
        }
    }
}
