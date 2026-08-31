using SatteliteManagment.Entities.LeafEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SatteliteManagment.Repositories.LeafRepos
{

        internal class TimeSetRepository
        {
            private readonly AppDbContext _db;

            public TimeSetRepository(AppDbContext db)
            {
                _db = db;
            }

            public async Task AddAsync(TimeSetEntity entity)
            {
                _db.TimeSets.Add(entity);
                await _db.SaveChangesAsync();
            }

            public async Task<TimeSetEntity> GetByIdAsync(int id)
            {
                return await _db.TimeSets
                    .FirstOrDefaultAsync(x => x.Id == id);
            }

            public async Task<List<TimeSetEntity>> GetAllAsync()
            {
                return await _db.TimeSets
                    .OrderBy(x => x.Id)
                    .ToListAsync();
            }

            public async Task<List<TimeSetEntity>> GetLastAsync(int count)
            {
                return await _db.TimeSets
                    .OrderByDescending(x => x.Id)
                    .Take(count)
                    .ToListAsync();
            }

            public async Task UpdateAsync(TimeSetEntity entity)
            {
                _db.TimeSets.Update(entity);
                await _db.SaveChangesAsync();
            }

            public async Task DeleteAsync(int id)
            {
                TimeSetEntity entity =
                    await _db.TimeSets.FirstOrDefaultAsync(x => x.Id == id);

                if (entity == null)
                    return;

                _db.TimeSets.Remove(entity);
                await _db.SaveChangesAsync();
            }

            public async Task<bool> ExistsAsync(int id)
            {
                return await _db.TimeSets
                    .AnyAsync(x => x.Id == id);
            }
        }
    
}
