using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Com.Guiyu.DAL
{
    public class GuiyuDbContextTransaction : IDisposable
    {
       private  DbContextTransaction trans;
       private  int flag = 0;
       private static GuiyuDbContextTransaction GuiyuTran;

       private GuiyuDbContextTransaction(Database database)
       {
           trans = database.BeginTransaction();
           flag = 0;
       }
        public static GuiyuDbContextTransaction BeginTransaction(Database database)
        {


            if (GuiyuTran == null)
            {
                GuiyuTran = new GuiyuDbContextTransaction(database);
            }
            GuiyuTran.flag++;
            return GuiyuTran;
        }
        public void Commit()
        {
        
            if (flag <= 1)
            {
                trans.Commit();
            }
        }
        public void Rollback()
        {
          
            if (flag <= 1)
            {
                trans.Rollback();
            }
        }

        public void Dispose()
        {
            flag--;
            if (flag <= 0)
            {
                trans.Dispose();
                trans = null;
                GuiyuTran = null;

            }
        }
    }
}
