using Microsoft.EntityFrameworkCore;
using SatteliteManagment.Entities;
using SatteliteManagment.Entities.LeafEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Repositories
{
    internal class FileTransferPacketRepository
    {
        private readonly AppDbContext _db;

        public FileTransferPacketRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(FileTransferPacketEntity entity)
        {
            
            _db.FileTransferPackets.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(FileTransferPacketEntity entity)
        {
            _db.FileTransferPackets.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<FileTransferPacketEntity> GetByIdAsync(int id)
        {
            return await _db.FileTransferPackets.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<FileTransferPacketEntity>> GetAllAsync()
        {
            return await _db.FileTransferPackets
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<List<FileTransferPacketEntity>> GetByFileIdAsync(byte fileId)
        {
            return await _db.FileTransferPackets
                .Where(x => x.FileId == fileId)
                .OrderBy(x => x.Number)
                .ToListAsync();
        }


        public async Task<List<FileTransferPacketEntity>> GetLastAsync(int count)
        {
            return await _db.FileTransferPackets
                .OrderByDescending(x => x.Id)
                .Take(count)
                .ToListAsync();
        }
        public async Task DeleteAsync(int id)
        {
            FileTransferPacketEntity entity =
                await _db.FileTransferPackets.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return;

            _db.FileTransferPackets.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _db.FileTransferPackets
                .AnyAsync(x => x.Id == id);
        }


    }
}
