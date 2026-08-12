using Microsoft.EntityFrameworkCore;
using SatteliteManagment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SatteliteManagment.Repositories
{
    internal class StoredFileRepository
    {
        private readonly AppDbContext _db;

        public StoredFileRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(StoredFileEntity entity, CancellationToken cancellationToken = default)
        {
            _db.StoredFiles.Add(entity);
            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task<StoredFileEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _db.StoredFiles.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<List<StoredFileEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _db.StoredFiles.ToListAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _db.StoredFiles.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (entity == null)
                return;

            _db.StoredFiles.Remove(entity);
            await _db.SaveChangesAsync(cancellationToken);
        }
    }
}
