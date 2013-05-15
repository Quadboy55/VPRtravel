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
        SiteMapPath pad = (SiteMapPath)Master.FindControl("SiteMapPath1");
        pad.Visible = false;
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        GebruikersAccess bll = new GebruikersAccess();
        GebruikerData user = bll.getPlayerByLogin(txtUsername.Text);
        if (user == null)
        {
            lblStatus.Text = "Er werd geen gebruiker gevonden met de opgegeven gebruikersnaam";
        }
        else
        {
            sendNewPass(user.mail, user.voornaam + " " + user.naam, user.gebruikersnaam);
        }
    }

    private void sendNewPass(string mail, string naam, string username)
    {
        string newpass = "";
        char[] characters = new char[58];
        for (int i = 65; i <= 122; i++)
        {
            characters[i - 65] = Convert.ToChar(i);
        }
        Random r = new Random();
        
        for(int j = 0;j<20;j++){
            char k = characters[r.Next(characters.Length)];
            string l = Convert.ToString(k);
            newpass += l;
        }
        GebruikersAccess bll = new GebruikersAccess();
        MD5_encryption md5 = new MD5_encryption();
        GebruikerData user = new GebruikerData();
        try
        {
            user = bll.getPlayerByLogin(username);
        }
        catch (Exception ex)
        {
            lblStatus.Text = "Er werd geen gebruiker gevonden met de opgegeven gebruikersnaam";
        }

        if (user != null)
        {
            bll.changePass(user.ID, md5.encryptPas(newpass));
            lblStatus.Text = "Het passwoord werd gewijzigd!";
            Mail.sendMail("Beste, <br/> <br/> U hebt onlangs uw passwoord gerecoverd bij VPRTravel <br/><br/> Nieuw passwoord: <strong>" + newpass + "</strong><br/><br/>Mvg,<br/> VPR Travel", mail, naam);
        }
        else
        {
            lblStatus.Text = "Er werd geen gebruiker gevonden met de opgegeven gebruikersnaam";
        }
    }
}