using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Core;
using TelefonRehberi.DataAccessLayer.EntityFramework;
using TelefonRehberi.Entities;

namespace TelefonRehberi.BusinessLayer
{
    public abstract class BaseManager<T> : IDataAccess<T> where T : class
    {
        private RepositoryDUFIL<T> repo = new RepositoryDUFIL<T>();

        public virtual int Delete(T obj)
        {
            return repo.Delete(obj);
        }

        public virtual T Find(Expression<Func<T, bool>> kosul)
        {
            return repo.Find(kosul);
        }

        public virtual int Insert(T obj)
        {
            return repo.Insert(obj);
        }

        public virtual List<T> List()
        {
            return repo.List();
        }

        public virtual List<T> List(Expression<Func<T, bool>> kosul)
        {
            return repo.List(kosul);
        }

        public virtual int Save()
        {
            return repo.Save();
        }

        public virtual int Update(T obj)
        {
            return repo.Update(obj);
        }
    }
}
