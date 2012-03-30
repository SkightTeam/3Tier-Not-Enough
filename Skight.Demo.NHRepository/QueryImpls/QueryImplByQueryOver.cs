using NHibernate.Criterion;
using Skight.Demo.Domain;

namespace Skight.Demo.NHRepository.QueryImpls
{
    public class QueryImplByQueryOver<item>:Query<item>
    {
        public QueryImplByQueryOver(QueryOver<item> query)
        {
            Query = query;
        }

        public QueryOver<item> Query { get; private set; }
    }
}