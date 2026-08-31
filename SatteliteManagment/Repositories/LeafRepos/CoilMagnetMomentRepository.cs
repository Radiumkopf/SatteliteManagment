using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SatteliteManagment.Entities.LeafEntities;

namespace SatteliteManagment.Repositories.LeafRepos
{


    internal class CoilMagnetMomentRepository
    {
        private readonly AppDbContext _db;

        public CoilMagnetMomentRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(CoilMagnetMomentEntity entity)
        {
            _db.CoilMagnetMoments.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<CoilMagnetMomentEntity> GetByIdAsync(int id)
        {
            return await _db.CoilMagnetMoments
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<CoilMagnetMomentEntity>> GetAllAsync()
        {
            return await _db.CoilMagnetMoments
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<List<CoilMagnetMomentEntity>> GetLastAsync(int count)
        {
            return await _db.CoilMagnetMoments
                .OrderByDescending(x => x.Id)
                .Take(count)
                .ToListAsync();
        }

        public async Task UpdateAsync(CoilMagnetMomentEntity entity)
        {
            _db.CoilMagnetMoments.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            CoilMagnetMomentEntity entity =
                await _db.CoilMagnetMoments
                    .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return;

            _db.CoilMagnetMoments.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _db.CoilMagnetMoments
                .AnyAsync(x => x.Id == id);
        }
    }
}
