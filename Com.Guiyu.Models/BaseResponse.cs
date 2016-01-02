using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Guiyu.Models
{
    public class BaseResponse<T>
    {
        /// <summary>
        /// 结果类型
        /// </summary>
        public bool IsRight { get; set; }

        /// <summary>
        /// 结果的描述
        /// </summary>
        public string Msg { get; set; }


        /// <summary>
        /// 如果错了，是哪个字段出差
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        public T Data { get; set; }

    }
}
