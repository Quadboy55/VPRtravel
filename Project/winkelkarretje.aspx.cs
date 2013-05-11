using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class winkelkarretje : System.Web.UI.Page
{
    private DataTable bestelling;
    private DataTable klasse;

    protected void Page_Load(object sender, EventArgs e)
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
    protected void btnBevestig_Click(object sender, EventArgs e)
    {
        TicketAccess tktacc = new TicketAccess();
        PersoonAccess persacc = new PersoonAccess();
        CapaciteitAccess capacc = new CapaciteitAccess();
        GridView grdRitten = (GridView)Session["VPR_grdRitten"];
        DataTable rit = (DataTable)Session["VPR_tempRit"];

        // rij id in het sessionobject met de bestellingstabel
        int i = 0;
        foreach (DataRow r in bestelling.Rows)
        {
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
                }
                else
                {
                    break;
                }
            }




            for (int j = 0; j < rit.Rows.Count; j++)
            {
                DateTime datum = DateTime.ParseExact(grdRitten.Rows[j].Cells[0].Text, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                DataTable d = new CapaciteitAccess().getCapa(datum, Convert.ToInt32(rit.Rows[j].ItemArray[0].ToString()));
                CapaciteitData c = new CapaciteitData();
                c.datum = datum;
                c.ritID = Convert.ToInt32(rit.Rows[j].ItemArray[0].ToString());
                if (d.Rows.Count != 0)
                {
                    c.capaciteit = Convert.ToInt32(d.Rows[0].ItemArray[0].ToString())- pers.Rows.Count;
                    capacc.updateCapa(c);
                }
                else
                {
                    DataTable ritTabel = new RitAccess().getRitById(Convert.ToInt32(rit.Rows[j].ItemArray[0].ToString()));
                    c.capaciteit = Convert.ToInt32(ritTabel.Rows[0].ItemArray[2].ToString())  - pers.Rows.Count;
                    capacc.addCapa(c);
                }
                
            }

            clearBestelling();
            Response.Redirect("Home.aspx");
        }
    }

    private void clearBestelling()
    {
        Session["VPR_personen"] = null;
        Session["VPR_grdRitten"] = null;
        Session["VPR_tempRit"] = null;
        Session["VPR_bestelling"] = null;
    }
}