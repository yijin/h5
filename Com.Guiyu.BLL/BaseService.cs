using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Guiyu.DAL;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Com.Guiyu.BLL
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private GuiyuDbContextTransaction trans;
        protected IBaseRepository<T> CurrentRepository { get; set; }

        public BaseService(IBaseRepository<T> currentRepository) { CurrentRepository = currentRepository; }

        public T Add(T entity) { return CurrentRepository.Add(entity); }

        public bool Update(T entity) { return CurrentRepository.Update(entity); }

        public IQueryable<T> FindList(Expression<Func<T, bool>> whereLamdba, string orderName = "", bool isAsc = true) { return CurrentRepository.FindList(whereLamdba, orderName, isAsc); }

        public IQueryable<T> FindList(Expression<Func<T, bool>> whereLamdba, int top, string orderName = "", bool isAsc = true) { return CurrentRepository.FindList(whereLamdba, top, orderName, isAsc); }

        public int Count(Expression<Func<T, bool>> predicate) { return CurrentRepository.Count(predicate); }
        public int Sum(Expression<Func<T, bool>> predicate, Expression<Func<T, int>> selector) { return CurrentRepository.Sum( predicate,selector); }
        public double Sum(Expression<Func<T, bool>> predicate, Expression<Func<T, double>> selector) { return CurrentRepository.Sum(predicate, selector); }

        public bool Exist(Expression<Func<T, bool>> anyLambda) { return CurrentRepository.Exist(anyLambda); }

        public bool Delete(T entity) { return CurrentRepository.Delete(entity); }

        public T Find(Expression<Func<T, bool>> whereLambda) { return CurrentRepository.Find(whereLambda); }

        public T Find(Expression<Func<T, bool>> whereLambda, string orderName = "", bool isAsc = true) { return CurrentRepository.Find(whereLambda,orderName,isAsc); }

        public IQueryable<T> FindPageList(int pageIndex, int pageSize, out int totalRecord, Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc)
        { return CurrentRepository.FindPageList(pageIndex, pageSize, out totalRecord, whereLamdba, orderName, isAsc); }

        public IQueryable<T> OrderBy(IQueryable<T> source, string propertyName, bool isAsc)
        { return CurrentRepository.OrderBy(source, propertyName, isAsc); }


        public void TransactionBegin()
        {
            
           trans= CurrentRepository.BeginTransaction();


        }

        public void TransactionCommit()
        {
            if(trans!=null)
            {
                trans.Commit();
                trans.Dispose();
                trans = null;
            }


        }

        public void TransactionRollback()
        {

            if (trans != null)
            {
                trans.Rollback();
                trans.Dispose();
                trans = null;
            }
        }
    }
}
