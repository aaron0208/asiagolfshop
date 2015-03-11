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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        theme mytheme = new theme();
        headerTop.InnerHtml = mytheme.getHeadertop();
        headerBottom.InnerHtml = mytheme.getHeaderbottom();
        left_menu.InnerHtml = mytheme.getLeftMenu();
        StoreDB myStore = new StoreDB();
        List<sProduction> myProduction = myStore.searchProduction(9);
        string innerString = "";
        foreach (sProduction production in myProduction)
        {
            innerString += "<div class='col-sm-4 col-lg-4 col-md-4' onclick='goDetail(" + production.ID + ")'>" +
                        "<div class='thumbnail'>" +
                            "<img src='./photos/production/" + production.ProductionPhoto + "' alt=''>" +
                            "<div class='caption'>" +
                                "<p><h4>" + "<a href='./detail.aspx?id=" + production.ID + "'>" + production.Name + "</a></p>" +
                                "<h4 class='pull-right'>$" + production.Price + "</h4>" +

                                "</h4>" +
                                "<p>" + production.Introduction + "</p>" +
                            "</div>" +
                        "</div>" +
                    "</div>";
        }
        ProductionDiv.InnerHtml = innerString;
    }
}
