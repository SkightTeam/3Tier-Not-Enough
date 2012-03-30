using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Criterion;
using Skight.Demo.Domain;
using Skight.Demo.NHRepository.QueryImpls;

namespace Skight.Demo.NHRepository
{
    public class RepositoryImpl:Repository
    {
        ISession session
        {
            get { return SessionProvider.Instance.CurrentSession; }
        }
        #region CRUD
        public Item get_by_id<Item>(int id)
        {
            return session.Get<Item>(id);
        }

        public void save<Item>(Item item)
        {
            session.SaveOrUpdate(item);
        }

        public void delete<Item>(Item item)
        {
            session.Delete(item);
        }

        #endregion

        #region Advanced Query

        public IEnumerable<Item> get_all_items_matching<Item>(Query<Item> query)
        {
            if (query == null)
                throw new ArgumentNullException();

            if (query is QueryImplByQueryOver<Item>)
            {
                QueryOver<Item> my_query = (query as QueryImplByQueryOver<Item>).Query;
                return my_query.GetExecutableQueryOver(session).List();
            }
            throw new ArgumentException(
                string.Format("Query {0} is not type supported.", query.GetType()));
        }

        public Item get_single_item_matching<Item>(Query<Item> query)
        {
            IEnumerable<Item> result = get_all_items_matching(query);
            if (result.Count() > 1)
                throw new TooManyRowsMatchingException();
            if (result.Count() <= 0)
                throw new NoRowsMatchingQueryException();
            return result.Single();
        }

        #endregion 

        //Shouldn't use every often
        public IEnumerable<Item> get_all_items<Item>()
        {
            return session.CreateCriteria(typeof(Item)).List<Item>();
        }
    }
}