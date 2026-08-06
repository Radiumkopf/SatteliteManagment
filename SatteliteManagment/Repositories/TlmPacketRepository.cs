using Microsoft.EntityFrameworkCore;
using SatteliteManagment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Repositories
{
    internal class TlmPacketRepository
    {
        private readonly AppDbContext _db;

        public TlmPacketRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(TlmPacketEntity entity)
        {
            _db.TlmPackets.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(TlmPacketEntity entity)
        {
            _db.TlmPackets.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<TlmPacketEntity> GetByIdAsync(int id)
        {
            return await _db.TlmPackets.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TlmPacketEntity>> GetAllAsync()
        {
            return await _db.TlmPackets
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<List<TlmPacketEntity>> GetLastAsync(int count)
        {
            return await _db.TlmPackets
                .OrderByDescending(x => x.Id)
                .Take(count)
                .ToListAsync();
        }
    }
}
