using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using Com.Guiyu.Utils.Config;
using System.IO;

namespace Com.Guiyu.Admin.Views.Upload
{
    public partial class Image : System.Web.Mvc.ViewPage
    {
       // UnobtrusiveValidationMode= UnobtrusiveValidationMode.None;
        private string NoFileMessage = "您没有选择文件。";
        private string UploadSuccessMessage = "上传成功";
        private string UploadFailureMessage = "上传失败。";
        private string NoImagesMessage = "该文件夹是空的";
        private string NoFolderSpecifiedMessage = "您要上传到的文件夹不存在。";
        private string NoFileToDeleteMessage = "您没有选中要删除的文件。";
        private string InvalidFileTypeMessage = "您无法上传这种类型的文件。";
        private string[] AcceptedFileTypes = new string[] { "jpg", "JPG", "jpeg", "jpe", "gif", "GIF", "png", "PNG" };

        // Configuration
        private bool UploadIsEnabled = true;         // 是否允许上传文件
        private bool DeleteIsEnabled = true;         // 是否允许删除文件
        private string DefaultImageFolder = "images";  // 默认的起始文件夹
        public string textid;
        public string imgpath;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            this.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            imgpath = KPathConfig.ImagePath;
            if (!HttpContext.Current.User.Identity.IsAuthenticated || HttpContext.Current.User.Identity.Name == "")
            {
                Response.End();
            }
            string isframe = "" + Request["frame"];
            if (Request["url"] != null)
            {
                DefaultImageFolder = Request["url"].ToString();
                if (!Page.IsPostBack)
                {
                    if (isframe == "")
                    {
                        if (!Directory.Exists(imgpath + "upload\\" + DefaultImageFolder.Replace("/", "\\")))
                        {
                            Directory.CreateDirectory(imgpath + "upload\\" + DefaultImageFolder.Replace("/", "\\"));
                        }
                        if (!Directory.Exists(imgpath + "upload\\" + DefaultImageFolder.Replace("/", "\\") + "\\" + DateTime.Now.ToString("yyyyMM")))
                        {
                            Directory.CreateDirectory(imgpath + "upload\\" + DefaultImageFolder.Replace("/", "\\") + "\\" + DateTime.Now.ToString("yyyyMM"));
                        }

                    }
                }


            }
            if (!String.IsNullOrEmpty(Request["textid"]))
            {
                textid = Request["textid"];
            }
            if (isframe != "")
            {
                MainPage.Visible = true;
                iframePanel.Visible = false;

                string rif = "" + Request["rif"];
                string cif = "" + Request["cif"];
                if (!String.IsNullOrEmpty(Request["textid"]))
                {
                    textid = Request["textid"];
                }

                if (cif != "" && rif != "")
                {
                    RootImagesFolder.Value = rif;
                    CurrentImagesFolder.Value = cif;
                    hfTextId.Value = textid + "";

                }
                else
                {
                    RootImagesFolder.Value = DefaultImageFolder;
                    CurrentImagesFolder.Value = DefaultImageFolder;
                    hfTextId.Value = textid + "";

                }


                UploadPanel.Visible = UploadIsEnabled;
            //    btndel.Visible = DeleteIsEnabled;

                string FileErrorMessage = "";
                string ValidationString = ".*(";

                for (int i = 0; i < AcceptedFileTypes.Length; i++)
                {
                    ValidationString += "[\\." + AcceptedFileTypes[i] + "]";
                    if (i < (AcceptedFileTypes.Length - 1)) ValidationString += "|";
                    FileErrorMessage += AcceptedFileTypes[i];
                    if (i < (AcceptedFileTypes.Length - 1)) FileErrorMessage += ", ";
                }
                FileValidator.ValidationExpression = ValidationString + ")$";
                FileValidator.ErrorMessage = FileErrorMessage;

                if (!IsPostBack)
                {
                    DisplayImages();
                }

            }
            else
            {

            }

