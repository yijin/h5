
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Image.aspx.cs" Inherits="Com.Guiyu.Admin.Views.Upload.Image" %>


<asp:panel id="MainPage" runat="server" visible="false">
<!doctype html public "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
<HEAD>
 <link rel="stylesheet" type="text/css" href="/css/CMS/themes/default/easyui.css" />
<script type="text/javascript" src="/js/CMS/jquery-1.6.min.js"></script>
	<script type="text/javascript" src="/js/CMS/jquery.easyui.min.js"></script>
<META HTTP-EQUIV="Expires" CONTENT="0">
<title>插入图片</title>
<style>

body {
	margin: 0px 0px 0px 0px;
	padding: 0px 0px 0px 0px;
	background: #ffffff; 
	width: 100%;
	overflow:hidden;
	border: 0;
}

body,tr,td {
	color: #000000;
	font-family: Verdana, Arial, Helvetica, sans-serif;
	font-size: 10pt;
}

div.imagespacer {
	width: 120;
	height: 126;
	text-align: center;			
	float: left;
	font: 10pt verdana;
	margin: 5px;
	overflow: hidden;
}
div.imageholder {
	margin: 0px;
	padding: 0px;
	border: 1 solid #CCCCCC;
	width: 100;
	height: 100;
}

div.titleholder {
	font-family: ms sans serif, arial;
	font-size: 8pt;
	width: 100;
	text-overflow: ellipsis;
	overflow: hidden;
	white-space: nowrap;			
}		

</style>


<script language="javascript">
    lastDiv = null;
    function divClick(theDiv, filename) {
        if (lastDiv) {
            lastDiv.style.border = "1 solid #CCCCCC";
        }
        lastDiv = theDiv;
        theDiv.style.border = "2 solid #316AC5";

        document.getElementById("FileToDelete").value = filename;


    }
    function back(fdir, textid) {
        window.location = "/upload/image?url=" + fdir + "&textid=" + textid;
    }
    function gotoFolder(rootfolder, newfolder, textid) {

        window.location = "/upload/image?frame=1&rif=" + rootfolder + "&cif=" + newfolder + "&textid=" + textid;
        //  window.navigate("imagegallery.aspx?frame=1&rif=" + rootfolder + "&cif=" + newfolder);
    }
    function returnImage(imagename, textid) {


        var par = parent;

        while (par.location.href.indexOf("/upload/image") > -1) {
            par = par.parent;
        }
        par.closeImg("/upload" + imagename, textid);

    }

    function btnsubmit(action)
    {
      
        $("#hfaction").val(action);
        $("#form1").submit();
    }
 
   
</script>		
</HEAD>
<body>
<form encType="multipart/form-data" runat="server" id="form1">
<table width=100% height=100% cellpadding=0 cellspacing=0 border=0>



<tr><td>
	<div id="galleryarea" style="width=100%; height:100%; overflow: auto;">
		<asp:label id="gallerymessage" runat="server"></asp:label>
		<asp:panel id="GalleryPanel" runat="server"></asp:panel>
	</div>
</td></tr>
<asp:Panel id="UploadPanel" runat="server">
<tr><td height=16 style="padding-left:10px;border-top: 1 solid #999999; background-color:#99ccff;">
	
	<table>
	<tr>
		<td valign=top><input id="UploadFile" type="file" name="UploadFile" runat="server" style="width:300;"/></td>
		<td valign=top>
           
            <input type="button" onclick="javascript:btnsubmit('upload')" value="上传"  id="btnsumit" />

		</td>
		<td valign=top>
            <input  type="button"   onclick="javascript:btnsubmit('del')" id="btndel"  value="删除"  /></td>
		
	</tr>
	<tr>
		<td colspan=3>
			<asp:RegularExpressionValidator runat="server" 
				ControlToValidate="UploadFile" 
				id="FileValidator" display="dynamic"/>
			<asp:literal id="ResultsMessage" runat="server" />		
		</td>		
	</tr></table>	
	<input type="hidden" id="FileToDelete" Value="" name="FileToDelete" runat="server" />
	<input type="hidden" id="RootImagesFolder" Value="images" name="RootImagesFolder" runat="server" />
	<input type="hidden" id="CurrentImagesFolder" name="CurrentImagesFolder" Value="images" runat="server" />
	<input type="hidden" id="hfTextId" Value="images" name="hfTextId" runat="server" />

    <input type="hidden"  Value="" id="hfaction" name="action" runat="server" />
</td></tr>
</asp:panel>

</table>
    </form>
</body>
</HTML>
</asp:panel>
<asp:panel id="iframePanel" runat="server" >
<html> 
<head><title>插入图片</title></head>
<style>
body {
	margin: 0px 0px 0px 0px;
	padding: 0px 0px 0px 0px;
	background: #ffffff;
	overflow:hidden;
}
</style>
<body>
	<iframe style="width:100%;height:100%;border:0;" border=0 frameborder=0 src="/upload/image?frame=1&<%=HttpContext.Current.Request.QueryString%>"></iframe>
</body>
</html>
</asp:panel>


