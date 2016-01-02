using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Guiyu.Models.Dbo
{

    public  class AddressResponce
    {
          public  List<TProvCityAreaStreet> Streets
          {
              get;
              set;
          }
          public  List<TProvCityAreaStreet> Areas
          {
              get;
              set;
          }
          public  List<TProvCityAreaStreet> Citys
        {
            get;
            set;
        }
          public  List<TProvCityAreaStreet> Provs
        {
            get;
            set;
        }
    }
}
