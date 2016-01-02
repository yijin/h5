using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;

namespace Com.Guiyu.Utils.Tool
{
    public static class KSerialize
    {


        public static void Serialize<T>(T o, string filePath)
        {
            FileInfo file = new FileInfo(filePath);
            if (!Directory.Exists(file.Directory.FullName))
            {
                Directory.CreateDirectory(file.Directory.FullName);
            }
            string json = new JavaScriptSerializer().Serialize(o);
            StreamWriter sw = new StreamWriter(filePath, false);
            sw.Write(json);
            sw.Flush();
            sw.Close();
        }


        public static T DeSerialize<T>(string filePath)
        {


            if (File.Exists(filePath))
            {
                string str = File.ReadAllText(filePath, Encoding.UTF8).Trim();
                return new JavaScriptSerializer().Deserialize<T>(str);
                
            }
            else
            {
                return default(T);
            }
        }


        /// <summary>
        /// JSON序列化
        /// </summary>
        public static string JsonSerializer<T>(T t)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, t);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            return jsonString;
        }

        /// <summary>
        /// JSON反序列化
        /// </summary>
        public static T JsonDeserialize<T>(string jsonString)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T obj = (T)ser.ReadObject(ms);
            return obj;
        }
    }
}
