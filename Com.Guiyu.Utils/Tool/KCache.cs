using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;
using System.Web;

namespace Com.Guiyu.Utils.Tool
{
    public class KCache
    {
        protected static volatile Cache cache = HttpRuntime.Cache;
        /// <summary>
        /// 简单设定一个字符串的缓存值,无限缓存期
        /// </summary>
        /// <param name="CacheName">存入的Key</param>
        /// <param name="CacheValue">存入的Value</param>
        public static void AddCacheStr(string CacheName, string CacheValue)
        {

            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheName, CacheValue);
        }




        /// <summary>
        /// 简单获取一个字符串缓存值
        /// </summary>
        public static string GetCacheStr(string CacheName)
        {
            Cache objCache = HttpRuntime.Cache;
            if (objCache.Get(CacheName) == null)
            {
                return "";
            }
            else
            {
                return objCache.Get(CacheName).ToString();
            }
        }





        /// <summary>
        /// 添加一个对象到缓存中
        /// </summary>
        /// <param name="CacheName">key</param>
        /// <param name="CacheValue">object</param>
        /// <param name="TimeOut">设定缓存到期的时间，单位为分钟,0为无限长</param>
        public static void AddCacheObj(string CacheName, object CacheValue, int TimeOut)
        {
            if (CacheName == null || CacheName.Length == 0 || CacheValue == null)
            {
                return;
            }
            CacheItemRemovedCallback callBack = new CacheItemRemovedCallback(onRemove);
            if (TimeOut == 0)
            {
                cache.Insert(CacheName, CacheValue, null, DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.High, callBack);
            }
            else
            {
                cache.Insert(CacheName, CacheValue, null, DateTime.Now.AddMinutes(TimeOut), Cache.NoSlidingExpiration, CacheItemPriority.High, callBack);
            }
        }
        /// <summary>
        /// 获取一个指定对象的缓存值
        /// </summary>
        /// <param name="CacheName">key</param>
        /// <returns></returns>
        public static object GetCacheObj(string CacheName)
        {
            if (cache.Get(CacheName) == null)
            {
                return null;
            }
            else
            {
                return cache.Get(CacheName);
            }
        }
        /// <summary>
        /// 删除缓存对象
        /// </summary>
        /// <param name="CacheName"></param>
        public static void RemoveCacheObj(string CacheName)
        {
            cache.Remove(CacheName);
        }

        //建立回调委托的一个实例
        public static void onRemove(string key, object val, CacheItemRemovedReason reason)
        {
            switch (reason)
            {
                case CacheItemRemovedReason.DependencyChanged:
                    break;
                case CacheItemRemovedReason.Expired:
                    break;
                case CacheItemRemovedReason.Removed:
                    break;
                case CacheItemRemovedReason.Underused:
                    break;
                default: break;
            }
        }
    }
}
