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
        
    }



    protected void btnReg_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
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
            g.gebruikersnaam = txtLogin.Text;
            g.geboortedatum = DateTime.ParseExact(txtGebDat.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);

            //wachtwoord instellen (hash)
            g.wachtwoord = md5.encryptPas(txtPasswoord.Text);

            GebruikersAccess access = new GebruikersAccess();
            int res = access.addUser(g);
            txtVoornaam.Text = res.ToString();
            if (res != -1)
            {
                Response.Redirect("RegSucces.aspx");
            }
        }
    }
   
    protected void valLoginUniek_ServerValidate(object source, ServerValidateEventArgs args)
    {
        DataTable logins = new GebruikersAccess().getLogins(txtLogin.Text);

        if (logins.Rows.Count > 0)
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }

    }


    protected void valGeldigeDatum_ServerValidate(object source, ServerValidateEventArgs args)
    {
        try
        {
            DateTime date = DateTime.ParseExact(txtGebDat.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
        }
        catch (FormatException ex)
        {
            args.IsValid = false;
        }
        args.IsValid = true;

    }
    protected void val18Jaar_ServerValidate(object source, ServerValidateEventArgs args)
    {
        DateTime date = DateTime.ParseExact(txtGebDat.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
        DateTime now = DateTime.Now;

        if ((now - date).TotalDays >= 18*365)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }

    protected void btnEID_Click(object sender, EventArgs e)
    {
        HttpBrowserCapabilities bc = Request.Browser;
        pnlAppletFF.Visible = false;
        pnlAppletIE.Visible = false;

        if (bc.Browser == "IE" || bc.Browser == "Chrome")
        {
            pnlAppletIE.Visible = true;
        }
        else
        {
            if (bc.Browser == "Firefox")
            {
                pnlAppletFF.Visible = true;
            }
            else
            {
                pnlAppletIE.Visible = true;
            }
        }
    }
}