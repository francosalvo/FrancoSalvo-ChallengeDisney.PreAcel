using ChallengeDisney.PreAcel.Interfaces.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChallengeDisney.PreAcel.Repositories;


namespace ChallengeDisney.PreAcel.Repositories
{
    public abstract class BaseRepository<TEntity, TContext> : IRepository<TEntity> where TEntity : class where TContext : DbContext
    {
        private readonly TContext _dbContext;

        protected BaseRepository(TContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TEntity>> GetAllEntities()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public ValueTask<TEntity> Get(int id)
        {
            return _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task Add(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public TEntity Update(TEntity entity)
        {
            _dbContext.Attach(entity); //traquea una entidad - toman la entidad
            _dbContext.Entry(entity).State = EntityState.Modified; //traquea los cambios
            _dbContext.SaveChanges();
            return entity;
        }

        public TEntity Delete(int id)
        {
            TEntity entity = _dbContext.Find<TEntity>(id);
            _dbContext.Remove(entity);
            return entity;

        }
    }
}
