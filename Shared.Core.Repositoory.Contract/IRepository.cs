using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Shared.Core.Repository.Contract
{
    public interface IRepository<TEntityType, in TPrimaryKeyType> where TEntityType : class
    {
        TEntityType Save(TEntityType entity);
        void AddRange(List<TEntityType> entities);
        void Update(TEntityType entity);
        void Delete(TEntityType entity);
        void Delete(Expression<Func<TEntityType, bool>> where);
        void DeleteAndCommit(Expression<Func<TEntityType, bool>> where);
        TEntityType GetById(TPrimaryKeyType id);
        TEntityType Get(Expression<Func<TEntityType, bool>> where);
        bool Any(Expression<Func<TEntityType, bool>> where);
        bool None(Expression<Func<TEntityType, bool>> where);
        IEnumerable<TEntityType> GetAll();
        IEnumerable<TEntityType> GetMany(Expression<Func<TEntityType, bool>> where);
        IEnumerable<TEntityType> GetAutoCompleteItems(Expression<Func<TEntityType, bool>> where, int numberOfReturnValues);
        TEntityType SaveAndCommit(TEntityType entity);
        void AddAndCommit(TEntityType entity);
    }
}