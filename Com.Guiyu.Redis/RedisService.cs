using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceStack.Redis;
using System.Linq.Expressions;
using ServiceStack.Redis.Generic;

namespace Com.Guiyu.Redis
{
    public class RedisService<T> : IRedisService<T> where T : class, new()
    {

        public T Add(T entity)
        {
            using (var client = RedisManager.GetClient())
            {

             
                return client.Store<T>(entity);

            }
        }
        
        public bool Update(T entity)
        {
            using (var client = RedisManager.GetClient())
            {
               client.Store<T>(entity);

            }
            return true;
        }

        public void Delete(T entity)
        {
            using (var client = RedisManager.GetClient())
            {
              
                 client.Delete<T>(entity);
               

            }
        }

        public T GetById(int id)
        {
            using (var redisClient = RedisManager.GetClient())
            {
               
                IRedisTypedClient<T> client = redisClient.As<T>();
              
                return client.GetById(id);

            }
        }

        public T Find(Func<T, bool> anyLambda)
        {
            using (var redisClient = RedisManager.GetClient())
            {
               
                IRedisTypedClient<T> client = redisClient.As<T>();

                return client.GetAll().Where<T>(anyLambda).First<T>();

            }
        }

       /* public IList<T> FindPageList(int pageIndex, int pageSize,  Func<T, bool> whereLamdba)
        {
            using (var redisClient = RedisManager.GetClient())
            {

                IRedisTypedClient<T> client = redisClient.As<T>();
                
                return client.GetAll().Where<T>(whereLamdba).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize).ToList<T>();
                
            }
        }*/


        public IList<T> FindList(Func<T, bool> anyLambda)
        {
            using (var redisClient = RedisManager.GetClient())
            {

                IRedisTypedClient<T> client = redisClient.As<T>();

                return client.GetAll().Where<T>(anyLambda).ToList<T>();

            }
        }

        public IList<T> FindAll()
        {
            using (var redisClient = RedisManager.GetClient())
            {

                IRedisTypedClient<T> client = redisClient.As<T>();

                return client.GetAll();

            }
        }

    }
}
