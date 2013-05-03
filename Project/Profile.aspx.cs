using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
        }
    }
    protected void btnOpslaan_Click(object sender, EventArgs e)
    {
        GebruikersAccess bll = new GebruikersAccess();
        GebruikerData g = new GebruikerData();
        g.gebruikersnaam = Session["VPR_naam"].ToString();
        g.naam=txtNaam.Text;
        g.voornaam=txtVoornaam.Text;
        g.straat=txtStraat.Text;
        g.postcode=Int32.Parse(txtPostcode.Text);
        g.huisnr=Int32.Parse(txtHuisnr.Text);
        g.stad =txtGemeente.Text;
        g.mail=txtEmail.Text;
        g.ID = bll.getIdByLogin(g.gebruikersnaam);
        bll.changeUserById(g);
    }
}