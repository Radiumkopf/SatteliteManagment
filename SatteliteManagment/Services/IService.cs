using SatteliteManagment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatteliteManagment.Services
{
    internal interface IService
    {
        Task SaveAsync(IDbEntity packet);
        Task<IDbEntity> GetByIdAsync(int id);
        Task<List<IDbEntity>> GetAllAsync();
        Task<List<IDbEntity>> GetLastAsync(int count);
        Task DeleteAsync(int id);
        Task UpdateAsync(IDbEntity entity);

    }
}
