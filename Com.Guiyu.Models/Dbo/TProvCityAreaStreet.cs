using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Com.Guiyu.Models.Dbo
{
      [Table("t_prov_city_area_street", Schema = "dbo")]
   public class TProvCityAreaStreet
    {
       public int Id
       {
           get;
           set;
       }
       public string Code
       {
           get;
           set;
       }

       public string ParentCode
       {
           get;
           set;
       }
       public string Name
       {
           get;
           set;
       }
       public int Level
       {
           get;
           set;
       }
    }
}
