using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        for (int i = 1; i <= 12; i++)
        {
             ListItem l = new ListItem(i.ToString(), i.ToString(), true);
             drpMaand.Items.Add(l);
        }

        for (int i = DateTime.Now.AddYears(-150).Year; i <= DateTime.Now.AddYears(-18).Year; i++)
        {
            ListItem l = new ListItem(i.ToString(),i.ToString(),true);
            drpJaar.Items.Add(l);
        }
    }



    protected void btnReg_Click(object sender, EventArgs e)
    {
        MD5_encryption md5 = new MD5_encryption();
        GebruikerData g = new GebruikerData();
        g.voornaam = txtVoornaam.Text;
        g.naam = txtNaam.Text;
        g.mail = txtEmail.Text;
        g.straat = txtStraat.Text;
        g.huisnr = Int32.Parse(txtHuisnr.Text);
        g.postcode = Int32.Parse(txtPost.Text);
        g.gebruikersnaam = txtLogin.Text;

        //wachtwoord instellen (hash)
        g.wachtwoord = md5.encryptPas(txtPasswoord.Text);

        GebruikersAccess access = new GebruikersAccess();
        int res = access.addPlayer(g);
        txtVoornaam.Text = res.ToString();
        if (res != -1)
        {
            Response.Redirect("RegSucces.aspx");
        }
    }
    protected void btnRegis_Click(object sender, EventArgs e)
    {
        MD5_encryption md5 = new MD5_encryption();
        GebruikerData g = new GebruikerData();
        g.voornaam = txtVoornaam.Text;
        g.naam = txtNaam.Text;
        g.mail = txtEmail.Text;
        g.straat = txtStraat.Text;
        g.huisnr = Int32.Parse(txtHuisnr.Text);
        g.postcode = Int32.Parse(txtPost.Text);
        g.stad = txtStad.Text;
        g.geboortedatum = new DateTime(Convert.ToInt32(drpDag.SelectedValue),Convert.ToInt32(drpMaand.SelectedValue),Convert.ToInt32(drpJaar.SelectedValue));
        g.gebruikersnaam = txtLogin.Text;

        //wachtwoord instellen (hash)
        g.wachtwoord = md5.encryptPas(txtPasswoord.Text);

        GebruikersAccess access = new GebruikersAccess();
        int res = access.addPlayer(g);
        txtVoornaam.Text = res.ToString();
        if (res != -1)
        {
            Response.Redirect("RegSucces.aspx");
        }
    }

    protected void valLoginUniek_ServerValidate(object source, ServerValidateEventArgs args)
    {
        DataTable logins = new GebruikersAccess().getLogins();

        if (logins.Rows.Find(txtLogin.Text) == null)
            args.IsValid = true;
        else
            args.IsValid = false;

    }

    protected void drpMaand_SelectedIndexChanged(object sender, EventArgs e)
    {
        int dagen = DateTime.DaysInMonth(Convert.ToInt32(drpJaar.SelectedValue), Convert.ToInt32(drpMaand.SelectedValue));

        drpMaand.Items.Clear();

        for (int i = 1; i <= dagen; i++)
        {
            ListItem l = new ListItem(i.ToString(), i.ToString(), true);
            drpDag.Items.Add(l);
        }
    }
}