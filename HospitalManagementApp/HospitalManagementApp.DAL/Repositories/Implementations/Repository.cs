using HospitalManagementApp.Core.Entities.Base;
using HospitalManagementApp.DAL.Contexts;
using HospitalManagementApp.DAL.Exceptions;
using HospitalManagementApp.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementApp.DAL.Repositories.Implementations;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public DbSet<TEntity> Table => _context.Set<TEntity>();

    //Read

    public async Task<ICollection<TEntity>> GetAllAsync()
    {
        ICollection<TEntity> entities = await Table.ToListAsync();
        return entities;
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        TEntity? entity = await Table.FindAsync(id);

        if (entity is null)
        {
            throw new EntityNotFoundException();
        }

        return entity;
    }

    public async Task<bool> IsExistAsync(int id)
    {
        bool result = await Table.AnyAsync(t => t.Id == id);
        return result;
    }


    //Write

    public async Task AddAsync(TEntity entity)
    {
        await Table.AddAsync(entity);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        var exitingEntity = await GetByIdAsync(entity.Id);
        _context.Entry(exitingEntity).CurrentValues.SetValues(entity);
    }

    public void HardDelete(TEntity entity)
    {
        Table.Remove(entity);
    }

    public void SoftDelete(TEntity entity)
    {
        entity.IsDeleted = true;
    }

    public void Restore(TEntity entity)
    {
        entity.IsDeleted = false;
    }


    //Save

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
