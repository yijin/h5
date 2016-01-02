using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Data.OleDb;
using System.Web;


namespace Com.Guiyu.Utils.Tool
{
    public static class KExcel
    {
        /// <summary>
        /// 获取excel数据返回为dataset
        /// </summary>
        /// <param name="ExcelPath">excel文件路径</param>
        /// <param name="ExcelTab">excel表名</param>
        public static DataSet GetToGridView(string ExcelPath, string ExcelTab)
        {
            string excelConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ExcelPath + ";Extended Properties=EXCEL 8.0";
            string excelSQL = "Select * from [sheet1$]";
            DataSet ds = new DataSet();
            OleDbConnection conn = new OleDbConnection(excelConn);
            OleDbCommand comm = new OleDbCommand(excelSQL, conn);
            OleDbDataAdapter adapter = new OleDbDataAdapter(comm);
            conn.Open();
            adapter.Fill(ds);
            return ds;


        }

        /// <summary>
        /// 将ds数据直接导出为Excel
        /// </summary>
        /// <param name="ds">dataset数据</param>
        /// <param name="ExcelName">生成的Excel文件名,带.xls</param>
        public static void GetDsToExcel(System.Data.DataSet ds, string ExcelName)
        {
            HttpResponse resp = HttpContext.Current.Response;
            resp.Charset = "utf-8";
            resp.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            resp.AppendHeader("Content-Disposition", "attachment;filename=" + ExcelName);
            string colHeaders = "", ls_item = "";
            int i = 0;

            //定义表对象和行对像，同时用DataSet对其值进行初始化 
            DataTable dt = ds.Tables[0];
            DataRow[] myRow = dt.Select("");
            // typeid=="1"时导出为EXCEL格式文档；typeid=="2"时导出为XML格式文档 

            //取得数据表各列标题，各标题之间以\t分割，最后一个列标题后加回车符 
            for (i = 0; i < dt.Columns.Count; i++)
            {
                if (i == dt.Columns.Count - 1)
                {
                    colHeaders += dt.Columns[i].Caption.ToString() + "\n";
                }
                else
                {
                    colHeaders += dt.Columns[i].Caption.ToString() + "\t";
                }
            }
            //向HTTP输出流中写入取得的数据信息 
            resp.Write(colHeaders);
            //逐行处理数据 
            foreach (DataRow row in myRow)
            {
                //在当前行中，逐列获得数据，数据之间以\t分割，结束时加回车符\n 
                for (i = 0; i < dt.Columns.Count; i++)
                {

                    if (i == dt.Columns.Count - 1)
                    {
                        ls_item += row[i].ToString() + "\n";
                    }
                    else
                    {
                        ls_item += row[i].ToString() + "\t";
                    }
                }
                //当前行数据写入HTTP输出流，并且置空ls_item以便下行数据 
                resp.Write(ls_item);
                ls_item = "";
            }

            //写缓冲区中的数据到HTTP头文档中 
            resp.End();
        }
        /// <summary>
        /// 将datatable数据直接导出为Excel
        /// </summary>
        /// <param name="ds">dataset数据</param>
        /// <param name="ExcelName">生成的Excel文件名,带.xls</param>
        public static void GetDtToExcel(System.Data.DataTable dt, string ExcelName)
        {
            StringWriter sw = new StringWriter();
            string colList = "";
            int i;
            for (i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns.Count - 1 != i)
                {
                    colList += dt.Columns[i].ColumnName + (char)9;
                }
                else
                {
                    colList += dt.Columns[i].ColumnName;
                }
            }
            sw.WriteLine(colList);
            StringBuilder tmplist = new StringBuilder();
            foreach (DataRow dr in dt.Rows)
            {
                tmplist.Remove(0, tmplist.Length);
                for (i = 0; i < dt.Columns.Count; i++)
                {
                    if (dt.Columns.Count - 1 != i)
                    {
                        tmplist.Append(dr[i].ToString() + (char)9);
                    }
                    else
                    {
                        tmplist.Append(dr[i].ToString());
                    }
                }
                sw.WriteLine(tmplist.ToString());
            }
            sw.Close();
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + ExcelName + "");
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.ContentEncoding = Encoding.GetEncoding("GB2312");
            HttpContext.Current.Response.Write(sw);
        }
    }
}
