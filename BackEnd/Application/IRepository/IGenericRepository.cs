using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        Task<Result<TEntity>> Add(TEntity entity);
        Task<Result<TEntity>> GetById(int id);
        Task<Result> Delete(int id);
        Task<Result<TEntity>> Update(TEntity entity);
        Task<Result<List<TEntity>>> GetAll();

    }
}
