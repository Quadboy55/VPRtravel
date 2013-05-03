using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BoekReis : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = (String)Session["VPR_reis"];
    }
    protected void CalDatum_SelectionChanged(object sender, EventArgs e)
    {
        RitAccess acc = new RitAccess();
        DataTable data = acc.getRittenTrein((int)Session["VPR_reis"], Convert.ToInt32(DateTime.Today.DayOfWeek) + 1);

        if (radList.SelectedValue.Equals("Vertrekken"))
        {
            drpUur.Items.Add("--Uur---");
            for (int i = 0; i < data.Rows.Count; i++)
            {
                drpUur.Items.Add(data.Rows[i].ItemArray[0].ToString());
            }
        }
    }
}