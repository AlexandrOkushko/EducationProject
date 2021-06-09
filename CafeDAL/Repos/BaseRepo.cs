using CafeDAL.Models.Base;
using CafeDAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace CafeDAL.Repos
{
    public class BaseRepo<T> : IDisposable, IRepo<T> where T : EntityBase, new()
    {
        private readonly DbSet<T> _table;
        private readonly CafeContext _db;
        protected CafeContext Context => _db;
        
        public BaseRepo() : this(new CafeContext())
        {

        }

        public BaseRepo(CafeContext context)
        {
            _db = context;
            _table = _db.Set<T>();
        }

        public int Add(T entity)
        {
            _table.Add(entity);
            return SaveChanges();
        }

        public int Add(IList<T> entities)
        {
            _table.AddRange(entities);
            return SaveChanges();
        }

        public int Update(T entity)
        {
            _table.Update(entity);
            return SaveChanges();
        }

        public int Update(IList<T> entities)
        {
            _table.UpdateRange(entities);
            return SaveChanges();
        }

        public int Delete(int id, byte[] timeStamp)
        {
            _db.Entry(new T() { Id = id, Timestamp = timeStamp }).State = EntityState.Deleted;
            return SaveChanges();
        }

        public int Delete(T entity)
        {
            _db.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }

        public T GetOne(int? id) 
            => _table.Find();

        public List<T> GetSome(Expression<Func<T, bool>> where)
            => _table.Where(where).ToList();

        public virtual List<T> GetAll() 
            => _table.ToList();

        public virtual List<T> GetAll<TSortField>(Expression<Func<T, TSortField>> orderBy, bool ascending)
            => (ascending ? _table.OrderBy(orderBy) : _table.OrderByDescending(orderBy)).ToList();

        public List<T> ExecuteQuery(string sql) 
            => _table.FromSqlInterpolated($"{sql}").ToList();

        public List<T> ExecuteQuery(string sql, object[] sqlParametersObjects)
            => _table.FromSqlRaw(sql, sqlParametersObjects).ToList();

        internal int SaveChanges()
        {
            try
            {
                return _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Thrown when there is a concurrency error
                // for now, just rethrow the exception.
                throw;
            }
            catch (RetryLimitExceededException ex)
            {
                //Thrown when max retries have been hit
                //Examine the inner exception(s) for additional details
                //for now, just rethrow the exception
                throw;
            }
            catch (DbUpdateException ex)
            {
                //Thrown when database update fails
                //Examine the inner exception(s) for additional 
                //details and affected objects
                //for now, just rethrow the exception
                throw;
            }
            catch (Exception ex)
            {
                //some other exception happened and should be handled
                throw;
            }
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}
