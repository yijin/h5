using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Guiyu.Models._12306
{
    [Table("H5_PINTopic", Schema = "H5")]
    public class PINTopic
    {
        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public String Des
        {
            get;
            set;
        }


        /// <summary>
        /// 挑战成功描述
        /// </summary>
        public String SuccessDes
        {
            get;
            set;
        }


        /// <summary>
        /// 挑战失败描述
        /// </summary>
        public String FailDes
        {
            get;
            set;
        }

        public DateTime Time
        {
            get;
            set;
        }
   


    }
}
