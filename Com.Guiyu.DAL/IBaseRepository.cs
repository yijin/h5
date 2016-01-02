using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Data.EntityModel;
using System.Data.Entity;


namespace Com.Guiyu.DAL
{ 
    public interface IBaseRepository<T> where T : class
    {
        T Add(T entity);

        int Count(Expression<Func<T, bool>> predicate);
        int Sum(Expression<Func<T, bool>> predicate, Expression<Func<T, int>> selector);
        double Sum(Expression<Func<T, bool>> predicate, Expression<Func<T, double>> selector);
        bool Update(T entity);

        bool Delete(T entity);

        IQueryable<T> FindList(Expression<Func<T, bool>> whereLambda, string orderName = "", bool isAsc = true);

        IQueryable<T> FindList(Expression<Func<T, bool>> whereLambda, int top, string orderName = "", bool isAsc = true);

        bool Exist(Expression<Func<T, bool>> anyLambda);

        T Find(Expression<Func<T, bool>> whereLambda);

        T Find(Expression<Func<T, bool>> whereLambda, string orderName = "", bool isAsc = true);

        IQueryable<T> FindPageList(int pageIndex, int pageSize, out int totalRecord, Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc);

        IQueryable<T> OrderBy(IQueryable<T> source, string propertyName, bool isAsc);

        GuiyuDbContextTransaction BeginTransaction();


    }
}
