using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class winkelkarretje : System.Web.UI.Page
{
    private DataTable bestelling;
    protected void Page_Load(object sender, EventArgs e)
    {
        bestelling = (DataTable)Session["VPR_bestelling"];
        grdReizen.DataSource = bestelling;
        grdReizen.DataBind();
    }
    protected void btnBevestig_Click(object sender, EventArgs e)
    {
        
    }
}