using Microsoft.EntityFrameworkCore;
using SatteliteManagment.Entities;
using SatteliteManagment.Entities.LeafEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Repositories.LeafRepos
{
    internal class FileRequestRepository
    {

        private readonly AppDbContext _db;

        public FileRequestRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(FileRequestEntity entity)
        {
            _db.FileRequests.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<FileRequestEntity> GetByIdAsync(int id)
        {
            return await _db.FileRequests
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<FileRequestEntity>> GetAllAsync()
        {
            return await _db.FileRequests
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<List<FileRequestEntity>> GetLastAsync(int count)
        {
            return await _db.FileRequests
                .OrderByDescending(x => x.Id)
                .Take(count)
                .ToListAsync();
        }
        public async Task<FileRequestEntity> GetByFileIdAndNumberAsync(byte fileId, ushort number)
        {
            return await _db.FileRequests
                .FirstOrDefaultAsync(x =>
                    x.FileId == fileId &&
                    x.Number == number);
        }
        public async Task UpdateAsync(FileRequestEntity entity)
        {
            _db.FileRequests.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            FileRequestEntity entity =
                await _db.FileRequests.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return;

            _db.FileRequests.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _db.FileRequests
                .AnyAsync(x => x.Id == id);
        }
    }
}
