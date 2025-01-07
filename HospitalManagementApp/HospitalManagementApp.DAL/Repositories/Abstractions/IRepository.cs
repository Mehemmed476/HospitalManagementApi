using HospitalManagementApp.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementApp.DAL.Repositories.Abstractions;

public interface IRepository<TEntity> where TEntity : BaseEntity, new()
{
    //Read
    Task<ICollection<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(int id);
    Task<bool> IsExistAsync(int id);

    //Write
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    void HardDelete(TEntity entity);
    void SoftDelete(TEntity entity);
    void Restore(TEntity entity);

    //Save
    Task SaveAsync();
}
