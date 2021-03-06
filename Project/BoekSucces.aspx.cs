﻿using System;
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
        SiteMapPath pad = (SiteMapPath)Master.FindControl("SiteMapPath1");
        pad.Visible = false;
        
        
        lblReis.Text = (String)Session["VPR_vertrek/aankomst"];
        grdRitten.DataSource = (DataTable)Session["VPR_grdRit"];
        grdRitten.DataBind();
        setGridBestemming();
        grdPersonen.DataSource = (DataTable)Session["VPR_personen"];
        grdPersonen.DataBind();

        clearBestelling();
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

    private void setGridBestemming()
    {
        Dictionary<int, PlaatsData> plaatsData = Hulp.getBestemmingData();

        for (int r = 0; r < grdRitten.Rows.Count; r++)
        {
            for (int i = 1; i < 3; i++)
            {
                int id = Int32.Parse(grdRitten.Rows[r].Cells[i].Text);
                grdRitten.Rows[r].Cells[i].Text = plaatsData[id].naam;

            }
        }
    }
}