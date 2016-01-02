using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Com.Guiyu.Models._12306;
using System.Data.Entity;
using Com.Guiyu.Models;
using Com.Guiyu.Models.Dbo;


namespace Com.Guiyu.DAL
{
    //Enable-Migrations -ContextTypeName "Com.Guiyu.DAL.BaseDbContext" -ProjectName "Com.Guiyu.DAL" -Force 
    public class BaseDbContext:DbContext
    {
       

        #region 12306
        public DbSet<PINCode> PINCode { get; set; }
        public DbSet<PINTopic> PINTopic { get; set; }
        #endregion
       

        #region dbo
        public DbSet<TProvCityAreaStreet> TProvCityAreaStreet { get; set; }
        #endregion




    }
}
