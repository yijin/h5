using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Com.Guiyu.Utils.Config;

namespace Com.Guiyu.Models._12306
{

    [Table("H5_PINCode", Schema = "H5")]
    public class PINCode
    {
        public int Id
        {
            get;
            set;
        }

        public string Des
        {
            get;
            set;
        }

        public string Img
        {
            get;
            set;
        }

        [NotMapped]
        public string ImgUrl
        {
            get
            {
                return KUrlConfig.ImageUrl+"/"+Img;
            }
        }

        public String Answer
        {
            get;
            set;
        }

        public int TopicId
        {
            get;
            set;

        }
    }
}
