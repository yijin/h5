using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Com.Vinehoo.Models.Ship;
using Com.Vinehoo.Core.Tool;
using Com.Vinehoo.Core.Config;

public partial class EMS_List : BasePage_CMS
{
  //  private BLLExpress bll = new BLLExpress();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindInfo();
        }
    }
    protected void BindInfo()
    {
        List<ShipExpress> expressList = KWebApiHelper<List<ShipExpress>>.Get(KApiUrlConfig.ShipApiUrl, "express/list");
        this.rpList.DataSource = expressList;
        this.rpList.DataBind();
  
    }

    protected void Pager_PageChanged(object sender, EventArgs e)
    {
        BindInfo();
    }

    protected void lbtnRefresh_Click(object sender, EventArgs e)
    {
        BindInfo();
    }

 
}