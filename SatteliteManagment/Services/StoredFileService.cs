using SatteliteManagment.Entities;
using SatteliteManagment.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SatteliteManagment.Services
{
    internal class StoredFileService
    {
        private readonly StoredFileRepository _repository;

        public StoredFileService(StoredFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> SaveFileAsync(string filePath, byte[] address, CancellationToken cancellationToken = default)
        {
            var fileData =  File.ReadAllBytes(filePath);

            var entity = new StoredFileEntity
            {
                Address = address,
                FileData = fileData,
                CreatedAtUtc = DateTime.UtcNow,
                FileName = Path.GetFileName(filePath),
                ContentType = GetContentType(filePath)
            };

            await _repository.AddAsync(entity, cancellationToken);
            return entity.Id;
        }

        public async Task<int> SaveFileAsync(byte[] fileData, byte[] address, string fileName = null, string contentType = null, CancellationToken cancellationToken = default)
        {
            var entity = new StoredFileEntity
            {
                Address = address,
                FileData = fileData,
                CreatedAtUtc = DateTime.UtcNow,
                FileName = fileName,
                ContentType = contentType
            };

            await _repository.AddAsync(entity, cancellationToken);
            return entity.Id;
        }

        private static string GetContentType(string filePath)
        {
            var ext = Path.GetExtension(filePath).ToLowerInvariant();
            switch (ext)
            {
                case ".png":
                    return "image/png";
                case ".jpg":
                    return "image/jpg";

                case ".jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";

                default:
                    return null;
            }
        }
    }
}
