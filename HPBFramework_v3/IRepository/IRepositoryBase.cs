using EntityFramework.DbContextScope.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HPBFramework.IRepository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Get();

        TEntity FindById(params object[] id);

        void InsertGraph(TEntity entity);

        void Update(TEntity entity);

        void Delete(params object[] id);

        void Delete(TEntity entity);

        void Insert(TEntity entity);
    }
}