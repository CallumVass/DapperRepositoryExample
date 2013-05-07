using DomainModel.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using DapperExtensions;

namespace DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["DapperExample"].ConnectionString);
            }
        }

        public virtual int Add(T entity)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                return cn.Insert<T>(entity);
            }
        }

        public virtual void Remove(T entity)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                cn.Delete<T>(entity);
            }
        }

        public virtual void Update(T entity)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                cn.Update<T>(entity);
            }
        }

        public virtual T GetById(int id)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                return cn.Get<T>(id);
            }
        }

        public virtual List<T> GetAll()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                return cn.GetList<T>().ToList();
            }
        }

        public virtual List<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();
                return cn.GetList<T>(predicate).ToList();
            }
        }

        public void Remove(int id)
        {
            var entity = GetById(id);
            Remove(entity);
        }
    }
}
