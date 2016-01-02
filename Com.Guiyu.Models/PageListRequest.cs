using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Guiyu.Models
{
   public class PageListRequest:BaseRequest
    {
       /// <summary>
       /// 页大小  每页显示多少条数据
       /// </summary>
        public int Pagesize
        {
            get;
            set;
        }

       /// <summary>
       /// 页码
       /// </summary>
        public int Page
        {
            get;
            set;
        }

       /// <summary>
       /// 排序字段
       /// </summary>
        public string Ordername
        {
            get;
            set;
        }

       /// <summary>
       /// 是否升序
       /// </summary>
        public bool IsAsc
        {
            get;
            set;
        }

    }
}
