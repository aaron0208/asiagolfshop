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
using System.Web.UI.MobileControls;
using System.Collections.Generic;

public partial class manage_store : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!HttpContext.Current.User.Identity.IsAuthenticated || !HttpContext.Current.User.IsInRole("admin"))
        {
            Response.Redirect("../Default.aspx?isauth=" + HttpContext.Current.User.Identity.IsAuthenticated.ToString()+
                "&role=" + HttpContext.Current.User.IsInRole("admin").ToString());
        }
        StoreDB myStore = new StoreDB();
        List<sProductionCategory> lProduction = myStore.searchProductionCategory();
        string innerHtml = "<table class='table table-striped table-bordered'><tr><th>分類名稱</th><th>功能</th></tr>";
        foreach (sProductionCategory myPorduct in lProduction)
        {
            innerHtml += "<tr id='pro_" + myPorduct.ID + "'>" +
                "<td>" + myPorduct.CategoryName + "</td>" +
                "<td>" + 
                    "<button href=':deleteCategory(" + myPorduct.ID + ")'>刪除</button>" +
                    "<button href='moveUp()'>往上移動</button>" +
                    "<button href='moveDown()'>往下移動</button>" +
                "</td>" +
                "</tr>";
            Production_Category.Items.Add(new ListItem( myPorduct.CategoryName,myPorduct.ID.ToString()));      
        }
        innerHtml += "</table>";
        tableProductCategory.InnerHtml = innerHtml;
    }
}
