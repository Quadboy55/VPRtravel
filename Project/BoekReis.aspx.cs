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
    DataTable tempTrein;
    DataTable tempRit;
    DataTable tempClass;
    DateTime vertrekDate;
    DateTime aankomstDate;


    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = (String)Session["VPR_reis"];
        if (!Page.IsPostBack)
        {
            drpUur.Items.Add("--Uur--");
            drpUur.Items.Add("08:00:00");
            drpUur.Items.Add("12:00:00");
            drpUur.Items.Add("16:00:00");
            drpUur.Items.Add("20:00:00");

           tempClass = new ClassAccess().getAllClass();
            drpClass.Items.Add("--Klasse--");
            foreach (DataRow r in tempClass.Rows)
            {
                drpClass.Items.Add(new ListItem(r.ItemArray[1].ToString(), r.ItemArray[0].ToString()));
            }
        }
    }


    protected void btnZoek_Click(object sender, EventArgs e)
    {
        TreinenAccess tracc = new TreinenAccess();
        RitAccess rtacc = new RitAccess();
        DataTable fullTraject = tracc.getTrainById(Convert.ToInt32(Session["VPR_reis"]));

        int start = Convert.ToInt32(fullTraject.Rows[0].ItemArray[1].ToString());
        int eind = Convert.ToInt32(fullTraject.Rows[0].ItemArray[2].ToString());
        vertrekDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        aankomstDate = vertrekDate;

        String[] overstap = fullTraject.Rows[0].ItemArray[4].ToString().Split(';');

        tempRit = new DataTable();
        TimeSpan vertrektijd = TimeSpan.Parse(drpUur.SelectedItem.ToString());
        int j = 1;


        // indien geen overstap
        if (overstap[0].Equals(""))
        {
            tempTrein = tracc.getTrainsFromTo(start, eind);
            tempRit = rtacc.getRit(Convert.ToInt32(tempTrein.Rows[0].ItemArray[0]), Hulp.dayOfWeek(DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)), vertrektijd);
            vertrektijd += TimeSpan.Parse(tempTrein.Rows[0].ItemArray[5].ToString());
        }
        else
        {
            //Met overstappen 
            //
            //eerste rit
            int stop = Convert.ToInt32(overstap[0]);
            tempTrein = tracc.getTrainsFromTo(start, stop);
            tempRit = rtacc.getRit(Convert.ToInt32(tempTrein.Rows[0].ItemArray[0]), Hulp.dayOfWeek(DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)), vertrektijd);
            vertrektijd = dichtsteUur(vertrektijd.Add(TimeSpan.Parse(tempTrein.Rows[0].ItemArray[5].ToString())));

            // controle op meerdere overstappen
            if (overstap.Count<String>() >= 2)
            {
                for (int i = 1; i <= overstap.Count<String>() - 1; i++)
                {
                    int stop2 = Convert.ToInt32(overstap[i]);
                    tempTrein.Merge(tracc.getTrainsFromTo(stop, stop2));
                    tempRit.Merge(rtacc.getRit(Convert.ToInt32(tempTrein.Rows[j].ItemArray[0]), Hulp.dayOfWeek(DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)), vertrektijd));
                    stop = stop2;
                    vertrektijd = dichtsteUur(vertrektijd.Add(TimeSpan.Parse(tempTrein.Rows[j].ItemArray[5].ToString())));
                    j++;
                }
            }

            //eind traject
            tempTrein.Merge(tracc.getTrainsFromTo(stop, eind));
            tempRit.Merge(rtacc.getRit(Convert.ToInt32(tempTrein.Rows[j].ItemArray[0]), Hulp.dayOfWeek(DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture)), vertrektijd));
        }


        grdRitten.Visible = true;
        grdRitten.DataSource = tempRit;
        grdRitten.DataBind();
        setGridBestemming();
        atlTickets.Visible = true;
    }

    protected void drpUur_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpUur.SelectedIndex != 0)
        {
            btnZoek.Enabled = true;
        }
    }

    // zoekt dichtst volgende vertrekuur
    private TimeSpan dichtsteUur(TimeSpan t)
    {
        TimeSpan t1 = new TimeSpan(0, 8, 0, 0);
        TimeSpan t2 = new TimeSpan(0, 12, 0, 0);
        TimeSpan t3 = new TimeSpan(0, 16, 0, 0);
        TimeSpan t4 = new TimeSpan(0, 20, 0, 0);

        if (TimeSpan.Compare(t, t4) == 1 || TimeSpan.Compare(t4, t) == 0)
        {
            return t1;
        }

        if (TimeSpan.Compare(t, t3) == 1 || TimeSpan.Compare(t3, t) == 0)
        {
            return t4;
        }

        if (TimeSpan.Compare(t, t2) == 1 || TimeSpan.Compare(t2, t) == 0)
        {
            return t3;
        }

        if (TimeSpan.Compare(t, t1) == 1 || TimeSpan.Compare(t1, t) == 0)
        {
            return t2;
        }
        return t1;

    }

    private void setGridBestemming()
    {
        Dictionary<int, PlaatsData> plaatsData = Hulp.getBestemmingData();

        int j = 0;
        TimeSpan temp = new TimeSpan(0, 20, 0, 0);
        TimeSpan v = new TimeSpan(0, 0, 0, 0);

        foreach (GridViewRow r in grdRitten.Rows)
        {
            
            for (int i = 0; i < 4; i++)
            {
                // van vertrekuur naar datum + vertrek uur
                if (i == 0)
                {
                    String s = r.Cells[i].ToString();
                    TimeSpan t = TimeSpan.Parse(r.Cells[i].Text);
                    if (TimeSpan.Compare(temp, v) == -1)
                    {
                        aankomstDate = aankomstDate.AddDays(1.00);
                    }

                    DateTime time = aankomstDate.AddMilliseconds(t.TotalMilliseconds);

                    r.Cells[i].Text = time.ToString("dd/MM/yyyy HH:mm");

                    v = t;
                }
                // van id naar plaatsnaam
                else
                {
                    if (i == 1)
                    {
                        TimeSpan t = v.Add(TimeSpan.Parse(tempTrein.Rows[j].ItemArray[5].ToString()));
                        if (TimeSpan.Compare(temp, v) == -1)
                        {
                            aankomstDate = aankomstDate.AddDays(1);
 
                        }

                        DateTime time = aankomstDate.AddMilliseconds(t.TotalMilliseconds);

                        r.Cells[i].Text = time.ToString("dd/MM/yyyy HH:mm");
                        j++;
                        v = t;
                    }
                    else
                    {
                        int id = Int32.Parse(r.Cells[i].Text);
                        r.Cells[i].Text = plaatsData[id].naam;
                    }
                }

                

            }
        }
    }
    protected void drpPersonen_SelectedIndexChanged(object sender, EventArgs e)
    {
        int atl = Convert.ToInt32(drpPersonen.SelectedValue);

        for (int i = 1; i <= atl; i++)
        {

            namen.Controls.Add(new LiteralControl("<strong>"));
            Label l = new Label();
            l.ID = "naam" + i;
            l.Text = "Naam " + i + " : ";
            namen.Controls.Add(new LiteralControl("</strong>"));

            TextBox t = new TextBox();
            t.ID = "txtnaam" + i;

            namen.Controls.Add(new LiteralControl("<strong>"));
            Label l2 = new Label();
            l.ID = "vrnaam" + i;
            l.Text = "Voornaam " + i + " : ";
            namen.Controls.Add(new LiteralControl("</strong>"));

            TextBox t2 = new TextBox();
            t.ID = "txtvrnaam" + i;

            RequiredFieldValidator val = new RequiredFieldValidator();
            val.ControlToValidate = t.ID;
            val.ValidationGroup = "namen";
            val.ErrorMessage = "Gelieve de naam op te geven";
            val.CssClass = "error";

            namen.Controls.Add(l);
            namen.Controls.Add(t);
            namen.Controls.Add(l2);
            namen.Controls.Add(t2);
            namen.Controls.Add(val);
            namen.Controls.Add(new LiteralControl("<br/>"));

        }
        btnMand.Visible = true;
    }
    protected void btnMand_Click(object sender, EventArgs e)
    {
        DataTable bestelling = new DataTable();

        if (Session["VPR_tickets"] == null) // schoppingcart
        {
            bestelling.Columns.Add("gebruikerID");
            bestelling.Columns.Add("totalePrijs");
            bestelling.Columns.Add("aankomstdatum");
            bestelling.Columns.Add("vertrekDatum");
            bestelling.Columns.Add("typeID");
            bestelling.Columns.Add("treinID");
        }
        else
        {
            bestelling = (DataTable)Session["VPR_bestelling"];
        }

        DataRow r = bestelling.NewRow();
        r[0] = Session["VPR_id"];
        r[1] = berekenPrijs();
        r[2] = DateTime.ParseExact(grdRitten.Rows[0].Cells[0].ToString(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
        r[3] = DateTime.ParseExact(grdRitten.Rows[grdRitten.Rows.Count-1].Cells[1].ToString(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
        r[4] = drpClass.SelectedValue;
        r[5] = Session["VPR_reis"];
    }

    //private double berekenPrijs()
    //{
    //    double prijs = 0;

    //    foreach (DataRow r in tempTrein.Rows)
    //    {
    //        double tarief = Convert.ToDouble(r.ItemArray[3].ToString());
    //    }
    //}
}