using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BoekReis : System.Web.UI.Page
{
    private DataTable tempTrein;
    private DataTable tempRit;
    private DataTable tempClass;
    private DateTime vertrekDate;
    private DateTime aankomstDate;
    private int atlPersonen;


    protected void Page_Load(object sender, EventArgs e)
    {
        //controle dat gebruiker komt via Trein.aspx
        if (Session["VPR_trace"] == null)
        {
            Response.Redirect("Trein.aspx");
        }

        
        
        Label1.Text = (String)Session["VPR_reis"];
        if (!Page.IsPostBack)
        {
            DateTime d = DateTime.Today;
            d = d.AddDays(1);
            for (int i = 0; i < 14; i++)
            {
                drpDagen.Items.Add(d.ToString("dddd dd MMMM yyyy"));
                d = d.AddDays(1);
            }


            drpUur.Items.Add("08:00:00");
            drpUur.Items.Add("12:00:00");
            drpUur.Items.Add("16:00:00");
            drpUur.Items.Add("20:00:00");

            tempClass = new ClassAccess().getAllClass();
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
        vertrekDate = DateTime.Parse(drpDagen.SelectedItem.ToString()); ;
        aankomstDate = vertrekDate;

        String[] overstap = fullTraject.Rows[0].ItemArray[4].ToString().Split(';');

        tempRit = new DataTable();
        TimeSpan vertrektijd = TimeSpan.Parse(drpUur.SelectedItem.ToString());
        int j = 1;


        // indien geen overstap
        if (overstap[0].Equals(""))
        {
            tempTrein = tracc.getTrainsFromTo(start, eind);
            tempRit = rtacc.getRit(Convert.ToInt32(tempTrein.Rows[0].ItemArray[0]), Hulp.dayOfWeek(vertrekDate), vertrektijd);
            vertrektijd += TimeSpan.Parse(tempTrein.Rows[0].ItemArray[5].ToString());
        }
        else
        {
            //Met overstappen 
            //
            //eerste rit
            int stop = Convert.ToInt32(overstap[0]);
            tempTrein = tracc.getTrainsFromTo(start, stop);
            tempRit = rtacc.getRit(Convert.ToInt32(tempTrein.Rows[0].ItemArray[0]), Hulp.dayOfWeek(vertrekDate), vertrektijd);
            vertrektijd = dichtsteUur(vertrektijd.Add(TimeSpan.Parse(tempTrein.Rows[0].ItemArray[5].ToString())));

            // controle op meerdere overstappen
            if (overstap.Count<String>() >= 2)
            {
                for (int i = 1; i <= overstap.Count<String>() - 1; i++)
                {
                    int stop2 = Convert.ToInt32(overstap[i]);
                    tempTrein.Merge(tracc.getTrainsFromTo(stop, stop2));
                    tempRit.Merge(rtacc.getRit(Convert.ToInt32(tempTrein.Rows[j].ItemArray[0]), Hulp.dayOfWeek(vertrekDate), vertrektijd));
                    stop = stop2;
                    vertrektijd = dichtsteUur(vertrektijd.Add(TimeSpan.Parse(tempTrein.Rows[j].ItemArray[5].ToString())));
                    j++;
                }
            }

            //eind traject
            tempTrein.Merge(tracc.getTrainsFromTo(stop, eind));
            tempRit.Merge(rtacc.getRit(Convert.ToInt32(tempTrein.Rows[j].ItemArray[0]), Hulp.dayOfWeek(vertrekDate), vertrektijd));
        }


        grdRitten.Visible = true;
        grdRitten.DataSource = tempRit;
        grdRitten.DataBind();
        setGridBestemming();
        atlTickets.Visible = true;

        Session["VPR_grdRit"] = grdRitten.DataSource;
        Session["VPR_tempTrein"] = tempTrein;
        Session["VPR_tempRit"] = tempRit;
        


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
            Session["VPR_grdRitten"] = grdRitten;
        }
    }

    protected void drpPersonen_SelectedIndexChanged(object sender, EventArgs e)
    {
        //aantal velden weergeven voor persoon namen
        if (drpPersonen.SelectedIndex != 0)
        {
            atlPersonen = Convert.ToInt32(drpPersonen.SelectedValue);
            Session["VPR_atlPersonen"] = atlPersonen;

            p1.Visible = false;
            val11.Enabled = false;
            val12.Enabled = false;

            p2.Visible = false;
            val21.Enabled = false;
            val22.Enabled = false;

            p3.Visible = false;
            val31.Enabled = false;
            val32.Enabled = false;

            p4.Visible = false; 
            val41.Enabled = false;
            val42.Enabled = false;

            p5.Visible = false;
            val51.Enabled = false;
            val52.Enabled = false;

            p6.Visible = false;
            val61.Enabled = false;
            val62.Enabled = false;

            p7.Visible = false;
            val71.Enabled = false;
            val72.Enabled = false;

            p8.Visible = false;
            val81.Enabled = false;
            val82.Enabled = false;

            p9.Visible = false;
            val91.Enabled = false;
            val92.Enabled = false;

            p10.Visible = false;
            val101.Enabled = false;
            val102.Enabled = false;


            for (int i = 0; i < atlPersonen; i++)
            {
                switch (i)
                {
                    case 0: 
                        p1.Visible = true; 
                        val11.Enabled = true;
                        val12.Enabled = true;
                        break;
                    case 1: 
                        p2.Visible = true;
                        val21.Enabled = true;
                        val22.Enabled = true;
                        break;
                    case 2:
                        p3.Visible = true; 
                        val31.Enabled = true;
                        val32.Enabled = true;
                        break;
                    case 3:
                        p4.Visible = true; 
                        val41.Enabled = true;
                        val42.Enabled = true;
                        break;
                    case 4: 
                        p5.Visible = true; 
                        val51.Enabled = true;
                        val52.Enabled = true;
                        break;
                    case 5: 
                        p6.Visible = true; 
                        val61.Enabled = true;
                        val62.Enabled = true;
                        break;
                    case 6: 
                        p7.Visible = true;
                        val71.Enabled = true;
                        val72.Enabled = true;
                        break;
                    case 7:
                        p8.Visible = true; 
                        val81.Enabled = true;
                        val82.Enabled = true;
                        break;
                    case 8:
                        p9.Visible = true; 
                        val91.Enabled = true;
                        val92.Enabled = true;
                        break;
                    case 9: 
                        p10.Visible = true; 
                        val101.Enabled = true;
                        val102.Enabled = true;
                        break;
                }
            }
            btnMand.Visible = true;
        }
        else
        {
            p1.Visible = false;
            p2.Visible = false;
            p3.Visible = false;
            p4.Visible = false;
            p5.Visible = false;
            p6.Visible = false;
            p7.Visible = false;
            p8.Visible = false;
            p9.Visible = false;
            p10.Visible = false;
            btnMand.Visible = false;
        }


    }

    private Boolean CheckIfPlaats()
    {
       //kijken of er nog genoeg plaats is op de trein
        foreach (DataRow r in tempRit.Rows)
        {
            DataTable capa = new CapaciteitAccess().getCapa(DateTime.Parse(grdRitten.Rows[0].Cells[0].Text), Convert.ToInt32(r.ItemArray[0].ToString()));

            if (capa.Rows.Count != 0)
            {
                int atlPlaatsen = Convert.ToInt32(capa.Rows[0].ItemArray[0].ToString());

                if (atlPlaatsen - atlPersonen < 0)
                {
                    return false;
                }
            }
        }
        return true;
    }

    protected void btnMand_Click(object sender, EventArgs e)
    {
        
        tempTrein = (DataTable)Session["VPR_tempTrein"];
        tempRit = (DataTable)Session["VPR_tempRit"];
        atlPersonen = (int)Session["VPR_atlPersonen"];

        Boolean ok = CheckIfPlaats();

        if (ok)
        {

            // bestelling in sessie plaatsen
            DataTable bestelling = new DataTable();

            if (Session["VPR_bestelling"] == null) // schoppingcart
            {
                bestelling.Columns.Add("gebruikerID");
                bestelling.Columns.Add("totalePrijs");
                bestelling.Columns.Add("aankomstdatum");
                bestelling.Columns.Add("vertrekDatum");
                bestelling.Columns.Add("typeID");
                bestelling.Columns.Add("treinID");
                bestelling.Columns.Add("vertrekplaats");
                bestelling.Columns.Add("aankomstplaats");
            }
            else
            {
                bestelling = (DataTable)Session["VPR_bestelling"];
            }

            DataRow r = bestelling.NewRow();
            r[0] = Session["VPR_id"];
            r[1] = berekenPrijs();
            DateTime vertrek = DateTime.Parse(grdRitten.Rows[0].Cells[0].Text);
            DateTime aankomst = DateTime.Parse(grdRitten.Rows[grdRitten.Rows.Count - 1].Cells[1].Text);

            r[3] = vertrek;
            r[2] = aankomst;
            r[4] = drpClass.SelectedValue;
            r[5] = Session["VPR_reis"];
            r[6] = grdRitten.Rows[0].Cells[2].Text;
            r[7] = grdRitten.Rows[grdRitten.Rows.Count - 1].Cells[3].Text;


            bestelling.Rows.Add(r);
            Session["VPR_bestelling"] = bestelling;

            // personen in sesie plaatsen
            DataTable personen = new DataTable();

            if (Session["VPR_personen"] == null) // schoppingcart
            {
                personen.Columns.Add("rijTicket");
                personen.Columns.Add("voornaam");
                personen.Columns.Add("naam");
                personen.Columns.Add("stoelnr");
            }
            else
            {
                personen = (DataTable)Session["VPR_personen"];
            }

            for (int i = 1; i <= atlPersonen; i++)
            {
                DataRow rp = personen.NewRow();
                rp[0] = bestelling.Rows.Count - 1;


                switch (i)
                {
                    case 1: rp[1] = txtvrnaam1.Text;
                        rp[2] = txtnaam1.Text; break;
                    case 2: rp[1] = txtvrnaam2.Text;
                        rp[2] = txtnaam2.Text; break;
                    case 3: rp[1] = txtvrnaam3.Text;
                        rp[2] = txtnaam3.Text; break;
                    case 4: rp[1] = txtvrnaam4.Text;
                        rp[2] = txtnaam4.Text; break;
                    case 5: rp[1] = txtvrnaam5.Text;
                        rp[2] = txtnaam5.Text; break;
                    case 6: rp[1] = txtvrnaam6.Text;
                        rp[2] = txtnaam6.Text; break;
                    case 7: rp[1] = txtvrnaam7.Text;
                        rp[2] = txtnaam7.Text; break;
                    case 8: rp[1] = txtvrnaam8.Text;
                        rp[2] = txtnaam8.Text; break;
                    case 9: rp[1] = txtvrnaam9.Text;
                        rp[2] = txtnaam9.Text; break;
                    case 10: rp[1] = txtvrnaam10.Text;
                        rp[2] = txtnaam10.Text; break;
                }

                int[] stoelnummers = getEersteVrijeStoel();
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < stoelnummers.Count<int>(); j++)
                {
                    sb.Append(stoelnummers[j] + ";");
                    stoelnummers[j]++;
                }

                rp[3] = sb.ToString();
                personen.Rows.Add(rp);
            }
            Session["VPR_personen"] = personen;
            Response.Redirect("winkelkarretje.aspx");
        }
        else
        {
            lblerror.Text = "Er niet genoeg plaats meer gelieve een vroegere of latere reis te kiezen";
        }
    }

    private int[] getEersteVrijeStoel()
    {
        int[] stoelen = new int[tempRit.Rows.Count];
        for(int i = 0; i < tempRit.Rows.Count; i++)
        {
            DateTime datum = DateTime.Parse(grdRitten.Rows[i].Cells[0].Text);
            DataTable d = new CapaciteitAccess().getCapa(datum,Convert.ToInt32(tempRit.Rows[i].ItemArray[0].ToString()));
            if (d.Rows.Count != 0)
            {
                //capaciteit van de rit - de nog vrije aantal plaatsen
                stoelen[i] = Convert.ToInt32(new RitAccess().getRitCapaciteit(Convert.ToInt32(tempRit.Rows[i].ItemArray[0].ToString()))) - Convert.ToInt32(d.Rows[0].ItemArray[0].ToString());
                stoelen[i] += i;
            }
            else
            {
                stoelen[i] = 1+i;
            }
        }

        return stoelen;
    }

    private double berekenPrijs()
    {
        double prijs = 0;
        double tarief = 0;
        tempClass = new ClassAccess().getAllClass();

        foreach (DataRow r in tempTrein.Rows)
        {
            tarief += Convert.ToDouble(r.ItemArray[3].ToString());
        }
        double verhouding = Convert.ToDouble(tempClass.Rows[drpClass.SelectedIndex].ItemArray[3]);

        prijs = tarief * verhouding/100 * atlPersonen;
        return prijs;
    }

}