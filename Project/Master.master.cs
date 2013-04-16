using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master : System.Web.UI.MasterPage
{
    GebruikerData gebruiker;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["login"] != null)
        {
            if (Session["login"].ToString().Equals("True"))
            {
                setLogon();
            }
            else
            {
                lblError.Text = "Login of wachtwoord zijn incorrect";                
            }
        }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }

    private void setLogon()
    {
        btnLogRes.Visible = false;
        btnLogOut.Visible = true;
        lblLogNaam.Visible = true;
        lblLogNaam.Text = Session["naam"].ToString();
    }
    protected void btnLogOk_Click(object sender, EventArgs e)
    {
        GebruikersAccess access = new GebruikersAccess();
        
        String login = txtLogin.Text;
        String pas = txtWachtwoord.Text;

         gebruiker = access.login(login, pas);
         if (gebruiker == null)
         {
             Session["login"] = false;
         }
         
         {
             Session["login"] = true;
             Session["id"] = gebruiker.ID;
             Session["naam"] = gebruiker.naam +" "+ gebruiker.voornaam;
             Response.Redirect("LoginSucces.aspx");
         }

    }

}
