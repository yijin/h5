using Com.Guiyu.DAL.Dbo;
using Com.Guiyu.Models.Dbo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Guiyu.BLL.Dbo
{
    public class TProvCityAreaStreetService : BaseService<TProvCityAreaStreet>,ITProvCityAreaStreetService
    {
        public TProvCityAreaStreetService() : base(DboRepositoryFactory.TProvCityAreaStreetRepository) { }
        
    }
}
