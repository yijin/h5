using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Com.Guiyu.Utils.Tool
{
   public class KHttpWebResponse
    {
        public static string Get(string url, int? timeout)
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";
            if (timeout.HasValue)
            {
                request.Timeout = timeout.Value;
            }
            WebResponse wrs = request.GetResponse();
            Stream strm = wrs.GetResponseStream();
            StreamReader sr = new StreamReader(strm);
            string str = sr.ReadToEnd();
            sr.Close();
            strm.Close();

            return str;
        }


        public static string Post(string url, int? timeout, Encoding requestEncoding, string data, string contentType)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
            if (requestEncoding == null)
            {
                throw new ArgumentNullException("requestEncoding");
            }
            WebRequest request = WebRequest.Create(url);

            request.Method = "POST";
            request.ContentType = contentType;

            if (timeout.HasValue)
            {
                request.Timeout = timeout.Value;
            }

            //如果需要POST数据  
            if (!String.IsNullOrEmpty(data))
            {
                byte[] databyte = requestEncoding.GetBytes(data);
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(databyte, 0, databyte.Length);
                    stream.Flush();
                    stream.Close();
                }
            }

            WebResponse wrs = request.GetResponse();
            Stream strm = wrs.GetResponseStream();
            StreamReader sr = new StreamReader(strm);
            string str = sr.ReadToEnd();
            sr.Close();
            strm.Close();

            return str;
        }
    }
}
