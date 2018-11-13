using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoggedIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String name = (String)Session["UserName"];
        userLabel.Text = name;
    }
    
    protected void logoutEventHandler(object sender, EventArgs e)
    {
        Session["UserName"] = null;
        Session.Abandon();
        Response.BufferOutput = true;
        Response.Redirect("Default.aspx", false);
    }
}