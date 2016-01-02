using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.EntityModel;
using System.Data.Entity;


namespace Com.Guiyu.DAL
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected BaseDbContext nContext=KContextFactory.GetCurrentContext();
   

        public T Add(T entity)
        {
            //nContext.Configuration.ValidateOnSaveEnabled = false;
            nContext.Set<T>().Add(entity);
       
            nContext.SaveChanges();
            
            return entity;
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
           // nContext.Set<T>().Sum(null,predicate);
            return nContext.Set<T>().Count(predicate);
        }

        public int Sum(Expression<Func<T, bool>> predicate,Expression<Func<T, int>> selector)
        {
            return nContext.Set<T>().Where(predicate).Sum(selector);
        }

        public double Sum(Expression<Func<T, bool>> predicate, Expression<Func<T, double>> selector)
        {
            return nContext.Set<T>().Where(predicate).Sum(selector);
        }

        
        public bool Update(T entity)
        {
            nContext.Set<T>().Attach(entity);
            nContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            return nContext.SaveChanges() > 0;
        }

        public bool Exist(Expression<Func<T, bool>> anyLambda)
        {
        
            return nContext.Set<T>().Any(anyLambda);
        }

        public bool Delete(T entity)
        {
            nContext.Set<T>().Attach(entity);
            nContext.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
            return nContext.SaveChanges() > 0;
        }  

        public T Find(Expression<Func<T, bool>> whereLambda)
        {
            T _entity = nContext.Set<T>().FirstOrDefault<T>(whereLambda);
            return _entity;
        }

        public T Find(Expression<Func<T, bool>> whereLambda, string orderName = "", bool isAsc = true)
        {
            var list = nContext.Set<T>().Where<T>(whereLambda);
            if (!String.IsNullOrEmpty(orderName))
            {
                list = OrderBy(list, orderName, isAsc);
            }
            if(list==null||list.Count<T>()==0)
            {
                return null;
            }
            return list.First<T>();
        }

        public IQueryable<T> FindList(Expression<Func<T, bool>> whereLambda, string orderName = "", bool isAsc = true)
        {
            var list = nContext.Set<T>().Where<T>(whereLambda);
            if (!String.IsNullOrEmpty(orderName))
            {
                list = OrderBy(list, orderName, isAsc);
            }
            return list;
        }

        public IQueryable<T> FindList(Expression<Func<T, bool>> whereLambda, int top, string orderName = "", bool isAsc = true)
        {
            if (!String.IsNullOrEmpty(orderName))
            {
                var list = nContext.Set<T>().Where<T>(whereLambda);
                list = OrderBy(list, orderName, isAsc).Take<T>(top);
                return list;
            }
            else
            {
                return nContext.Set<T>().Where<T>(whereLambda).Take<T>(top);
            }
            
        }

        public IQueryable<T> FindPageList(int pageIndex, int pageSize, out int totalRecord, Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc)
        {
            var list = nContext.Set<T>().Where<T>(whereLamdba);
            totalRecord = list.Count();
            list = OrderBy(list, orderName, isAsc).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            return list;
        }

        public IQueryable<T> OrderBy(IQueryable<T> source, string propertyName, bool isAsc)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source", "不能为空");
            }
            if (string.IsNullOrEmpty(propertyName))
            {
                return source;
            }
            var parameter = Expression.Parameter(source.ElementType);
            var property = Expression.Property(parameter, propertyName);
            if (property == null)
            {
                throw new ArgumentNullException("propertyName", "属性不存在");
            }
            var lambda = Expression.Lambda(property, parameter);
            var methodName = isAsc ? "OrderBy" : "OrderByDescending";
            var resultExpression = Expression.Call(typeof(Queryable), methodName, new Type[] { source.ElementType, property.Type }, source.Expression, Expression.Quote(lambda));
            return source.Provider.CreateQuery<T>(resultExpression);
        }

        public GuiyuDbContextTransaction BeginTransaction()
        {
            return GuiyuDbContextTransaction.BeginTransaction(nContext.Database);
    
            
        }
    }
}


