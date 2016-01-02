using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Guiyu.Models
{
    public class PageListResponse<T>:BaseResponse<T>
    {
        
        public int TotalCount { get; set; }

        public IList<T> Data { get; set; }

        public int Pagesize { get; set; }

       
    }
}
