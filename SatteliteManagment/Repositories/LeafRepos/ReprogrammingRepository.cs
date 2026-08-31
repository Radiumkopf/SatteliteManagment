using SatteliteManagment.Entities.LeafEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SatteliteManagment.Repositories.LeafRepos
{
    internal class ReprogrammingRepository
    {
        private readonly AppDbContext _db;

        public ReprogrammingRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(ReprogrammingEntity entity)
        {
            _db.Reprogrammings.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<ReprogrammingEntity> GetByIdAsync(int id)
        {
            return await _db.Reprogrammings
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ReprogrammingEntity>> GetAllAsync()
        {
            return await _db.Reprogrammings
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<List<ReprogrammingEntity>> GetLastAsync(int count)
        {
            return await _db.Reprogrammings
                .OrderByDescending(x => x.Id)
                .Take(count)
                .ToListAsync();
        }

        public async Task UpdateAsync(ReprogrammingEntity entity)
        {
            _db.Reprogrammings.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            ReprogrammingEntity entity =
                await _db.Reprogrammings.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return;

            _db.Reprogrammings.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _db.Reprogrammings
                .AnyAsync(x => x.Id == id);
        }
    }
}
