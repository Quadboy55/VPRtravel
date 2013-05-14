using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        lblReis.Text = (String)Session["VPR_vertrek/aankomst"];
        grdRitten.DataSource = (DataTable)Session["VPR_grdRit"];
        grdRitten.DataBind();

        grdPersonen.DataSource = (DataTable)Session["VPR_personen"];
        grdPersonen.DataBind();
    }

    private void clearBestelling()
    {
        Session["VPR_personen"] = null;
        Session["VPR_grdRitten"] = null;
        Session["VPR_tempRit"] = null;
        Session["VPR_bestelling"] = null;
        Session["VPR_grdRit"] = null;
        Session["VPR_vertrek/aankomst"] = null;
    }
}