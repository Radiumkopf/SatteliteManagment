using SatteliteManagment.Entities.LeafEntities;
using SatteliteManagment.Repositories.LeafRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Services.LeafServices
{
    internal class FileRequestService
    {
        private readonly FileRequestRepository _repository;

        public FileRequestService(FileRequestRepository repository)
        {
            _repository = repository;
        }

        public Task SaveAsync(FileRequestEntity entity)
            => _repository.AddAsync(entity);

        public Task<FileRequestEntity> GetByIdAsync(int id)
            => _repository.GetByIdAsync(id);

        public Task<List<FileRequestEntity>> GetAllAsync()
            => _repository.GetAllAsync();

        public Task<List<FileRequestEntity>> GetLastAsync(int count)
            => _repository.GetLastAsync(count);
        public async Task<FileRequestEntity> GetLastAsync() { var list = await _repository.GetLastAsync(1); return list?.FirstOrDefault(); }

        public Task UpdateAsync(FileRequestEntity entity)
            => _repository.UpdateAsync(entity);

        public Task DeleteAsync(int id)
            => _repository.DeleteAsync(id);

        public Task<bool> ExistsAsync(int id)
            => _repository.ExistsAsync(id);
    }
}
