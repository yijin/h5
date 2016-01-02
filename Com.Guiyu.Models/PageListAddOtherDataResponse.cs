using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Guiyu.Models
{
    public class PageListAddOtherDataResponse<T,U> : PageListResponse<T>
    {
        public U OtherData
        {
            get;
            set;
        }
    }
}
