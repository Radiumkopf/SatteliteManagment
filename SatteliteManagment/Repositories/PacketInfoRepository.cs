using Microsoft.EntityFrameworkCore;
using SatteliteManagment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Repositories
{
    internal class PacketInfoRepository
    {
        private readonly AppDbContext _db;

        public PacketInfoRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(PacketInfoEntity entity)
        {
            _db.PacketInfos.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(PacketInfoEntity entity)
        {
            _db.PacketInfos.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<PacketInfoEntity> GetByIdAsync(int id)
        {
            return await _db.PacketInfos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<PacketInfoEntity>> GetAllAsync()
        {
            return await _db.PacketInfos
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<List<PacketInfoEntity>> GetLastAsync(int count)
        {
            return await _db.PacketInfos
                .OrderByDescending(x => x.Id)
                .Take(count)
                .ToListAsync();
        }

        public async Task AddGraphAsync(PacketInfoEntity entity)
        {
            _db.PacketInfos.Add(entity);
            await _db.SaveChangesAsync();
        }
    }
}
