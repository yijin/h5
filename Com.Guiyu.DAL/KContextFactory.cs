using System.Data.Entity;  
using System.Runtime.Remoting.Messaging;
using Com.Guiyu.DAL.User;

namespace Com.Guiyu.DAL
{
   public class KContextFactory
    {
         /// <summary>  
        /// 获取当前数据上下文  
        /// </summary>  
        /// <returns></returns>  
        public static BaseDbContext GetCurrentContext()  
        {
            BaseDbContext context = CallContext.GetData("BaseDbContext") as BaseDbContext;  
            if (context == null)  
            {
                context = new BaseDbContext();
                CallContext.SetData("BaseDbContext", context);  
            }  
            return context;  
        }
       
    }  
    
}
