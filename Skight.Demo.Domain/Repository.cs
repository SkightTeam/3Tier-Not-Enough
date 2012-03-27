using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Skight.Demo.Domain
{
    public interface Repository
    {
        Item get_by_id<Item>(int id);
        void save<Item>(Item item);
        Item get_single_item_matching<Item>(Query<Item> query);
        void delete<Item>(Item item);

        IEnumerable<Item> get_all_items_matching<Item>(Query<Item> query);
        IEnumerable<Item> get_all_items<Item>();
    }
}