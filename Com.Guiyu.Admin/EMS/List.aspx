<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List.aspx.cs" Inherits="EMS_List" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>    
    <link rel="stylesheet" type="text/css" href="/css/CMS/admin.css" />
    <link rel="stylesheet" type="text/css" href="/css/CMS/icon.css" />
	<script type="text/javascript" src="/js/CMS/jquery-1.6.min.js"></script>
	<script type="text/javascript" src="/js/CMS/jquery.easyui.min.js"></script>
	<script type="text/javascript" language="javascript">

	    function open1(id) {
	        var url = "add.aspx?id=" + id;
	        var str = "<iframe  frameborder='0' src='" + url + "' style='width:100%;height:100%'></iframe>";
	        $("#add").children().children().empty();
	        $("#add").children().children().append(str);
	        $("#add").dialog("open");
	    }

	    function close1(refresh) {
	        $("#add").dialog("close");
	        if (refresh) {
	            __doPostBack('lbtnRefresh', '');
	        }
	    }

	</script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="panel-header">
            <div class="panel-title">
                <asp:Label ID="lblTitle" runat="server" />
            </div>
        </div>
        <div class="panel-body">
        <div class="panel-toolbar">
            <div style="float:left">
            <a href="javascript:void(0)" onclick="open1('')" class="easyui-linkbutton" plain="true" iconCls="icon-add">新建</a>
            <asp:LinkButton ID="lbtnRefresh" runat="server" onclick="lbtnRefresh_Click" CssClass="easyui-linkbutton" plain="true" iconCls="icon-reload">刷新</asp:LinkButton>
            </div>            
            <div style="clear:both"></div>
        </div>
        <asp:Repeater ID="rpList" runat="server" >
        <HeaderTemplate>
            <table>
                <tr class="datagrid-header">
                    <td style="width:25px">序号</td>
                    <td style="width:150px">名称</td>
                    <td style="width:150px">联系人</td>
                    <td style="width:150px">联系方式</td>
                    <td >备注</td>
                    <td style="width:120px">操作</td>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
               <tr class="datagrid-body">
                    <td style="text-align:center"><%# Container.ItemIndex + 1 %></td>
                    <td><%# Eval("Name")%></td>
                    <td><%# Eval("ContactMan")%></td>
                    <td ><%# Eval("ContactType")%></td>
                    <td><%# Eval("Remarks") %></td>
                    <td style="text-align:center">
                        <a href="#" onclick=open1('<%# Eval("ID") %>'); class="easyui-linkbutton" plain="true" iconCls="icon-edit">编辑</a>
                        <asp:LinkButton ID="lbtnDelete" OnClientClick="return confirm('确定要删除？');" CommandName="Delete" CommandArgument='<%# Eval("ID") %>' CssClass="easyui-linkbutton" plain="true" iconCls="icon-cancel" runat="server">删除</asp:LinkButton>
                    </td>
               </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
        </asp:Repeater>        
        <div class="pager">
        <webdiyer:aspnetpager id="Pager" runat="server" Width="100%" PageSize="15" 
                AlwaysShow="True" ShowCustomInfoSection="Left" 
                CustomInfoHTML="第 %currentPageIndex% 页，共 %PageCount% 页，每页 %PageSize% 条，共 %RecordCount% 条记录"
                FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" 
                CustomInfoTextAlign="Left" HorizontalAlign="Right" LayoutType="Table" onpagechanged="Pager_PageChanged"></webdiyer:aspnetpager>
        </div>
        </div>        
        <div id="add" title="编辑" icon="icon-save" class="easyui-dialog" closed="true" modal="true" style="width:500px;height:300px"></div>
    </form>
</body>
</html>



