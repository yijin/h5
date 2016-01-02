using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Xml;
using System.ComponentModel;
using System.Web;
using System.Net;
using System.Text.RegularExpressions;
using Com.Guiyu.Utils.Auth;
using Com.Guiyu.Utils.Log;

namespace Com.Guiyu.Utils.Tool
{
    public static class KEmail
    {
        static bool mailSent = false;
        public static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {

            if (e.Cancelled)
            {
                mailSent = false;
            }
            if (e.Error != null)
            {
                mailSent = false;
            }
            else
            {
                mailSent = true;
            }

        }

        public static bool SendEmail(string mailTo, string mailSubject, string mailContent)
        {
            // 设置发送方的邮件信息,例如使用网易的smtp
            string smtpServer = "smtp.qq.com"; //SMTP服务器
            string mailFrom = "info@Yijin.com"; //登陆用户名
            string userPassword = "jedight99";//登陆密码

            // 邮件服务设置
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            smtpClient.Host = smtpServer; //指定SMTP服务器
            smtpClient.Credentials = new System.Net.NetworkCredential(mailFrom, userPassword);//用户名和密码
          

            // 发送邮件设置        
            MailMessage mailMessage = new MailMessage(mailFrom, mailTo); // 发送人和收件人
            mailMessage.Subject = mailSubject;//主题
            mailMessage.Body = mailContent;//内容
            mailMessage.BodyEncoding = Encoding.UTF8;//正文编码
            mailMessage.IsBodyHtml = true;//设置为HTML格式
            mailMessage.Priority = MailPriority.Low;//优先级

            try
            {
                smtpClient.Send(mailMessage); // 发送邮件
                return true;
            }
            catch (SmtpException e)
            {
                KExceptionLog.WriteExcetion("邮件发送错误","email:"+mailTo+ e.InnerException + "/n" + e.Message + "/n" + e.Source + "/n" + e.StackTrace + "/n");
                return false;
            }
        }
    