            if (Request["FileToDelete"] != null && Request["FileToDelete"] != "" && Request["FileToDelete"] != "undefined")
            {

                DeleteImage_OnClick();
                FileToDelete.Value = "";
                return;
               
            }
            if (Request["CurrentImagesFolder"] != null && Request["CurrentImagesFolder"].Trim() != "")
            {
                if (UploadFile.PostedFile.FileName.Trim() != "")
                {
                    if (IsValidFileType(UploadFile.PostedFile.FileName))
                    {
                        UploadImage_OnClick();
                        return;
                    }
                }
            }
           
            


            hfaction.Value = "";
           
        }

        public void UploadImage_OnClick()
        {
            
            if (true)
            {
                if (Request["CurrentImagesFolder"] != null && Request["CurrentImagesFolder"].Trim() != "")
                {
                    if (UploadFile.PostedFile.FileName.Trim() != "")
                    {
                        if (IsValidFileType(UploadFile.PostedFile.FileName))
                        {
                            try
                            {
                                string UploadFileName = "";
                                string UploadFileDestination = "";
                                UploadFileName = DateTime.Now.ToString("ddHHmmssffff") + UploadFile.PostedFile.FileName.Substring(UploadFile.PostedFile.FileName.LastIndexOf("."));

                                UploadFileDestination = imgpath + "upload\\";
                                UploadFileDestination += CurrentImagesFolder.Value;
                                UploadFileDestination += "\\";
                            //    Response.Write(UploadFileDestination + UploadFileName);
                              //  Response.End();
                                UploadFile.PostedFile.SaveAs(UploadFileDestination + UploadFileName);
                                ResultsMessage.Text = UploadSuccessMessage;
                            }
                            catch (Exception ex)
                            {
                                //ResultsMessage.Text = "Your file could not be uploaded: " + ex.Message;
                                ResultsMessage.Text = UploadFailureMessage;
                                throw ex;
                            }
                        }
                        else
                        {

                            ResultsMessage.Text = InvalidFileTypeMessage;
                        }
                    }
                    else
                    {
                        ResultsMessage.Text = NoFileMessage;
                    }
                }
                else
                {
                    ResultsMessage.Text = NoFolderSpecifiedMessage;
                }
            }
            else
            {
                
                ResultsMessage.Text = InvalidFileTypeMessage;

            }

           // throw new Exception("" + InvalidFileTypeMessage);
           // UploadFile.Value = null;
         
            DisplayImages();

           
        }

        public void DeleteImage_OnClick()
        {
           
            if (Request["FileToDelete"]!=null&&Request["FileToDelete"] != "" && Request["FileToDelete"] != "undefined")
            {
                try
                {
                    //string AppPath = HttpContext.Current.Request.PhysicalApplicationPath;
                    string AppPath = imgpath + "upload\\";
                    System.IO.File.Delete(AppPath + Request["CurrentImagesFolder"] + "\\" +Request["FileToDelete"]);
                    ResultsMessage.Text = "已删除: " + Request["FileToDelete"];
                }
                catch (Exception ex)
                {
                    ResultsMessage.Text = "删除失败。";
                }
            }
            else
            {
                ResultsMessage.Text = NoFileToDeleteMessage;
            }
            DisplayImages();
        }

        private bool IsValidFileType(string FileName)
        {
            string ext = FileName.Substring(FileName.LastIndexOf(".") + 1, FileName.Length - FileName.LastIndexOf(".") - 1);
            for (int i = 0; i < AcceptedFileTypes.Length; i++)
            {
                if (ext == AcceptedFileTypes[i])
                {
                    return true;

                }
            }
            return false;
        }


        private string[] ReturnFilesArray()
        {
            if (CurrentImagesFolder.Value != "")
            {
                try
                {

                    string AppPath = imgpath + "upload\\";
                    string ImageFolderPath = AppPath + CurrentImagesFolder.Value.Replace("/", "\\");
                    //Jscript.JsAlert(ImageFolderPath,this);
                    string[] FilesArray = System.IO.Directory.GetFiles(ImageFolderPath, "*");
                    return FilesArray;


                }
                catch
                {

                    return null;
                }
            }
            else
            {
                return null;
            }

        }

