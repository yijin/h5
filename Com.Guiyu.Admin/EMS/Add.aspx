<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="EMS_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>    
    <link rel="stylesheet" type="text/css" href="/css/CMS/admin.css" />
    <link rel="stylesheet" type="text/css" href="/css/CMS/icon.css" />
	<script type="text/javascript" src="/js/CMS/jquery-1.6.min.js"></script>
	<script type="text/javascript" src="/js/CMS/jquery.easyui.min.js"></script>
    <script language="javascript" type="text/javascript">
        function valdiate() {
            if ($("#txtName").val() == "") {
                alert("名称必须填写");
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height:220px;border-bottom:1px solid #CCCCCC" class="overlfow">
    <table class="detail">
        <tr>
            <th style="width:150px">名称<span class="red">*</span></th>
            <td><asp:TextBox ID="txtName" runat="server" ></asp:TextBox></td>
        </tr>
        <tr>
            <th>联系人</th>
            <td><asp:TextBox ID="txtContactMan" runat="server" ></asp:TextBox></td>
        </tr>
        <tr>
            <th>联系方式</th>
            <td><asp:TextBox ID="txtContactType" runat="server" ></asp:TextBox></td>
        </tr>
        <tr>
            <th>备注</th>
            <td><asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Rows="5" ></asp:TextBox></td>
        </tr>
    </table>
    </div>
    <div class="btn-layout">
        <asp:LinkButton ID="lbtnSubmit" CssClass="easyui-linkbutton" iconCls="icon-ok" 
            runat="server" onclick="lbtnSubmit_Click" OnClientClick="return valdiate()" >提交</asp:LinkButton>
        <a href="#" class="easyui-linkbutton" iconCls="icon-cancel" onclick="parent.close1(false)" >取消</a>
    </div>
    </form>
</body>
</html>
