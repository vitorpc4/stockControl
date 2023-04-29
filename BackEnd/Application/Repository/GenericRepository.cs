using Application.Domain;
using Application.IRepository;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DbStockContext _dbContext;
        public GenericRepository(DbStockContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result<TEntity>> Add(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)  return Result.Ok(entity);
            return Result.Fail("Not possibile to save on database");
        }

        public async Task<Result> Delete(int id)
        {
            var obj = await GetById(id);
            if (obj.IsSuccess)
            {
                _dbContext.Set<TEntity>().Remove(obj.Value);
                var result = await _dbContext.SaveChangesAsync();
                if (result > 0) return Result.Ok();
                return Result.Fail("Failed to delete object");
                
            }
            return Result.Fail(obj.Reasons[0].Message);
        }

        public async Task<Result<List<TEntity>>> GetAll()
        {
            var result = await _dbContext.Set<TEntity>().ToListAsync();
            if (result.Count() > 0) return Result.Ok(result);
            return Result.Fail("No objects found in the database");
        }

        public async Task<Result<TEntity>> GetById(int id)
        {
            var result = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (result != null) return Result.Ok(result);
            return Result.Fail("No object found in the dabase");

        }

        public async Task<Result<TEntity>> Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0) return Result.Ok(entity);
            return Result.Fail("Failed to edit user in database");
        }
    }
}