        public static bool IsEmail(string email)
        {
            string reg = @"[\w\.-]+(\+[\w-]*)?@([\w-]+\.)+[\w-]+";
            Regex re = new Regex(reg);
            if (re.IsMatch(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public static void SendB2BRegisterSubmitEmail(int id,string email,string username)
        {
           // string timestamp = ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString();
            DateTime time = Convert.ToDateTime("2015/3/25");

        
            string token = KEmailToken.GetEmailToken(id,  email);
            string content = "";
            if (DateTime.Now > time)
            {
                 content = "<div id=\"mailContentContainer\" class=\"qmbox qm_con_body_content\"><p>" + username + "，您好！</p>" +
    "<p>&nbsp;&nbsp; &nbsp; <br>" +
    "&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; 感谢您注册云酒.供应链，我们的工作人员将尽快审核您的公司资质，在48小时内向您致电确认，请保持电话畅通。或者您可致电021-52980329*803要求开通账号，并授予查看价格权限。<br>" +
    "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 点击下面的链接完成邮箱认证，将更容易通过审核：<br>" +
    "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <a href=\"http://b2b.wineyun.com/account/validateEmail?id=" + id + "&token=" + token + "\" target=\"_blank\">http://b2b.wineyun.com/account/validateEmail?id=" + id + "&token=" + token + "</a><br>" +
    "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 如果以上链接无法点击，请将其复制到你的浏览器地址栏打开。<br>" +
     "如有疑问欢迎拨打客服热线：021-52980329*803<br>" +
     "<br>" +
    "云酒.供应链帮助您用最低的预算挑选最好的酒款<br>" +
    "云酒.供应链敬上！</p>" +
   // "<p><strong>本邮件为系统自动发送，请勿回复。</p>" +
    "</div>";
            }
            else
            {
                content = "<div id=\"mailContentContainer\" class=\"qmbox qm_con_body_content\"><p>" + username + "，您好！</p>" +
    "<p>&nbsp;&nbsp; &nbsp; <br>" +
    "&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;   感谢您注册云酒.供应链！您获得了免年费预约会员资格。工作人员将审核您的公司资质，并在3月25日正式开放日之前向您致电确认，请您留意。点击下面的链接完成邮箱认证，将更容易通过审核：<br>" +
    "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 点击下面的链接完成邮箱认证，将更容易通过审核：<br>" +
    "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <a href=\"http://b2b.wineyun.com/account/validateEmail?id=" + id + "&token=" + token + "\" target=\"_blank\">http://b2b.wineyun.com/account/validateEmail?id=" + id + "&token=" + token + "</a><br>" +
    "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 如果以上链接无法点击，请将其复制到你的浏览器地址栏打开。<br>" +
     "如有疑问欢迎拨打客服热线：021-52980329*803<br>" +
     "<br>" +
    "云酒.供应链帮助您用最低的预算挑选最好的酒款<br>" +
    "云酒.供应链敬上！</p>" +
    //"<p><strong>本邮件为系统自动发送，请勿回复。</p>" +
    "</div>";
            }
            SendEmail(email, "云酒.供应链注册确认", content);

        }

        public static void SendB2BRegisterSuccessEmail(string email, string username)
        {
           
           
            string content = "<div id=\"mailContentContainer\" class=\"qmbox qm_con_body_content\"><p>" + username + "，您好！</p>" +
"<p>&nbsp;&nbsp; &nbsp; <br>" +
"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 恭喜您的信息被云酒.供应链工作人员审核通过，您可点击下面的链接选购商品：<br>" +
"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <a href='http://b2b.wineyun.com'>http://b2b.wineyun.com</a><br>" +
"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 如果以上链接无法点击，请将其复制到你的浏览器地址栏打开。<br>" +
"<br>" +
"云酒.供应链帮助您用最低的预算挑选最好的酒款<br>" +
"云酒.供应链敬上！</p>" +
//"<p><strong>本邮件为系统自动发送，请勿回复。</p>" +
"</div>";
            SendEmail(email, "云酒.供应链审核通过", content);

        }


        public static void SendPXSuccessEmail(string email,string url,string orderno, string lclname)
        {


            string content = "<div id=\"mailContentContainer\" class=\"qmbox qm_con_body_content\"><p>亲！</p>" +
"<p>&nbsp;&nbsp; &nbsp; <br>" +
"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 您的订单" + orderno + "的参加" + lclname + "拼箱完成100%！<br>" +
"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 请您进入下方链接在48小时内支付90%余款及物流费用。支付成功后 我们将尽快为您发货。<br>" +
"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <a href='" + url + "'>" + url + "</a><br>" +
"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 如您取消订单，10%定金将不予退还。如有疑问请拨打客服热线021-52980329*803<br>" +
"<br>" +
"云酒.供应链帮助您用最低的预算挑选最好的酒款<br>" +
"云酒.供应链敬上！</p>" +
"<p><strong>本邮件为系统自动发送，请勿回复。</p>" +
"</div>";
            SendEmail(email, "拼箱成功", content);

        }


        public static void SendPXFailEmail(string email, string orderno, string lclname)
        {


            string content = "<div id=\"mailContentContainer\" class=\"qmbox qm_con_body_content\"><p>亲爱的会员</p>" +
"<p>&nbsp;&nbsp; &nbsp; <br>" +
"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 很遗憾的通知您，您的订单"+orderno+"参加的"+lclname+"拼箱活动失败了。<br>" +
"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;我们将退还您10%的定金，请您在近日留意账户信息。如有疑问请拨打客服热线021-52980329*803<br>" +
"<br>" +
"云酒.供应链帮助您用最低的预算挑选最好的酒款<br>" +
"云酒.供应链敬上！</p>" +
//"<p><strong>本邮件为系统自动发送，请勿回复。</p>" +
"</div>";
            SendEmail(email, "拼箱失败", content);

        }



        public static void SendShipOrderEmail(string email, string url)
        {


            string content = "<div id=\"mailContentContainer\" class=\"qmbox qm_con_body_content\"><p>亲！</p>" +
"<p>&nbsp;&nbsp; &nbsp; <br>" +
"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 亲！根据您和我们客服人员沟通的情况，我们为您生成了一张物流订单。<br>" +
"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 请点击下方链接进入支付流程<br>" +
"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <a href='" + url + "'>" + url + "</a><br>" +
"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 如有疑问请拨打客服热线021-52980329*803<br>" +
"<br>" +
"云酒.供应链帮助您用最低的预算挑选最好的酒款<br>" +
"云酒.供应链敬上！</p>" +
//"<p><strong>本邮件为系统自动发送，请勿回复。</p>" +
"</div>";
            SendEmail(email, "物流费用支付", content);

        }


        public static void SendDirectPay2Email(string email, string url, string orderno)
        {


            string content = "<div id=\"mailContentContainer\" class=\"qmbox qm_con_body_content\"><p>亲！</p>" +
"<p>&nbsp;&nbsp; &nbsp; <br>" +
"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 亲！你的直采酒款已漂洋过海来到我们的港口，接下来开始交税啦！<br>" +
"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 请点击下方链接进入第二次付款流程：<br>" +
"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <a href='" + url + "'>" + url + "</a><br>" +
"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 如有疑问请拨打客服热线021-52980329*803<br>" +
"<br>" +
"云酒.供应链帮助您用最低的预算挑选最好的酒款<br>" +
"云酒.供应链敬上！</p>" +
                //"<p><strong>本邮件为系统自动发送，请勿回复。</p>" +
"</div>";
            SendEmail(email, "直采酒款税金", content);

        }


        public static void SendDirectPay3Email(string email, string url, string orderno)
        {


            string content = "<div id=\"mailContentContainer\" class=\"qmbox qm_con_body_content\"><p>亲！</p>" +
"<p>&nbsp;&nbsp; &nbsp; <br>" +
"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 亲！你的直采酒款已进入报关流程，马上就可以发到你身边了！在此之前需要你交付报关操作费、佣金、及国内物流费用。<br>" +
"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 请点击下方链接进入第三次付款流程：<br>" +
"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <a href='" + url + "'>" + url + "</a><br>" +
"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 如有疑问请拨打客服热线021-52980329*803<br>" +
"<br>" +
"云酒.供应链帮助您用最低的预算挑选最好的酒款<br>" +
"云酒.供应链敬上！</p>" +
                //"<p><strong>本邮件为系统自动发送，请勿回复。</p>" +
"</div>";
            SendEmail(email, "直采酒款佣金", content);

        }


    }
}
