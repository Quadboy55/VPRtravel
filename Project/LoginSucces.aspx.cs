using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoginSucces : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Control pad = Master.FindControl("SiteMapPath1");
        pad.Visible = false;
    }
}