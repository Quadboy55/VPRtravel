using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

public partial class _Default : System.Web.UI.Page
{

    private RitAccess RitAccess;
    private RitAccess ritten;
    private PlaatsenAccess PlaatsAccess;
    private Dictionary<int, PlaatsData> plaatsData;

    protected void Page_Load(object sender, EventArgs e)
    {
        ((Master)Page.Master).checkLogon(true);

        if (Session["VPR_naam"] == null)
        {
            Response.Redirect("Home.aspx");
        }

        SiteMapPath pad = (SiteMapPath)Master.FindControl("SiteMapPath1");
        pad.Visible = false;


        RitAccess = new RitAccess();
        PlaatsAccess = new PlaatsenAccess();
        plaatsData = new Dictionary<int, PlaatsData>();
        if (!Page.IsPostBack)
        {
            GebruikersAccess bll = new GebruikersAccess();
            GebruikerData g = new GebruikerData();
            string gebruikersnaam = Session["VPR_naam"].ToString();
            g = bll.getPlayerByLogin(gebruikersnaam);
            
            lblGebruiker.Text = gebruikersnaam;
            txtNaam.Text = g.naam;
            txtVoornaam.Text = g.voornaam;
            txtStraat.Text = g.straat;
            txtPostcode.Text = g.postcode.ToString();
            txtHuisnr.Text = g.huisnr.ToString();
            txtGemeente.Text = g.stad;
            txtEmail.Text = g.mail;
            vulBestemmingData();
        }

        updateHistoriek();
        updateRitten();
    }

    private void updateHistoriek()
    {
        RitAccess = new RitAccess();
        int id = Int32.Parse(Session["VPR_id"].ToString());
        rptHistoriek.DataSource = RitAccess.getHistoriek(Int32.Parse(Session["VPR_id"].ToString()));
        rptHistoriek.DataBind();
    }

    private void updateRitten()
    {
        RitAccess = new RitAccess();
        rptRitten.DataSource = RitAccess.getFuture(Int32.Parse(Session["VPR_id"].ToString()));
        rptRitten.DataBind();
    }



    private void vulBestemmingData()
    {
        DataTable plaats = PlaatsAccess.getAllPlaatsen();

        for (int r = 0; r < plaats.Rows.Count; r++)
        {
            PlaatsData pl = new PlaatsData();
            object[] inhoud = plaats.Rows[r].ItemArray;
            pl.ID = (int)inhoud[0];
            pl.naam = (String)inhoud[1];
            //pl.beschrijving = (String)inhoud[2];

            plaatsData.Add(pl.ID, pl);
        }
    }

    protected void btnOpslaan_Click(object sender, EventArgs e)
    {
        GebruikersAccess bll = new GebruikersAccess();
        GebruikerData g = new GebruikerData();
        g.gebruikersnaam = Session["VPR_naam"].ToString();
        g.naam = txtNaam.Text;
        g.voornaam = txtVoornaam.Text;
        g.straat = txtStraat.Text;
        g.postcode = Int32.Parse(txtPostcode.Text);
        g.huisnr = Int32.Parse(txtHuisnr.Text);
        g.stad = txtGemeente.Text;
        g.mail = txtEmail.Text;
        g.ID = bll.getIdByLogin(g.gebruikersnaam);
        bll.changeUserById(g);
    }

    protected void btnHistoriek_Click(object sender, EventArgs e)
    {
        ritten = new RitAccess();
        rptHistoriek.DataSource = ritten.getHistoriek(Int32.Parse(Session["VPR_id"].ToString()));
        rptHistoriek.DataBind();
    }
    protected void btnProfiel_Click(object sender, EventArgs e)
    {
        GebruikersAccess bll = new GebruikersAccess();
        GebruikerData g = new GebruikerData();
        string gebruikersnaam = Session["VPR_naam"].ToString();
        g = bll.getPlayerByLogin(gebruikersnaam);
        lblGebruiker.Text = gebruikersnaam;
        txtNaam.Text = g.naam;
        txtVoornaam.Text = g.voornaam;
        txtStraat.Text = g.straat;
        txtPostcode.Text = g.postcode.ToString();
        txtHuisnr.Text = g.huisnr.ToString();
        txtGemeente.Text = g.stad;
        txtEmail.Text = g.mail;
    }

    public string getPlaats(int id)
    {
        if (plaatsData.Count == 0)
        {
            vulBestemmingData();
        }


        return plaatsData[id].naam;
    }



    public string getPersonen(int Ticketid)
    {
        TicketAccess t = new TicketAccess();
        DataTable table = t.getPersonenPerTicket(Ticketid);
        int atl = table.Rows.Count;
        string str = "";
        for (int i = 0; i < atl; i++)
        {
            str += "<li> " + table.Rows[i][2] + " " + table.Rows[i][3] + " </li>";
        }
        return str;
    }
    protected void btnAnnuleer_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        int TicketID = Int32.Parse(btn.ToolTip.ToString());
        TicketAccess t = new TicketAccess();
        DataTable table = t.getDatum(TicketID);
        string date = table.Rows[0][0].ToString();
        DateTime d = DateTime.Parse(date);
        DateTime today = new DateTime();

        if (d.AddDays(3) >= today)
        {
            t.AnnuleerTicket(TicketID);
            updateRitten();
        }
        else
        {
            Response.Write("<script LANGUAGE='JavaScript'>alert('Deze Rit kan niet worden geannuleerd!');</script>");
        }
    }

    protected void btnPassChange_Click(object sender, EventArgs e)
    {
        if (!txtPassOud.Text.Equals(txtPassNieuw.Text))
        {
            if (txtPassNieuw.Text.Equals(txtPassNieuwOpnieuw.Text))
            {
                try
                {
                    GebruikersAccess bll = new GebruikersAccess();
                    MD5_encryption md5 = new MD5_encryption();
                    GebruikerData gebruiker = bll.getPlayerByLogin(Convert.ToString(Session["VPR_naam"]));
                    // controle op huidig pass
                    if (gebruiker.wachtwoord.Equals(md5.encryptPas(txtPassOud.Text)))
                    {
                        int id = gebruiker.ID;
                        bll.changePass(id, md5.encryptPas(txtPassNieuw.Text));
                    }
                    else
                    {
                        lblStatus.Text = "Het oud passwoord klopt niet met het huidige passwoord!";
                    }

                    
                }
                catch (Exception ex)
                {
                    lblStatus.Text = "Er trad een fout op tijdens het wijzigen van het passwoord!";
                }

            }
            else
            {
                lblStatus.Text = "De 2 nieuwe passwoorden zijn niet gelijk!";
            }
        }
        else
        {
            lblStatus.Text = "Het nieuwe passwoord kan niet gelijk zijn aan de oude!";
        }
    }
}