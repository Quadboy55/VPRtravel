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
        checkLogon(false);
        HttpCookie c = Request.Cookies["VPR_Profiel"];

        String[] talen = HttpContext.Current.Request.UserLanguages;
        if (talen[0].StartsWith("nl"))
        {
            int i;
            
            if (c != null)
            {
                i = Convert.ToInt32(c.Value);
            }
            else
            {
                Random r = new Random();
                i = r.Next(1, 7);
            }

            switch(i)
            {
                case 1: adRotator.KeywordFilter = "amsterdam_ned"; break;
                case 2: adRotator.KeywordFilter = "berlijn_ned"; break;
                case 3: adRotator.KeywordFilter = "brussel_ned"; break;
                case 4: adRotator.KeywordFilter = "London_ned"; break;
                case 5: adRotator.KeywordFilter = "moskou_ned"; break;
                case 6: adRotator.KeywordFilter = "parijs_ned"; break;
                case 7: adRotator.KeywordFilter = "Rome_ned"; break;
            }
        }
        else
        {
            int i;

            if (c != null)
            {
                i = Convert.ToInt32(c.Value);
            }
            else
            {
                Random r = new Random();
                i = r.Next(1, 7);
            }

            switch(i)
            {
                case 1: adRotator.KeywordFilter = "amsterdam_eng"; break;
                case 2: adRotator.KeywordFilter = "berlijn_eng"; break;
                case 3: adRotator.KeywordFilter = "brussel_eng"; break;
                case 4: adRotator.KeywordFilter = "London_eng"; break;
                case 5: adRotator.KeywordFilter = "moskou_eng"; break;
                case 6: adRotator.KeywordFilter = "parijs_eng"; break;
                case 7: adRotator.KeywordFilter = "Rome_eng"; break;
            }
        }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Register.aspx");
    }


    protected void btnLogOk_Click(object sender, EventArgs e)
    {
        MD5_encryption md5 = new MD5_encryption();
        GebruikersAccess access = new GebruikersAccess();
        
        String login = txtLogin.Text;
        String pass = md5.encryptPas(txtWachtwoord.Text);

         gebruiker = access.getPlayerByLogin(login);
         if (gebruiker == null)
         {
             Session["VPR_login"] = false;
             //Response.Redirect("~/Home.aspx");
             
         }
         else
         {
             if (pass.Equals(gebruiker.wachtwoord))
             {
                 Session["VPR_login"] = true;
                 Session["VPR_id"] = gebruiker.ID;
                 Session["VPR_fullnaam"] = gebruiker.naam + " " + gebruiker.voornaam;
                 Session["VPR_naam"] = gebruiker.gebruikersnaam;

                 //Response.Redirect("~/Profile.aspx");
             }
             else
             {
                 Session["VPR_login"] = false;
                 //Response.Redirect("~/Home.aspx");
             }
         }

    }
    public void checkLogon(Boolean plicht)
    {
        if (plicht)
        {
            if (Session["VPR_login"] != null)
            {
                if (((Boolean)Session["VPR_login"]) == true)
                {
                    btnLogRes.Visible = false;
                    btnLogOut.Visible = true;
                    btnProfile.Visible = true;
                    btnProfile.Text = Session["VPR_naam"].ToString();
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
            else
            {
                lblError.Text = "Login om verder te gaan";
                lblError.Visible = true;
                hdValue.Value = "0";
            }

        }
        else
        {
            if (Session["VPR_login"] != null)
            {
                if (((Boolean)Session["VPR_login"]) == true)
                {
                    btnLogRes.Visible = false;
                    btnLogOut.Visible = true;
                    btnProfile.Visible = true;
                    btnProfile.Text = Session["VPR_naam"].ToString();
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

    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        Session.Clear();
        btnLogRes.Visible = true;
        btnLogOut.Visible = false;
        btnProfile.Visible = false;
        Response.Redirect("Home.aspx");
    }
    protected void btnProfile_Click(object sender, EventArgs e)
    {
        Response.Redirect("profile.aspx");
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Session.Clear();
        hdValue.Value = "1";
        Response.Redirect("Home.aspx");
    }
}
