using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session != null)
        {
            Session.Clear();
        }
    }

    protected void login(object sender, EventArgs e)
    {
        String user  ;
        String pass;
        user = username.Text;
        pass = password.Text;
        if (user == "usama" && pass == "able900")
        {
            Session["user"] = user;
            String redirect = "Display.aspx";
            Page.Response.Redirect(redirect);
        }
    }
}