using Com.Guiyu.Utils.ShortData;
using Com.Guiyu.Models._12306;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Com.Guiyu.Utils.Tool;


namespace Com.Guiyu.Admin.Controllers
{
    public class PinController : Controller
    {
        object lockThis = new object();

        [Authorize(Roles = "king,editor")]
        public ActionResult TopicAdd()
        {
          
       
            int id = 0;
            if (!String.IsNullOrEmpty(Request["id"].Trim()))
            {
                id = Convert.ToInt32(Request["id"].Trim());
            }
            if (id > 0)
            {
                List<PINTopic> list = KShortData.Get<List<PINTopic>>(KShortDataKeyFactory.PinTopicKey, KShortDataDomainFactory.PinTopicDomain);
                return View(list.Find(u => u.Id == id));
            }
            PINTopic model = new PINTopic();
            model.Time = DateTime.Now;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Authorize(Roles = "king,editor")]
        public ActionResult TopicAdd(PINTopic model)
        {

            DateTime time = Convert.ToDateTime(Request["Time"].Trim()).AddHours(Convert.ToInt32(Request["StartTimeHour"].Trim())).AddMinutes(Convert.ToInt32(Request["StartTimeMinute"].Trim()));
            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            //ModelState.AddModelError("", "提供的用户名或密码不正确。");
            model.Time = time;
         
 
            int id = 0;
            if (!String.IsNullOrEmpty(Request["id"].Trim()))
            {
                id = Convert.ToInt32(Request["id"].Trim());
            }

            model.Id = id;
            topicAddOrEdit(model);
            Response.Write("<script> alert('操作成功！');parent.close1(true);</script> ");

            return null;



        }



        [Authorize(Roles = "king,editor")]
        public ActionResult TopicDelete()
        {


            int id = Convert.ToInt32(Request["id"].Trim());


            List<PINTopic> list = KShortData.Get<List<PINTopic>>(KShortDataKeyFactory.PinTopicKey, KShortDataDomainFactory.PinTopicDomain);
            list.RemoveAll(u => u.Id == id);
            KShortData.Set<List<PINTopic>>(KShortDataKeyFactory.PinTopicKey, KShortDataDomainFactory.PinTopicDomain, list);
            return Redirect("/pin/topicList");
        }


        private bool topicAddOrEdit(PINTopic model)
        {
            lock (lockThis)
            {
                List<PINTopic> list = KShortData.Get<List<PINTopic>>(KShortDataKeyFactory.PinTopicKey, KShortDataDomainFactory.PinTopicDomain);
                if (model.Id > 0 && list != null && list.FindIndex(u => u.Id == model.Id) >= 0)
                {
                    // ShortDataArticle oldmodel = list.Find(u => u.Id == id);
                    int index = list.FindIndex(u => u.Id == model.Id);
                    list[index] = model;
                    KShortData.Set<List<PINTopic>>(KShortDataKeyFactory.PinTopicKey, KShortDataDomainFactory.PinTopicDomain,list);
                    return true;
                }
                else
                {
                    if (list == null)
                    {
                        list = new List<PINTopic>();
                    }
                    if (model.Id == 0)
                    {
                        if (list.Count == 0)
                        {
                            model.Id = 1;
                        }
                        else
                        {
                            model.Id = 1 + list.Max(u => u.Id);
                        }
                    }

                    list.Add(model);
                    list = list.OrderBy(u => u.Id).ToList();
                    KShortData.Set<List<PINTopic>>(KShortDataKeyFactory.PinTopicKey, KShortDataDomainFactory.PinTopicDomain,list);
                    return true;

                }
            }
        }
        
        //
        // GET: /Pin/

        [Authorize(Roles = "king,editor")]
        public ActionResult TopicList()
        {

            List<PINTopic> list = KShortData.Get<List<PINTopic>>(KShortDataKeyFactory.PinTopicKey, KShortDataDomainFactory.PinTopicDomain);
            return View(list);
        }




        [Authorize(Roles = "king,editor")]
        public ActionResult CodeList()
        {
            int topicId = Convert.ToInt32(Request["topicid"].Trim());
            if(topicId<=0)
            {
                return null;
            }
            ViewBag.TopicName =Server.UrlDecode( Request["topicname"]);
            ViewBag.TopicId = topicId;
            List<PINCode> list = KShortData.Get<List<PINCode>>(KShortDataKeyFactory.PinCodeKey+"_"+topicId, KShortDataDomainFactory.PinCodeDomain);
            return View(list);
        }




