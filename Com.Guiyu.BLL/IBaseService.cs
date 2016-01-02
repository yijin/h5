using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
using Com.Guiyu.DAL;

namespace Com.Guiyu.BLL
{
    public interface IBaseService<T> where T : class
    {
        T Add(T entity); 

        int Count(Expression<Func<T, bool>> predicate);
        int Sum(Expression<Func<T, bool>> predicate, Expression<Func<T, int>> selector);
        double Sum(Expression<Func<T, bool>> predicate, Expression<Func<T, double>> selector);

        bool Update(T entity);

        IQueryable<T> FindList(Expression<Func<T, bool>> whereLamdba, string orderName = "", bool isAsc = true);

        IQueryable<T> FindList(Expression<Func<T, bool>> whereLamdba, int top, string orderName = "", bool isAsc = true);

        bool Exist(Expression<Func<T, bool>> anyLambda);

        bool Delete(T entity);

        T Find(Expression<Func<T, bool>> whereLambda);

        T Find(Expression<Func<T, bool>> whereLambda, string orderName = "", bool isAsc = true);

        IQueryable<T> FindPageList(int pageIndex, int pageSize, out int totalRecord, Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc);

        IQueryable<T> OrderBy(IQueryable<T> source, string propertyName, bool isAsc);


        void TransactionBegin();
        void TransactionCommit();
        void TransactionRollback();

        
    }
}
