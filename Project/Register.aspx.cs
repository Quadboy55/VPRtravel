using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        GebruikerData g = new GebruikerData();
        g.voornaam = txtVoornaam.Text;
        g.naam = txtNaam.Text;
        g.mail = txtEmail.Text;
        g.straat = txtStraat.Text;
        g.huisnr = Int32.Parse(txtHuisnr.Text);
        g.postcode = Int32.Parse(txtPost.Text);
        g.gebruikersnaam = txtLogin.Text;
        g.wachtwoord = txtPasswoord.Text;

        GebruikersAccess access = new GebruikersAccess();
        int res = access.addPlayer(g);

        if (res != -1)
        {
            Response.Redirect("RegSucces.aspx");
        }
    }
}