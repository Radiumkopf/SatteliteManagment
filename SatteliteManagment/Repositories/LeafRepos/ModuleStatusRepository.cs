using SatteliteManagment.Entities.LeafEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SatteliteManagment.Repositories.LeafRepos
{
    internal class ModuleStatusRepository
    {
        private readonly AppDbContext _db;

        public ModuleStatusRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(ModuleStatusEntity entity)
        {
            _db.ModuleStatuses.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<ModuleStatusEntity> GetByIdAsync(int id)
        {
            return await _db.ModuleStatuses
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ModuleStatusEntity>> GetAllAsync()
        {
            return await _db.ModuleStatuses
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<List<ModuleStatusEntity>> GetLastAsync(int count)
        {
            return await _db.ModuleStatuses
                .OrderByDescending(x => x.Id)
                .Take(count)
                .ToListAsync();
        }

        public async Task UpdateAsync(ModuleStatusEntity entity)
        {
            _db.ModuleStatuses.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            ModuleStatusEntity entity =
                await _db.ModuleStatuses.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return;

            _db.ModuleStatuses.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _db.ModuleStatuses
                .AnyAsync(x => x.Id == id);
        }
    }
}
