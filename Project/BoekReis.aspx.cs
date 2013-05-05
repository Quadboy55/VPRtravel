using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BoekReis : System.Web.UI.Page
{
    private DataTable ticketTraject;

    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = (String)Session["VPR_reis"];
        drpUur.Items.Add("--Uur--");
        drpUur.Items.Add("08:00:00");
        drpUur.Items.Add("12:00:00");
        drpUur.Items.Add("16:00:00");
        drpUur.Items.Add("20:00:00");
        ticketTraject = new DataTable();
    }


    protected void btnZoek_Click(object sender, EventArgs e)
    {
        TreinenAccess tracc = new TreinenAccess();
        RitAccess rtacc = new RitAccess();
        DataTable fullTraject = tracc.getTrainById(Convert.ToInt32(Session["VPR_reis"]));

        int start =Convert.ToInt32(fullTraject.Rows[0].ItemArray[1].ToString());
        int eind =Convert.ToInt32(fullTraject.Rows[0].ItemArray[2].ToString());
        String[] overstap = fullTraject.Rows[0].ItemArray[5].ToString().Split(';');

        DataTable tempTrein;
        DataTable tempRit = new DataTable();

        if (overstap[0].Equals(""))
        {
            tempTrein = tracc.getTrainsFromTo(start, eind);
            tempRit = rtacc.getRit(Convert.ToInt32(tempTrein.Rows[0].ItemArray[0]), Hulp.dayOfWeek(DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)), TimeSpan.Parse(drpUur.SelectedItem.ToString()));
        }
        else
        {
            int stop = Convert.ToInt32(overstap[0]);
            tempTrein = tracc.getTrainsFromTo(start, stop);
            tempRit = rtacc.getRit(Convert.ToInt32(tempTrein.Rows[0].ItemArray[0]), Hulp.dayOfWeek(DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)), TimeSpan.Parse(drpUur.SelectedItem.ToString()));

            if (overstap.Count<String>() >= 2)
            {
                for (int i = 1; i <= overstap.Count<String>()-1 ; i++)
                {
                    int stop2 = Convert.ToInt32(overstap[i]);
                    tempTrein = tracc.getTrainsFromTo(stop, stop2);
                    tempRit.Merge(rtacc.getRit(Convert.ToInt32(tempTrein.Rows[0].ItemArray[0]), Hulp.dayOfWeek(DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)), TimeSpan.Parse(drpUur.SelectedItem.ToString())));
                    stop = stop2;
                }
            }

            tempTrein = tracc.getTrainsFromTo(stop, eind);
            tempRit.Merge(rtacc.getRit(Convert.ToInt32(tempTrein.Rows[0].ItemArray[0]), Hulp.dayOfWeek(DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)), TimeSpan.Parse(drpUur.SelectedItem.ToString())));

        }

        ticketTraject = tempRit;










       
        grdRitten.Visible = true;
        grdRitten.DataSource = ticketTraject;
        grdRitten.DataBind();
    }

    protected void drpUur_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpUur.SelectedIndex != 0)
        {
            btnZoek.Enabled = true;
        }
    }
}