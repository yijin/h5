using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Guiyu.DAL._12306
{
    public static class PINRepositoryFactory
    {
        public static IPINTopicRepository PINTopicRepository { get { return new PINTopicRepository(); } }
        public static IPINCodeRepository PINCodeRepository { get { return new PINCodeRepository(); } }
        
     
    }
}
