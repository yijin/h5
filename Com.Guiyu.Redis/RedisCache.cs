using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using ServiceStack.Redis;
using System.Linq.Expressions;
using ServiceStack.Redis.Generic;
using ServiceStack.CacheAccess;


namespace Com.Guiyu.Redis
{
    public class RedisCache
    {
       


        public static bool Add<T>(string key, T value)
        {
            using (var client = RedisManager.GetCacheClient())
            {
              
                return client.Add<T>(key, value);

            }
        }
        public static bool Add<T>(string key, T value, DateTime expiresAt)
        {
            using (var client = RedisManager.GetCacheClient())
            {

                return client.Add<T>(key, value,expiresAt);

            }
        }
        public static bool Add<T>(string key, T value, TimeSpan expiresIn)
        {
            using (var client = RedisManager.GetCacheClient())
            {

                return client.Add<T>(key, value,expiresIn);

            }
        }
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
        public static long Decrement(string key, uint amount)
        {
            using (var client = RedisManager.GetCacheClient())
            {

                return client.Decrement(key, amount);

            }
        }
        //
        // 摘要: 
        //     Invalidates all data on the cache.
        public static void FlushAll()
        {
            using (var client = RedisManager.GetCacheClient())
            {

                client.FlushAll();

            }
        }
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
        public static T Get<T>(string key)
        {
            using (var client = RedisManager.GetCacheClient())
            {

                return client.Get<T>(key);

            }
        }
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
        public static IDictionary<string, T> GetAll<T>(IEnumerable<string> keys)
        {
            using (var client = RedisManager.GetCacheClient())
            {

                return client.GetAll<T>(keys);

            }
        }
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
        public static long Increment(string key, uint amount)
        {
            using (var client = RedisManager.GetCacheClient())
            {

                return client.Increment(key, amount);

            }
        }
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
        public static bool Remove(string key)
        {
            using (var client = RedisManager.GetCacheClient())
            {
               
                return client.Remove(key);

            }
        }
        //
        // 摘要: 
        //     Removes the cache for all the keys provided.
        //
        // 参数: 
        //   keys:
        //     The keys.
        public static void RemoveAll(IEnumerable<string> keys)
        {
            using (var client = RedisManager.GetCacheClient())
            {

                client.RemoveAll(keys);

            }
        }
        //
        // 摘要: 
        //     Replaces the item at the cachekey specified only if an items exists at the
        //     location already.
        public static bool Replace<T>(string key, T value)
        {
            using (var client = RedisManager.GetCacheClient())
            {

                return client.Replace<T>(key, value);

            }
        }
        public static bool Replace<T>(string key, T value, DateTime expiresAt)
        {
            using (var client = RedisManager.GetCacheClient())
            {

                return client.Replace<T>(key, value,expiresAt);

            }
        }
        public static bool Replace<T>(string key, T value, TimeSpan expiresIn)
        {
            using (var client = RedisManager.GetCacheClient())
            {

                return client.Replace<T>(key, value, expiresIn);

            }
        }
        //
        // 摘要: 
        //     Sets an item into the cache at the cache key specified regardless if it already
        //     exists or not.
        public static bool Set<T>(string key, T value)
        {
            using (var client = RedisManager.GetCacheClient())
            {

                return client.Set<T>(key, value);
            }
        
           
        }
        public static bool Set<T>(string key, T value, DateTime expiresAt)
        {
            using (var client = RedisManager.GetCacheClient())
            {

                return client.Set<T>(key, value,expiresAt);
            }
        }
        public static bool Set<T>(string key, T value, TimeSpan expiresIn)
        {
            using (var client = RedisManager.GetCacheClient())
            {

                return client.Set<T>(key, value,expiresIn);
            }
        }
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
        public static void SetAll<T>(IDictionary<string, T> values)
        {
            using (var client = RedisManager.GetCacheClient())
            {

                client.SetAll<T>(values);
            }
        }
    }
}
