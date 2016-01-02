using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Guiyu.Redis
{
    public interface IRedisCache
    {
         bool Add<T>(string key, T value);
        bool Add<T>(string key, T value, DateTime expiresAt);
        bool Add<T>(string key, T value, TimeSpan expiresIn);
        //
        // 摘要: 
        //     Increments the value of the specified key by the given amount. The operation
        //     is atomic and happens on the server.  A non existent value at key starts
        //     at 0
        //
        // 参数: 
        //   key:
        //     The identifier for the item to increment.
        //
        //   amount:
        //     The amount by which the client wants to decrease the item.
        //
        // 返回结果: 
        //     The new value of the item or -1 if not found.
        //
        // 备注: 
        //     The item must be inserted into the cache before it can be changed. The item
        //     must be inserted as a System.String. The operation only works with System.UInt32
        //     values, so -1 always indicates that the item was not found.
        long Decrement(string key, uint amount);
        //
        // 摘要: 
        //     Invalidates all data on the cache.
        void FlushAll();
        //
        // 摘要: 
        //     Retrieves the specified item from the cache.
        //
        // 参数: 
        //   key:
        //     The identifier for the item to retrieve.
        //
        // 类型参数: 
        //   T:
        //
        // 返回结果: 
        //     The retrieved item, or null if the key was not found.
        T Get<T>(string key);
        //
        // 摘要: 
        //     Retrieves multiple items from the cache. The default value of T is set for
        //     all keys that do not exist.
        //
        // 参数: 
        //   keys:
        //     The list of identifiers for the items to retrieve.
        //
        // 返回结果: 
        //     a Dictionary holding all items indexed by their key.
        IDictionary<string, T> GetAll<T>(IEnumerable<string> keys);
        //
        // 摘要: 
        //     Increments the value of the specified key by the given amount. The operation
        //     is atomic and happens on the server.  A non existent value at key starts
        //     at 0
        //
        // 参数: 
        //   key:
        //     The identifier for the item to increment.
        //
        //   amount:
        //     The amount by which the client wants to increase the item.
        //
        // 返回结果: 
        //     The new value of the item or -1 if not found.
        //
        // 备注: 
        //     The item must be inserted into the cache before it can be changed. The item
        //     must be inserted as a System.String. The operation only works with System.UInt32
        //     values, so -1 always indicates that the item was not found.
        long Increment(string key, uint amount);
        //
        // 摘要: 
        //     Removes the specified item from the cache.
        //
        // 参数: 
        //   key:
        //     The identifier for the item to delete.
        //
        // 返回结果: 
        //     true if the item was successfully removed from the cache; false otherwise.
        bool Remove(string key);
        //
        // 摘要: 
        //     Removes the cache for all the keys provided.
        //
        // 参数: 
        //   keys:
        //     The keys.
        void RemoveAll(IEnumerable<string> keys);
        //
        // 摘要: 
        //     Replaces the item at the cachekey specified only if an items exists at the
        //     location already.
        bool Replace<T>(string key, T value);
        bool Replace<T>(string key, T value, DateTime expiresAt);
        bool Replace<T>(string key, T value, TimeSpan expiresIn);
        //
        // 摘要: 
        //     Sets an item into the cache at the cache key specified regardless if it already
        //     exists or not.
        bool Set<T>(string key, T value);
        bool Set<T>(string key, T value, DateTime expiresAt);
        bool Set<T>(string key, T value, TimeSpan expiresIn);
        //
        // 摘要: 
        //     Sets multiple items to the cache.
        //
        // 参数: 
        //   values:
        //     The values.
        //
        // 类型参数: 
        //   T:
        void SetAll<T>(IDictionary<string, T> values);
       
    }
}
