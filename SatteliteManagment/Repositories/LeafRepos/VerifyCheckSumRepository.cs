using SatteliteManagment.Entities.LeafEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace SatteliteManagment.Repositories.LeafRepos
{
    internal class VerifyCheckSumRepository
    {
        private readonly AppDbContext _db;

        public VerifyCheckSumRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(VerifyCheckSumEntity entity)
        {
            _db.VerifyCheckSums.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<VerifyCheckSumEntity> GetByIdAsync(int id)
        {
            return await _db.VerifyCheckSums
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<VerifyCheckSumEntity>> GetAllAsync()
        {
            return await _db.VerifyCheckSums
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<List<VerifyCheckSumEntity>> GetLastAsync(int count)
        {
            return await _db.VerifyCheckSums
                .OrderByDescending(x => x.Id)
                .Take(count)
                .ToListAsync();
        }

        public async Task UpdateAsync(VerifyCheckSumEntity entity)
        {
            _db.VerifyCheckSums.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            VerifyCheckSumEntity entity =
                await _db.VerifyCheckSums.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return;

            _db.VerifyCheckSums.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _db.VerifyCheckSums
                .AnyAsync(x => x.Id == id);
        }
    }
}
