using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class winkelkarretje : System.Web.UI.Page
{
    private DataTable bestelling;
    private DataTable klasse;
    private StringBuilder mail;

    protected void Page_Load(object sender, EventArgs e)
    {
        ((Master)Page.Master).checkLogon(true);

        setGrid();
 
        
    }
    protected void btnBevestig_Click(object sender, EventArgs e)
    {
        
        TicketAccess tktacc = new TicketAccess();
        PersoonAccess persacc = new PersoonAccess();
        CapaciteitAccess capacc = new CapaciteitAccess();
        GridView grdRitten = (GridView)Session["VPR_grdRitten"];
        DataTable rit = (DataTable)Session["VPR_tempRit"];

        mail = new StringBuilder();
        mail.Append("Beste "+ (String)Session["VPR_fullnaam"]+",");
        mail.AppendLine("<br/>");
        mail.AppendLine("<br/>");
        mail.Append("U heeft volgende reis bij VPRtravel geboekt:");
        mail.AppendLine("<br/>");
        
        // rij id in het sessionobject met de bestellingstabel
        int i = 0;
        foreach (DataRow r in bestelling.Rows)
        {
            //mail opstellen
            mail.Append(r.ItemArray[6].ToString() +" - "+r.ItemArray[7].ToString());
            mail.AppendLine("<br/>");
            
            TicketData t = new TicketData();
            t.gebruikerID = (int)Session["VPR_id"];
            t.totalePrijs = Convert.ToDouble(r.ItemArray[1].ToString());
            String s = r.ItemArray[2].ToString();
            t.aankomstdatum = DateTime.Parse(r.ItemArray[2].ToString());
            t.vertrekdatum = DateTime.Parse(r.ItemArray[3].ToString());
            t.typeID = Convert.ToInt32(r.ItemArray[4].ToString());
            t.treinID = Convert.ToInt32(r.ItemArray[5].ToString());

            tktacc.addTicket(t);
            int tID = Convert.ToInt32(tktacc.getTicket(t).Rows[0].ItemArray[0]);
            int tRowID = i;
            i++;

            DataTable pers = (DataTable)Session["VPR_personen"];
            
            //mail opstellen
            mail.Append("met volgende personen als reizigers:");
            mail.AppendLine("<br/>");

            foreach (DataRow pr in pers.Rows)
            {
                if(pr.ItemArray[0].ToString().Equals(tRowID.ToString()))
                {
                    PersoonData p = new PersoonData();
                    p.ticketID = tID;
                    p.voornaam = pr.ItemArray[1].ToString();
                    p.naam = pr.ItemArray[2].ToString();
                    p.stoelnr = pr.ItemArray[3].ToString();

                    persacc.addPersoon(p);

                    //mail opstellen
                    mail.Append(p.naam +" "+p.voornaam);
                    mail.AppendLine("<br/>");
                }
                
            }

            for (int j = 0; j < rit.Rows.Count; j++)
            {
                DateTime datum = DateTime.Parse(grdRitten.Rows[j].Cells[0].Text);
                DataTable d = new CapaciteitAccess().getCapa(datum, Convert.ToInt32(rit.Rows[j].ItemArray[0].ToString()));
                CapaciteitData c = new CapaciteitData();
                c.datum = datum;
                c.ritID = Convert.ToInt32(rit.Rows[j].ItemArray[0].ToString());
                double extraCapa= specialeDagen(datum, Convert.ToInt32(rit.Rows[j].ItemArray[1].ToString()));
                if (d.Rows.Count != 0)
                {
                    c.capaciteit = Convert.ToInt32((extraCapa*Convert.ToInt32(d.Rows[0].ItemArray[0].ToString())) - pers.Rows.Count);
                    capacc.updateCapa(c);
                }
                else
                {
                    DataTable ritTabel = new RitAccess().getRitById(Convert.ToInt32(rit.Rows[j].ItemArray[0].ToString()));
                    c.capaciteit = Convert.ToInt32((extraCapa*Convert.ToInt32(ritTabel.Rows[0].ItemArray[2].ToString()))  - pers.Rows.Count);
                    capacc.addCapa(c);
                }
            }
        }

            //mail opstellen
            mail.AppendLine("<br/>");
            mail.AppendLine("<br/>");
            mail.Append("Mvg");
            mail.AppendLine("<br/>");
            mail.Append("Het VPRtravel team");
            String emailAdress = new GebruikersAccess().getMailByID(Convert.ToInt32(Session["VPR_id"].ToString()));
            Mail.sendMail(mail.ToString(),emailAdress ,Session["VPR_fullnaam"].ToString());
            Response.Redirect("BoekSucces.aspx");
        
    }

    

    private double specialeDagen(DateTime d, int trein)
    {
        DataTable tr = new TreinenAccess().getTrainById(trein);
        DateTime kerst = new DateTime(new GregorianCalendar().GetYear(d), 12 , 25 );
        DateTime paas = new DateTime(new GregorianCalendar().GetYear(d), 4, 7);

        TimeSpan nuKerst = kerst - d;
        TimeSpan nuPaas = d - paas;
        if (nuKerst.Days <= 31 && nuKerst.Days >= 0)
        {
            int aankomstID = Convert.ToInt32(tr.Rows[0].ItemArray[2].ToString());
            if (aankomstID == 2 || aankomstID == 3)
            {
                return 1.3;
            }

        }
        else
        {
            if (nuPaas.Days <= 14 && nuKerst.Days >= 0)
            {
                int aankomstID = Convert.ToInt32(tr.Rows[0].ItemArray[2].ToString());
                if (aankomstID == 1 || aankomstID == 3 || aankomstID == 4)
                {
                    return 1.3;
                }

            }
        }
        return 1;

    }

    protected void grdReizen_SelectedIndexChanged(object sender, EventArgs e)
    {
        bestelling = (DataTable)Session["VPR_bestelling"];
        bestelling.Rows[grdReizen.SelectedRow.RowIndex].Delete();

        DataTable p = (DataTable)Session["VPR_personen"];

        for(int i = 0; i < p.Rows.Count;i++)
        {
            if (Convert.ToInt32(p.Rows[i].ItemArray[0]) == grdReizen.SelectedRow.RowIndex)
            {
                p.Rows.RemoveAt(i);
                i--;
            }
        }


        if (bestelling.Rows.Count == 0)
        {
            Session["VPR_bestelling"] = null;
        }
        else
        {
            Session["VPR_bestelling"] = bestelling;
        }
        setGrid();
        
    }

    private void setGrid()
    {
        if (Session["VPR_bestelling"] == null)
        {
            lblLeeg.Text = "Uw winkelkarretje is leeg";
            lblLeeg.Visible = true;
            grdReizen.Visible = false;
        }
        else
        {
            bestelling = (DataTable)Session["VPR_bestelling"];
            grdReizen.DataSource = bestelling;
            grdReizen.DataBind();

            klasse = new ClassAccess().getAllClass();
            foreach (TableRow r in grdReizen.Rows)
            {
                int id = Convert.ToInt32(r.Cells[4].Text);
                r.Cells[4].Text = klasse.Rows[id - 1].ItemArray[1].ToString();
            }
        }
    }
    protected void btnBoekNog_Click(object sender, EventArgs e)
    {
        Response.Redirect("Trein.aspx");
    }
}