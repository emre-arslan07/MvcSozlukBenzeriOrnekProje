using MvcProjeKampiDeneme.DAL.Abstract;
using MvcProjeKampiDeneme.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcProjeKampiDeneme.DAL.Concrete.EntityFramework
{
    public class EFRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
         where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Delete(TEntity entity)
        {
            using (TContext contextdb = new TContext())
            {
                var deletedEntity = contextdb.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                contextdb.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext contextDb = new TContext())
            {
                return contextDb.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
               TContext contextDb = new TContext();            
                return filter == null ?
                    contextDb.Set<TEntity>().ToList() :
                    contextDb.Set<TEntity>().Where(filter).ToList();
            
        }

        public void Insert(TEntity entity)
        {
            using (TContext contextDb = new TContext())
            {
                var addedEntity = contextDb.Entry(entity);
                addedEntity.State = EntityState.Added;
                contextDb.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext contextDb = new TContext())
            {
                var updatedEntity = contextDb.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                contextDb.SaveChanges();
            }
        }
    }
}
