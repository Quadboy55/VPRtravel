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
        checkLogon();
        
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
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
             Response.Redirect("Home.aspx");
             
         }
         else
         {
             Session["login"] = true;
             Session["id"] = gebruiker.ID;
             Session["naam"] = gebruiker.naam +" "+ gebruiker.voornaam;
             Response.Redirect("LoginSucces.aspx");
         }

    }
    private void checkLogon()
    {
        if (Session["login"] != null)
        {
            if (((Boolean)Session["login"]) == true )
            {
                btnLogRes.Visible = false;
                btnLogOut.Visible = true;
                lblLogNaam.Visible = true;
                lblLogNaam.Text = Session["naam"].ToString();
                lblError.Visible = false;
                hdValue.Value = "1";
            }
            else
            {
                lblError.Text = "Login of wachtwoord zijn incorrect";
                lblError.Visible = true;
                hdValue.Value = "0";
                
            }
        }
    }

}
