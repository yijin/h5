using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Guiyu.Models.Wechat
{
    public class WechatPayInfo
    {
        public int Id
        {
            get;
            set;
        }

        #region 业务参数
        //交易模式 1即时到账 其他保留
        public int trade_mode
        {
            get;
            set;
        }

        //支付结果 0为支付成功 其他保留
        public int trade_state
        {
            get;
            set;
        }

        //支付结果信息 成功时为空
        public string pay_info
        {
            get;
            set;
        }
        //商户号
        public string partner
        {
            get;
            set;
        }
        //银行类型，在微信中使用WX
        public string bank_type
        {
            get;
            set;
        }
        //银行订单号
        public string bank_billno
        {
            get;
            set;
        }
        //支付总金额 单位是分
        public int total_fee
        {
            get;
            set;
        }
        //币种，默认值是1人民币
        public int fee_type
        {
            get;
            set;
        }
        //通知id
        public string notify_id
        {
            get;
            set;
        }
        //交易号
        public string transaction_id
        {
            get;
            set;
        }
        //商户订单号
        public string out_trade_no
        {
            get;
            set;
        }
        //商户数据包
        public string attach
        {
            get;
            set;
        }
        //支付完成时间
        public string time_end
        {
            get;
            set;
        }

        //物流费用 单位是分
        public int transport_fee
        {
            get;
            set;
        }
        //商品费用 单位是分
        public int product_fee
        {
            get;
            set;
        }
        // 折扣价格 单位是分
        public int discount
        {
            get;
            set;
        }

        //买家别名
        public string buyer_alias
        {
            get;
            set;
        }

        #endregion

        #region postdata

        /// <summary>
        /// 用户id
        /// </summary>
        public string OpenId
        {
            get;
            set;
        }

        /// <summary>
        /// 商户id
        /// </summary>
        public string AppId
        {
            get;
            set;
        }

        /// <summary>
        /// 是否关注公众号
        /// </summary>
        public string IsSubscribe
        {
            get;
            set;
        }

        /// <summary>
        /// 时间戳
        /// </summary>
        public string TimeStamp
        {
            get;
            set;
        }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string NonceStr
        {
            get;
            set;
        }
        /// <summary>
        /// 签名
        /// </summary>
        public string AppSignature
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string SignMethod
        {
            get;
            set;
        }
        #endregion
    }
}
