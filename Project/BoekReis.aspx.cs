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

        ticketTraject = new DataTable();
        ticketTraject.Columns.Add("ID", typeof(int));
        ticketTraject.Columns.Add("vertrekID", typeof(int));
        ticketTraject.Columns.Add("aankomstID", typeof(int));
        ticketTraject.Columns.Add("capaciteit", typeof(int));
        ticketTraject.Columns.Add("prijs", typeof(int));
        ticketTraject.Columns.Add("duur", typeof(DateTime));
    }

    protected void txtDate_TextChanged(object sender, EventArgs e)
    {

    }
    protected void CalDatum_Disposed(object sender, EventArgs e)
    {

    }

    protected void txtDate_TextChanged1(object sender, EventArgs e)
    {
        RitAccess acc = new RitAccess();
        DataTable data = acc.getRittenTrein(Convert.ToInt32(Session["VPR_reis"]), Hulp.dayOfWeek(DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)));

        if (radList.SelectedValue.Equals("Vertrekken"))
        {
            drpUur.Items.Clear();
            drpUur.Items.Add("---Uur---");
            for (int i = 0; i < data.Rows.Count; i++)
            {
                drpUur.Items.Add(data.Rows[i].ItemArray[0].ToString());
            }
        }
    }
    protected void btnZoek_Click(object sender, EventArgs e)
    {
        TreinenAccess tracc = new TreinenAccess();
        DataTable fullTraject = tracc.getTrainById((int)Session["VPR_reis"]);

        int start =Convert.ToInt32(fullTraject.Rows[0].ItemArray[1].ToString());
        int eind =Convert.ToInt32(fullTraject.Rows[0].ItemArray[2].ToString());
        String[] overstap = fullTraject.Rows[0].ItemArray[5].ToString().Split(',');

        for(int i = 0; i < overstap.Count<String>(); i++)
        {
            DataTable temp;
            if(i == 0)
            {
                int stop = Convert.ToInt32(overstap[i]);
                temp = tracc.getTrainsFromTo(start,stop);
            }
            else
            {
                if(i == overstap.Count<String>()-1)
                {
                    int stop = Convert.ToInt32(overstap[i]);
                    temp = tracc.getTrainsFromTo(stop,eind);
                }
                else{
                    int stop1 = Convert.ToInt32(overstap[i-1]);
                    int stop2 = Convert.ToInt32(overstap[i]);
                    temp = tracc.getTrainsFromTo(stop1,stop2);
                }
            }

            addStuk(temp);

        }
        grdRitten.Visible = true;
        grdRitten.DataSource = ticketTraject;
        grdRitten.DataBind();
    }

    private void addStuk(DataTable d)
    {
        ticketTraject.Rows.Add(d.Rows[0].ItemArray[0], d.Rows[0].ItemArray[1], d.Rows[0].ItemArray[2], d.Rows[0].ItemArray[3], d.Rows[0].ItemArray[4], d.Rows[0].ItemArray[6]);
    }
    protected void drpUur_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpUur.SelectedIndex != 0)
        {
            btnZoek.Enabled = true;
        }
    }
}