        [Authorize(Roles = "king,editor")]
        public ActionResult CodeAdd()
        {


            int id = 0;
            if (!String.IsNullOrEmpty(Request["id"].Trim()))
            {
                id = Convert.ToInt32(Request["id"].Trim());
            }

            int topicId = Convert.ToInt32(Request["topicId"].Trim());
            if (id > 0)
            {
                List<PINCode> list = KShortData.Get<List<PINCode>>(KShortDataKeyFactory.PinCodeKey + "_" + topicId, KShortDataDomainFactory.PinCodeDomain);
                return View(list.Find(u => u.Id == id));
            }
            PINCode model = new PINCode();
            model.TopicId = topicId;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Authorize(Roles = "king,editor")]
        public ActionResult CodeAdd(PINCode model)
        {

        


            int id = 0;
            if (!String.IsNullOrEmpty(Request["id"].Trim()))
            {
                id = Convert.ToInt32(Request["id"].Trim());
            }
     
            model.Id = id;
            codeAddOrEdit(model);
            Response.Write("<script> alert('操作成功！');parent.close1(true);</script> ");

            return null;



        }



        [Authorize(Roles = "king,editor")]
        public ActionResult CodeDelete()
        {


            int id = Convert.ToInt32(Request["id"].Trim());

            int topicId = Convert.ToInt32(Request["topicId"].Trim());
            if(topicId<=0)
            {
                return null;
            }
            List<PINCode> list = KShortData.Get<List<PINCode>>(KShortDataKeyFactory.PinCodeKey + "_" + topicId, KShortDataDomainFactory.PinCodeDomain);
            list.RemoveAll(u => u.Id == id);
            KShortData.Set<List<PINCode>>(KShortDataKeyFactory.PinCodeKey + "_" + topicId, KShortDataDomainFactory.PinCodeDomain, list);
            return Redirect("/pin/topicList");
        }


        private bool codeAddOrEdit(PINCode model)
        {
            if (model.TopicId <= 0)
            {
                KJs.alert("错误");
                return false;
            }
            lock (lockThis)
            {

                model.Answer = model.Answer.Trim();
                string[] answers = model.Answer.Split(new string[]{","}, StringSplitOptions.RemoveEmptyEntries);
                if(answers==null||answers.Length==0)
                {
                    KJs.alert("没有填写答案或答案格式不正确");
                    return false;
                }
                string answer = "";
                foreach (string str in answers)
                {
                    try
                    {
                        answer += Convert.ToInt32(str) + ",";
                    }
                    catch (Exception e)
                    {
                        KJs.alert("答案格式不正确");
                        return false;
                    }
                }
                if(String.IsNullOrEmpty(answer))
                {
                    KJs.alert("答案格式不正确");
                    return false;
                }
                else
                {
                    model.Answer = answer.Substring(0, answer.Length - 1);
                }
                List<PINCode> list = KShortData.Get<List<PINCode>>(KShortDataKeyFactory.PinCodeKey + "_" + model.TopicId, KShortDataDomainFactory.PinCodeDomain);
                if (model.Id > 0 && list != null && list.FindIndex(u => u.Id == model.Id) >= 0)
                {
                    
                    int index = list.FindIndex(u => u.Id == model.Id);
                    list[index] = model;
                    KShortData.Set<List<PINCode>>(KShortDataKeyFactory.PinCodeKey + "_" + model.TopicId, KShortDataDomainFactory.PinCodeDomain, list);
                    return true;
                }
                else
                {
                    if (list == null)
                    {
                        list = new List<PINCode>();
                    }
                    if (model.Id == 0)
                    {
                        if (list.Count == 0)
                        {
                            model.Id = 1;
                        }
                        else
                        {
                            model.Id = 1 + list.Max(u => u.Id);
                        }
                    }

                    list.Add(model);
                    list = list.OrderBy(u => u.Id).ToList();
                    KShortData.Set<List<PINCode>>(KShortDataKeyFactory.PinCodeKey + "_" + model.TopicId, KShortDataDomainFactory.PinCodeDomain, list);
                    return true;

                }
            }
        }
        

    }
}
