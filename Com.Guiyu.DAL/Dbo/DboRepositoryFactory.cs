using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Guiyu.DAL.Dbo
{
    public static class DboRepositoryFactory
    {
        public static TProvCityAreaStreetRepository TProvCityAreaStreetRepository { get { return new TProvCityAreaStreetRepository(); } }
      
    }
}
