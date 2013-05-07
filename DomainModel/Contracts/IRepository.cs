using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DomainModel.Contracts
{
    public interface IRepository<T>
    {
        int Add(T entity);
        void Remove(T entity);
        void Remove(int id);
        void Update(T entity);
        T GetById(int id);
        List<T> GetAll();
        List<T> Find(Expression<Func<T, bool>> predicate);
    }
}
