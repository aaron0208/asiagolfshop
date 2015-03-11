using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

public partial class detail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ID = "";
        try
        {
            ID = Context.Request.QueryString["id"].ToString();
            theme mytheme = new theme();
            headerTop.InnerHtml = mytheme.getHeadertop();
            headerBottom.InnerHtml = mytheme.getHeaderbottom();
            left_menu.InnerHtml = mytheme.getLeftMenu();
            StoreDB myStore = new StoreDB();
            sProduction myProduction = myStore.searchProductionbyID(ID);
            mainImg.InnerHtml = "<img class='img-responsive' src='./photos/production/" + myProduction.ProductionPhoto + "'  alt='' >";
            fullintroduction.InnerHtml = myProduction.FullIntro;
            Title.InnerHtml = myProduction.Name;
        }
        catch
        {
            
        }
        
    }
}
