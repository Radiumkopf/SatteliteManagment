using SatteliteManagment.Entities.LeafEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SatteliteManagment.Repositories.LeafRepos
{
    internal class MotorSpeedRepository
    {
        private readonly AppDbContext _db;

        public MotorSpeedRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(MotorSpeedEntity entity)
        {
            _db.MotorSpeeds.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<MotorSpeedEntity> GetByIdAsync(int id)
        {
            return await _db.MotorSpeeds
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<MotorSpeedEntity>> GetAllAsync()
        {
            return await _db.MotorSpeeds
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<List<MotorSpeedEntity>> GetLastAsync(int count)
        {
            return await _db.MotorSpeeds
                .OrderByDescending(x => x.Id)
                .Take(count)
                .ToListAsync();
        }

        public async Task UpdateAsync(MotorSpeedEntity entity)
        {
            _db.MotorSpeeds.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            MotorSpeedEntity entity =
                await _db.MotorSpeeds.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return;

            _db.MotorSpeeds.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _db.MotorSpeeds
                .AnyAsync(x => x.Id == id);
        }
    }
}
