using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Web;
using System.Data;
using System.Text.RegularExpressions;
using Com.Guiyu.Utils.Config;

namespace Com.Guiyu.Utils.Tool
{
    /// <summary>
    /// xml操作类
    /// </summary>
    public static class KXML
    {
        /// <summary>
        /// 读取xml文件为ds数据
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static DataSet readXML(string path)
        {
            FileStream fsreadxml = new FileStream(path, FileMode.Open);
            XmlTextReader xmlreader = new XmlTextReader(fsreadxml);
            DataSet ds = new DataSet();
            ds.ReadXml(xmlreader);
            xmlreader.Close();
            return ds;
        }
        /// <summary>
        /// 将ds数据写成xml文件
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool writeXML(DataSet ds, string path)
        {
            FileStream fsxml = new FileStream(path, FileMode.Create);
            XmlTextWriter xmlwrite = new XmlTextWriter(fsxml, Encoding.UTF8);
            ds.WriteXml(xmlwrite);
            fsxml.Close();
            ds.Dispose();
            return true;
        }
        /// <summary>
        /// 输出为xml格式
        /// </summary>
        /// <param name="str"></param>
        public static void responseXML(string str)
        {
            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.ContentType = "text/xml";
            HttpContext.Current.Response.Write(str);
        }
        /// <summary>
        /// 输出为xml头标记
        /// </summary>
        /// <returns></returns>
        public static string responseXMLtop()
        {
            return "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n";
        }
        /// <summary>
        /// 输出xml的某个node
        /// </summary>
        /// <param name="nodename"></param>
        /// <param name="value"></param>
        /// <param name="isCDATA">是否用CDATA框住</param>
        /// <returns></returns>
        public static string responseNode(string nodename, string value, bool isCDATA)
        {
            if (!isCDATA)
            {
                return ("<" + nodename + ">" + value + "</" + nodename + ">\n");
            }
            return ("<" + nodename + "><![CDATA[" + value + "]]></" + nodename + ">\n");
        }
        /// <summary>
        ///加载一个xml文件到XmlDocument对象
        /// </summary>
        /// <param name="xmlDoc"></param>
        /// <param name="fileName"></param>
        public static void XmlLoad(XmlDocument xmlDoc, string fileName)
        {
            xmlDoc.Load(fileName);
        }
        /// <summary>
        /// 生产XmlDocument对象,返回XmlElement对象
        /// </summary>
        /// <param name="xmlPath">xml路径</param>
        public static XmlElement XmlEle(string xmlPath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlLoad(xmlDoc, xmlPath);
            XmlElement xmlEle = xmlDoc.DocumentElement;
            return xmlEle;
        }
        /// <summary>
        /// 在指定的Xml元素下,添加子Xml元素
        /// </summary>
        /// <param name="xmlElement">被追加子元素的Xml元素</param>
        /// <param name="childElementName">要添加的Xml元素名称</param>
        /// <param name="childElementValue">要添加的Xml元素值</param>
        /// <param name="IsCDataSection">是否是CDataSection类型的子元素</param>
        /// <returns></returns>
        public static bool AppendChildElement(ref XmlElement xmlElement, string childElementName, object childElementValue, bool IsCDataSection)
        {
            if ((xmlElement != null) && (xmlElement.OwnerDocument != null))
            {
                if (IsCDataSection)
                {
                    XmlCDataSection tempdata = xmlElement.OwnerDocument.CreateCDataSection(childElementName);
                    tempdata.InnerText = FiltrateControlCharacter(childElementValue.ToString());
                    XmlElement childXmlElement = xmlElement.OwnerDocument.CreateElement(childElementName);
                    childXmlElement.AppendChild(tempdata);
                    xmlElement.AppendChild(childXmlElement);
                }
                else
                {
                    XmlElement childXmlElement = xmlElement.OwnerDocument.CreateElement(childElementName);
                    childXmlElement.InnerText = FiltrateControlCharacter(childElementValue.ToString());
                    xmlElement.AppendChild(childXmlElement);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 在指定的Xml结点下,添加子Xml元素
        /// </summary>
        /// <param name="xmlElement">被追加子元素的Xml节点</param>
        /// <param name="childElementName">要添加的Xml元素名称</param>
        /// <param name="childElementValue">要添加的Xml元素值</param>
        /// <param name="IsCDataSection">是否是CDataSection类型的子元素</param>
        /// <returns></returns>
        public static bool AppendChildElement(ref XmlNode xmlNode, string childElementName, object childElementValue, bool IsCDataSection)
        {
            if ((xmlNode != null) && (xmlNode.OwnerDocument != null))
            {
                //是否是CData类型Xml结点
                if (IsCDataSection)
                {
                    XmlCDataSection tempdata = xmlNode.OwnerDocument.CreateCDataSection(childElementName);
                    tempdata.InnerText = FiltrateControlCharacter(childElementValue.ToString());
                    XmlElement childXmlElement = xmlNode.OwnerDocument.CreateElement(childElementName);
                    childXmlElement.AppendChild(tempdata);
                    xmlNode.AppendChild(childXmlElement);
                }
                else
                {
                    XmlElement childXmlElement = xmlNode.OwnerDocument.CreateElement(childElementName);
                    childXmlElement.InnerText = FiltrateControlCharacter(childElementValue.ToString());
                    xmlNode.AppendChild(childXmlElement);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 初始化节点, 当节点存在则清除当前路径下的所有子结点, 如不存在则直接创建该结点
        /// </summary>
        /// <param name="xmlpath"></param>
        /// <returns></returns>
        public static XmlNode InitializeNode(XmlDocument xmlDoc, string xmlpath)
        {
            XmlNode xmlNode = xmlDoc.SelectSingleNode(xmlpath);
            if (xmlNode != null)
            {
                xmlNode.RemoveAll();
            }
            else
            {
                xmlNode = CreateNode(xmlDoc, xmlpath);
            }
            return xmlNode;
        }
        /// <summary>
        /// 删除指定路径下面的所有子结点和自身
        /// </summary>
        /// <param name="xmlpath">指定路径</param>
        public static void RemoveNodeAndChildNode(XmlDocument xmlDoc, string xmlpath)
        {
            XmlNodeList xmlNodeList = xmlDoc.SelectNodes(xmlpath);
            if (xmlNodeList.Count > 0)
            {
                foreach (XmlNode xn in xmlNodeList)
                {
                    xn.RemoveAll();
                    xn.ParentNode.RemoveChild(xn);
                }
            }
        }
        /// <summary>
        /// 创建指定路径下的节点
        /// </summary>
        /// <param name="xmlpath">节点路径</param>
        /// <returns></returns>
        public static XmlNode CreateNode(XmlDocument xmlDoc, string xmlpath)
        {

            string[] xpathArray = xmlpath.Split('/');
            string root = "";
            XmlNode parentNode = xmlDoc;
            for (int i = 1; i < xpathArray.Length; i++)
            {
                XmlNode node = xmlDoc.SelectSingleNode(root + "/" + xpathArray[i]);
                if (node == null)
                {
                    XmlElement newElement = xmlDoc.CreateElement(xpathArray[i]);
                    parentNode.AppendChild(newElement);
                }
                root = root + "/" + xpathArray[i];
                parentNode = xmlDoc.SelectSingleNode(root);
            }

            return parentNode;
        }

        /// <summary>
        /// 返回某个节点的值,此节点只存在一次
        /// </summary>
        /// <param name="xmlEle">一个element元素</param>
        /// <param name="nodeValue">一个节点，需带//</param>
        /// <returns></returns>
        public static string xmlNodeValue(XmlElement xmlEle, string nodeValue)
        {
            XmlNodeList xmlList = xmlEle.SelectNodes("//" + nodeValue);
            return xmlList[0].InnerText.ToString();
        }
        /// <summary>
        /// 返回某个节点的数量
        /// </summary>
        /// <param name="xmlEle">一个element元素</param>
        /// <param name="nodeValue">节点名</param>
        /// <returns></returns>
        public static int xmlNodeCount(XmlElement xmlEle, string nodeValue)
        {
            XmlNodeList xmlList = xmlEle.SelectNodes("//" + nodeValue);
            return xmlList.Count;
        }
        /// <summary>
        /// 遍历一个重复的节点，返回二维数组
        /// </summary>
        /// <param name="xmlEle"></param>
        /// <param name="nodeValue"></param>
        /// <returns></returns>
        public static string[,] xmlNodeArr(XmlElement xmlEle, string nodeValue)
        {
            int num = xmlNodeCount(xmlEle, nodeValue);
            XmlNodeList xmlList = xmlEle.SelectNodes("//" + nodeValue);
            string[,] result = new string[num, xmlList[0].ChildNodes.Count];
            for (int i = 0; i < num; i++)
            {
                for (int y = 0; y < xmlList[i].ChildNodes.Count; y++)
                {
                    result[i, y] = xmlList[i].ChildNodes[y].InnerText.ToString();
                }
            }
            return result;
        }
        /// <summary>
        /// 过滤控制字符,包括0x00 - 0x08,0x0b - 0x0c,0x0e - 0x1f
        /// </summary>
        /// <param name="content">要过滤的内容</param>
        /// <returns>过滤后的内容</returns>
        private static string FiltrateControlCharacter(string content)
        {
            return Regex.Replace(content, "[\x00-\x08|\x0b-\x0c|\x0e-\x1f]", "");
        }

        /// <summary>
        /// 写入rss文件
        /// </summary>
        public static bool WriteRssFile(string filename, string title, string link, string author, string descript, DateTime time, string image)
        {
            //1.得到xml对象
            XmlDocument xml = new XmlDocument();
            xml.Load(KPathConfig.RssPath + filename);
            if (xml != null)
            {
                try
                {
                    //获取根节点
                    XmlElement root = xml.DocumentElement;
                    XmlNode node = root.FirstChild;
                    if (KXML.AppendChildElement(ref node, "item", "", false))
                    {
                        XmlNode item = node.LastChild;
                        KXML.AppendChildElement(ref item, "title", title, false);
                        KXML.AppendChildElement(ref item, "link", link, false);
                        KXML.AppendChildElement(ref item, "author", author, false);
                        KXML.AppendChildElement(ref item, "description", descript, false);
                        KXML.AppendChildElement(ref item, "pubDate", time, false);
                        if (!string.IsNullOrEmpty(image))
                        {
                            KXML.AppendChildElement(ref item, "image",  image, false);
                        }
                    }
                    else
                    {
                        return false;
                    }
                    xml.Save(KPathConfig.RssPath + filename);
                    

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
