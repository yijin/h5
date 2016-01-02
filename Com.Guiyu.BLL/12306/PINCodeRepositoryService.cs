using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Guiyu.Models._12306;
using Com.Guiyu.DAL._12306;

namespace Com.Guiyu.BLL._12306
{
    public class PINCodeRepositoryService : BaseService<PINCode>, IPINCodeRepositoryService
    {
        public PINCodeRepositoryService() : base(PINRepositoryFactory.PINCodeRepository) { }
    }
}
