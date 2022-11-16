using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Core;

namespace TelefonRehberi.DataAccessLayer.EntityFramework
{
    public class RepositoryDUFIL<T> : RepositoryBase , IDataAccess<T> where T : class
    {
        private DbSet<T> _dbset;

        public RepositoryDUFIL()
        {
            _dbset = context.Set<T>();
        }

        public List<T> List()
        {
            return _dbset.ToList();
        }

        public List<T> List(Expression<Func<T,bool>> kosul)
        {
            return _dbset.Where(kosul).ToList();
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public int Insert(T obj)
        {
            _dbset.Add(obj);

            return Save();
        }

        public int Delete(T obj)
        {
            _dbset.Remove(obj);

            return Save();
        }

        public int Update(T obj)
        {
            return Save();
        }

        public T Find(Expression<Func<T,bool>> kosul)
        {
            return _dbset.Where(kosul).FirstOrDefault();
        }
    }
}
