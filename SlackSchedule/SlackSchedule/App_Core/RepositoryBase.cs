using SlackSchedule.Models;
using System;
using System.Data.Entity;
using System.Linq;
using HPBFramework.IRepository;
using EntityFramework.DbContextScope.Interfaces;

namespace SlackSchedule
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class 
    {
        internal readonly IAmbientDbContextLocator _ambientDbContextLocator;

        internal DatabaseContext DbContext
        {
            get
            {
                DatabaseContext dbContext = _ambientDbContextLocator.Get<DatabaseContext>();

                if (dbContext == null)
                    throw new InvalidOperationException("No ambient DbContext of type UserManagementDbContext found. This means that this repository method has been called outside of the scope of a DbContextScope. A repository must only be accessed within the scope of a DbContextScope, which takes care of creating the DbContext instances that the repositories need and making them available as ambient contexts. This is what ensures that, for any given DbContext-derived type, the same instance is used throughout the duration of a business transaction. To fix this issue, use IDbContextScopeFactory in your top-level business logic service method to create a DbContextScope that wraps the entire business transaction that your service method implements. Then access this repository within that scope. Refer to the comments in the IDbContextScope.cs file for more details.");

                return dbContext;
            }
        }

        public RepositoryBase(IAmbientDbContextLocator ambientDbContextLocator)
		{
			if (ambientDbContextLocator == null) throw new ArgumentNullException("ambientDbContextLocator");
			_ambientDbContextLocator = ambientDbContextLocator;
		}

        public IQueryable<TEntity> Get()
        {
            return DbContext.Set<TEntity>().AsQueryable<TEntity>();
        }

        public TEntity FindById(params object[] id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }

        public void InsertGraph(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            DbContext.Set<TEntity>().Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(params object[] id)
        {
            var entity = DbContext.Set<TEntity>().Find(id);
            //var objectState = entity as IObjectState;
            //if (objectState != null)
            //    objectState.State = ObjectState.Deleted;
            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            DbContext.Set<TEntity>().Attach(entity);
            DbContext.Set<TEntity>().Remove(entity);
        }

        public virtual void Insert(TEntity entity)
        {
            DbContext.Set<TEntity>().Attach(entity);
            DbContext.Set<TEntity>().Add(entity);
        }
    }
}