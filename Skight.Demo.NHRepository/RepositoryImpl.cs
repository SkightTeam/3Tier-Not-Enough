using System.Collections.Generic;
using Skight.Demo.Domain;

namespace Skight.Demo.NHRepository
{
    public class RepositoryImpl:Repository
    {
        public Item get_by_id<Item>(int id)
        {
            throw new System.NotImplementedException();
        }

        public void save<Item>(Item item)
        {
            throw new System.NotImplementedException();
        }

        public Item get_single_item_matching<Item>(Query<Item> query)
        {
            throw new System.NotImplementedException();
        }

        public void delete<Item>(Item item)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Item> get_all_items_matching<Item>(Query<Item> query)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Item> get_all_items<Item>()
        {
            throw new System.NotImplementedException();
        }
    }
}