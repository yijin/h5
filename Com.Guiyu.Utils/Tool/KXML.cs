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
    /// xml������
    /// </summary>
    public static class KXML
    {
        /// <summary>
        /// ��ȡxml�ļ�Ϊds����
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
        /// ��ds����д��xml�ļ�
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
        /// ���Ϊxml��ʽ
        /// </summary>
        /// <param name="str"></param>
        public static void responseXML(string str)
        {
            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.ContentType = "text/xml";
            HttpContext.Current.Response.Write(str);
        }
        /// <summary>
        /// ���Ϊxmlͷ���
        /// </summary>
        /// <returns></returns>
        public static string responseXMLtop()
        {
            return "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n";
        }
        /// <summary>
        /// ���xml��ĳ��node
        /// </summary>
        /// <param name="nodename"></param>
        /// <param name="value"></param>
        /// <param name="isCDATA">�Ƿ���CDATA��ס</param>
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
        ///����һ��xml�ļ���XmlDocument����
        /// </summary>
        /// <param name="xmlDoc"></param>
        /// <param name="fileName"></param>
        public static void XmlLoad(XmlDocument xmlDoc, string fileName)
        {
            xmlDoc.Load(fileName);
        }
        /// <summary>
        /// ����XmlDocument����,����XmlElement����
        /// </summary>
        /// <param name="xmlPath">xml·��</param>
        public static XmlElement XmlEle(string xmlPath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlLoad(xmlDoc, xmlPath);
            XmlElement xmlEle = xmlDoc.DocumentElement;
            return xmlEle;
        }
        /// <summary>
        /// ��ָ����XmlԪ����,�����XmlԪ��
        /// </summary>
        /// <param name="xmlElement">��׷����Ԫ�ص�XmlԪ��</param>
        /// <param name="childElementName">Ҫ��ӵ�XmlԪ������</param>
        /// <param name="childElementValue">Ҫ��ӵ�XmlԪ��ֵ</param>
        /// <param name="IsCDataSection">�Ƿ���CDataSection���͵���Ԫ��</param>
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
        /// ��ָ����Xml�����,�����XmlԪ��
        /// </summary>
        /// <param name="xmlElement">��׷����Ԫ�ص�Xml�ڵ�</param>
        /// <param name="childElementName">Ҫ��ӵ�XmlԪ������</param>
        /// <param name="childElementValue">Ҫ��ӵ�XmlԪ��ֵ</param>
        /// <param name="IsCDataSection">�Ƿ���CDataSection���͵���Ԫ��</param>
        /// <returns></returns>
        public static bool AppendChildElement(ref XmlNode xmlNode, string childElementName, object childElementValue, bool IsCDataSection)
        {
            if ((xmlNode != null) && (xmlNode.OwnerDocument != null))
            {
                //�Ƿ���CData����Xml���
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
        /// ��ʼ���ڵ�, ���ڵ�����������ǰ·���µ������ӽ��, �粻������ֱ�Ӵ����ý��
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
        /// ɾ��ָ��·������������ӽ�������
        /// </summary>
        /// <param name="xmlpath">ָ��·��</param>
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
        /// ����ָ��·���µĽڵ�
        /// </summary>
        /// <param name="xmlpath">�ڵ�·��</param>
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
        /// ����ĳ���ڵ��ֵ,�˽ڵ�ֻ����һ��
        /// </summary>
        /// <param name="xmlEle">һ��elementԪ��</param>
        /// <param name="nodeValue">һ���ڵ㣬���//</param>
        /// <returns></returns>
        public static string xmlNodeValue(XmlElement xmlEle, string nodeValue)
        {
            XmlNodeList xmlList = xmlEle.SelectNodes("//" + nodeValue);
            return xmlList[0].InnerText.ToString();
        }
        /// <summary>
        /// ����ĳ���ڵ������
        /// </summary>
        /// <param name="xmlEle">һ��elementԪ��</param>
        /// <param name="nodeValue">�ڵ���</param>
        /// <returns></returns>
        public static int xmlNodeCount(XmlElement xmlEle, string nodeValue)
        {
            XmlNodeList xmlList = xmlEle.SelectNodes("//" + nodeValue);
            return xmlList.Count;
        }
        /// <summary>
        /// ����һ���ظ��Ľڵ㣬���ض�ά����
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
        /// ���˿����ַ�,����0x00 - 0x08,0x0b - 0x0c,0x0e - 0x1f
        /// </summary>
        /// <param name="content">Ҫ���˵�����</param>
        /// <returns>���˺������</returns>
        private static string FiltrateControlCharacter(string content)
        {
            return Regex.Replace(content, "[\x00-\x08|\x0b-\x0c|\x0e-\x1f]", "");
        }

        /// <summary>
        /// д��rss�ļ�
        /// </summary>
        public static bool WriteRssFile(string filename, string title, string link, string author, string descript, DateTime time, string image)
        {
            //1.�õ�xml����
            XmlDocument xml = new XmlDocument();
            xml.Load(KPathConfig.RssPath + filename);
            if (xml != null)
            {
                try
                {
                    //��ȡ���ڵ�
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
