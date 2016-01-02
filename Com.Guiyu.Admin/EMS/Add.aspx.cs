using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Com.Vinehoo.Models.Ship;
using Com.Vinehoo.Core.Tool;
using Com.Vinehoo.Core.Config;

public partial class EMS_Add : BasePage_CMS
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            { //编辑
                BindInfo();
            }
        }
    }

    private void BindInfo()
    {
        string id = Request.QueryString["ID"].ToString();
        ShipExpress model = KWebApiHelper<ShipExpress>.Get(KApiUrlConfig.ShipApiUrl, "Express/get/"+id);
        if (model != null)
        {
            SetValue(model);
        }
    }

    protected void lbtnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            ShipExpress model = null;
            if (string.IsNullOrEmpty(Request.QueryString["ID"]))
            {//新增
                model = new ShipExpress();
                GetValue(model);
            //    BLLExpress.Add(model);
                KWebApiHelper<ShipExpress>.Post<ShipExpress>(KApiUrlConfig.ShipApiUrl, "Express/add", model);
            }
            else
            {//修改
                model = KWebApiHelper<ShipExpress>.Get(KApiUrlConfig.ShipApiUrl, "Express/get/" + Request.QueryString["ID"].ToString());
                GetValue(model);
                KWebApiHelper<bool>.Post<ShipExpress>(KApiUrlConfig.ShipApiUrl, "Express/edit", model);
            }
            ClientScript.RegisterStartupScript(this.GetType(), "success", "alert('操作成功！');parent.close1(true);", true);
        }
        catch (Exception ex)
        {
            string message = "添加失败!" + ex.Message;
            ClientScript.RegisterStartupScript(this.GetType(), "failed", "alert('" + message + "');", true);
        }
    }

    private void GetValue(ShipExpress model)
    {
        model.ContactMan = txtContactMan.Text.Trim();
        model.Name = txtName.Text.Trim();
        model.Remarks = txtRemarks.Text.Trim();
        model.ContactType = txtContactType.Text.Trim();
    }

    private void SetValue(ShipExpress model)
    {
        txtContactMan.Text = model.ContactMan;
        txtContactType.Text = model.ContactType;
        txtName.Text = model.Name;
        txtRemarks.Text = model.Remarks;
    }
}