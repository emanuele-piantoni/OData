using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;

namespace ExampleOData.NH
{
    public class Repository<T> : IEnumerable
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        protected ISession Session
        {
            get
            {
                return _session;
            }
        }

        #region Implementation of IQueryable

        public System.Linq.Expressions.Expression Expression
        {
            get { return Session.Query<T>().Expression; }
        }

        public Type ElementType
        {
            get { return Session.Query<T>().ElementType; }
        }

        public IQueryProvider Provider
        {
            get { return Session.Query<T>().Provider; }
        }

        #endregion

        #region Implementation of IEnumerable

        public IEnumerator<T> GetEnumerator()
        {
            return Session.Query<T>().AsEnumerable().GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Implementation of IRepository

        public IQueryable<T> Include(Expression<Func<T, object>> subSelector)
        {
            return Session.Query<T>().Fetch(subSelector);
        }

        public void Add(T item)
        {
            if (!Session.Query<T>().Contains(item))
            {
                Session.Save(item);
            }
        }

        public void Remove(T item)
        {
            Session.Delete(item);
        }

        public void Update(T item)
        {
            Session.Save(item);
        }

        #endregion
    }
}
