using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Com.Guiyu.Utils.Tool;
using Com.Guiyu.Utils.Config;
using System.IO;
namespace Com.Guiyu.Utils.ShortData
{
    public static class KShortData
    {

        public static void Set<T>(string key, string domain,T data)
        {

            KSerialize.Serialize<T>(data, getFileNameAndCreateDir(key, domain));

        }


        public static T Get<T>(string key,string domain)
        {
            return KSerialize.DeSerialize<T>(getFileNameAndCreateDir(key, domain));
        }


        public static void Add(string key, string domain,string data)
        {
            string filePath = getFileNameAndCreateDir(key, domain);
            FileInfo file = new FileInfo(filePath);
            if (!Directory.Exists(file.Directory.FullName))
            {
                Directory.CreateDirectory(file.Directory.FullName);
            }
            StreamWriter objStreamWriter = new StreamWriter(filePath, true, Encoding.UTF8);
            objStreamWriter.Write(data);  //将字符串写入到文件中
            objStreamWriter.Flush();
            objStreamWriter.Close();
           
        }

        public static void Add(string key, string domain,int data)
        {

            string filePath = getFileNameAndCreateDir(key, domain);
            FileInfo file = new FileInfo(filePath);
            if (!Directory.Exists(file.Directory.FullName))
            {
                Directory.CreateDirectory(file.Directory.FullName);
            }
            StreamWriter objStreamWriter = new StreamWriter(filePath, true, Encoding.UTF8);
            objStreamWriter.Write(data);  //将字符串写入到文件中
            objStreamWriter.Flush();
            objStreamWriter.Close();

        }

        public static string Get(string key, string domain)
        {
            
            string filePath = getFileNameAndCreateDir(key, domain);
            if (File.Exists(filePath))
            {
                string str = File.ReadAllText(filePath, Encoding.UTF8).Trim();
                return str;
            }
            else
            {
                return String.Empty;
            }
        }

        public static int GetInt32(string key, string domain)
        {
            string str= Get(key, domain);
            int result = 0;
            Int32.TryParse(str, out result);
            return result;
        }
        private static string getFileNameAndCreateDir(string key, string domain)
        {
            key = key.ToLower();

            domain = domain.ToLower();

            string fileDir = KPathConfig.ShortDataPath + "_" + domain + "\\" + key[0] + "\\";

            string filename = key;
            return fileDir + filename;
        }
    }
}
