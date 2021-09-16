using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeDisney.PreAcel.Interfaces.Repositories.Generic
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllEntities();

        #region CRUD
        ValueTask<TEntity> Get(int id);//Read

        Task Add(TEntity entity);//Create

        void Update(TEntity entity);//Update

        void Delete(TEntity entity);//Delete
        #endregion
    }
}
