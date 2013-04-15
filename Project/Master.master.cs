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
             // zeg dat login of passwoord incorrect zijn
         }
         else
         {
             Response.Redirect("LoginSucces.aspx");
         }

    }
}
