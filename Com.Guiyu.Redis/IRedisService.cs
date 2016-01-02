using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Com.Guiyu.Redis
{
    public interface IRedisService<T>
    {
        T Add(T entity);

        bool Update(T entity);

        void Delete(T entity);


        T GetById(int id);

        T Find(Func<T, bool> anyLambda);

        IList<T> FindAll();

       
    }
}