        private string[] ReturnDirectoriesArray()
        {
            if (CurrentImagesFolder.Value != "")
            {
                try
                {
                    //string AppPath = HttpContext.Current.Request.PhysicalApplicationPath;
                    string AppPath = imgpath + "upload\\";
                    string CurrentFolderPath = AppPath + CurrentImagesFolder.Value.Replace("/", "\\");
                    string[] DirectoriesArray = System.IO.Directory.GetDirectories(CurrentFolderPath, "*");
                    return DirectoriesArray;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public void DisplayImages()
        {

            string[] FilesArray = ReturnFilesArray();
            string[] DirectoriesArray = ReturnDirectoriesArray();
            //string AppPath = HttpContext.Current.Request.PhysicalApplicationPath;
            string AppPath = imgpath + "upload\\";
            string AppUrl;



            AppUrl = KUrlConfig.ImageUrl + "/upload/";
            GalleryPanel.Controls.Clear();
            if ((FilesArray == null || FilesArray.Length == 0) && (DirectoriesArray == null || DirectoriesArray.Length == 0))
            {
                //gallerymessage.Text = NoImagesMessage + ": " + CurrentImagesFolder.Value;

            }


            string ImageFileName = "";
            string ImageFileLocation = "";

            int thumbWidth = 94;
            int thumbHeight = 94;

            if (CurrentImagesFolder.Value != RootImagesFolder.Value)
            {

                System.Web.UI.HtmlControls.HtmlImage myHtmlImage = new System.Web.UI.HtmlControls.HtmlImage();
                myHtmlImage.Src = "/images/ftb/folder.up.gif";
                myHtmlImage.Attributes["unselectable"] = "on";
                myHtmlImage.Attributes["align"] = "absmiddle";
                myHtmlImage.Attributes["vspace"] = "36";

                string ParentFolder = CurrentImagesFolder.Value.Substring(0, CurrentImagesFolder.Value.LastIndexOf("\\"));

                System.Web.UI.WebControls.Panel myImageHolder = new System.Web.UI.WebControls.Panel();
                myImageHolder.CssClass = "imageholder";
                myImageHolder.Attributes["unselectable"] = "on";
                myImageHolder.Attributes["onclick"] = "divClick(this,'');";
                myImageHolder.Attributes["ondblclick"] = "back('" + RootImagesFolder.Value + "','" + hfTextId.Value + "');";
                myImageHolder.Controls.Add(myHtmlImage);

                System.Web.UI.WebControls.Panel myMainHolder = new System.Web.UI.WebControls.Panel();
                myMainHolder.CssClass = "imagespacer";
                myMainHolder.Controls.Add(myImageHolder);

                System.Web.UI.WebControls.Panel myTitleHolder = new System.Web.UI.WebControls.Panel();
                myTitleHolder.CssClass = "titleHolder";
                myTitleHolder.Controls.Add(new LiteralControl("向上"));
                myMainHolder.Controls.Add(myTitleHolder);

                GalleryPanel.Controls.Add(myMainHolder);

            }

            foreach (string _Directory in DirectoriesArray)
            {

                try
                {
                    string DirectoryName = _Directory.ToString();


                    System.Web.UI.HtmlControls.HtmlImage myHtmlImage = new System.Web.UI.HtmlControls.HtmlImage();
                    myHtmlImage.Src = "/images/ftb/folder.big.gif";
                    myHtmlImage.Attributes["unselectable"] = "on";
                    myHtmlImage.Attributes["align"] = "absmiddle";
                    myHtmlImage.Attributes["vspace"] = "29";

                    System.Web.UI.WebControls.Panel myImageHolder = new System.Web.UI.WebControls.Panel();
                    myImageHolder.CssClass = "imageholder";
                    myImageHolder.Attributes["unselectable"] = "on";
                    myImageHolder.Attributes["onclick"] = "divClick(this,'');";
                    myImageHolder.Attributes["ondblclick"] = "gotoFolder('" + RootImagesFolder.Value + "','" + DirectoryName.Replace(AppPath, "").Replace("\\", "\\\\") + "','" + hfTextId.Value + "');";
                    myImageHolder.Controls.Add(myHtmlImage);

                    System.Web.UI.WebControls.Panel myMainHolder = new System.Web.UI.WebControls.Panel();
                    myMainHolder.CssClass = "imagespacer";
                    myMainHolder.Controls.Add(myImageHolder);

                    System.Web.UI.WebControls.Panel myTitleHolder = new System.Web.UI.WebControls.Panel();
                    myTitleHolder.CssClass = "titleHolder";
                    myTitleHolder.Controls.Add(new LiteralControl(DirectoryName.Substring(DirectoryName.LastIndexOf("\\") + 1)));
                    myMainHolder.Controls.Add(myTitleHolder);

                    GalleryPanel.Controls.Add(myMainHolder);
                }
                catch
                {
                    // nothing for error
                }
            }

            foreach (string ImageFile in FilesArray)
            {

                try
                {

                    ImageFileName = ImageFile.ToString();
                    ImageFileName = ImageFileName.Substring(ImageFileName.LastIndexOf("\\") + 1);
                    ImageFileLocation = AppUrl;
                    ImageFileLocation = ImageFileLocation.Substring(ImageFileLocation.LastIndexOf("\\") + 1);
                    //galleryfilelocation += "/";
                    ImageFileLocation += CurrentImagesFolder.Value;
                    ImageFileLocation += "/";
                    ImageFileLocation += ImageFileName;
                    System.Web.UI.HtmlControls.HtmlImage myHtmlImage = new System.Web.UI.HtmlControls.HtmlImage();
                    myHtmlImage.Src = ImageFileLocation;
                    System.Drawing.Image myImage = System.Drawing.Image.FromFile(ImageFile.ToString());
                    myHtmlImage.Attributes["unselectable"] = "on";
                    //myHtmlImage.border=0;

                    // landscape image
                    if (myImage.Width > myImage.Height)
                    {
                        if (myImage.Width > thumbWidth)
                        {
                            myHtmlImage.Width = thumbWidth;
                            myHtmlImage.Height = Convert.ToInt32(myImage.Height * thumbWidth / myImage.Width);
                        }
                        else
                        {
                            myHtmlImage.Width = myImage.Width;
                            myHtmlImage.Height = myImage.Height;
                        }
                        // portrait image
                    }
                    else
                    {
                        if (myImage.Height > thumbHeight)
                        {
                            myHtmlImage.Height = thumbHeight;
                            myHtmlImage.Width = Convert.ToInt32(myImage.Width * thumbHeight / myImage.Height);
                        }
                        else
                        {
                            myHtmlImage.Width = myImage.Width;
                            myHtmlImage.Height = myImage.Height;
                        }
                    }

                    if (myHtmlImage.Height < thumbHeight)
                    {
                        myHtmlImage.Attributes["vspace"] = Convert.ToInt32((thumbHeight / 2) - (myHtmlImage.Height / 2)).ToString();
                    }


                    System.Web.UI.WebControls.Panel myImageHolder = new System.Web.UI.WebControls.Panel();
                    myImageHolder.CssClass = "imageholder";
                    myImageHolder.Attributes["onclick"] = "divClick(this,'" + ImageFileName + "');";
                    myImageHolder.Attributes["ondblclick"] = "returnImage('" + ImageFileLocation.Replace(AppUrl, "/").Replace("\\", "/") + "','" + textid + "');";
                    myImageHolder.Controls.Add(myHtmlImage);


                    System.Web.UI.WebControls.Panel myMainHolder = new System.Web.UI.WebControls.Panel();
                    myMainHolder.CssClass = "imagespacer";
                    myMainHolder.Controls.Add(myImageHolder);

                    System.Web.UI.WebControls.Panel myTitleHolder = new System.Web.UI.WebControls.Panel();
                    myTitleHolder.CssClass = "titleHolder";
                    myTitleHolder.Controls.Add(new LiteralControl(ImageFileName + "<BR>" + myImage.Width.ToString() + "x" + myImage.Height.ToString()));
                    myMainHolder.Controls.Add(myTitleHolder);
                    GalleryPanel.Controls.Add(myMainHolder);

                    myImage.Dispose();
                }
                catch
                {

                }
            }
            gallerymessage.Text = "";

        }

   
    }
}