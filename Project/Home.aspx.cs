using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Home - VPRtravel";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Mail.sendMail("test", "anthony.vanparijs@gmail.com", "Anthony");
    }
}