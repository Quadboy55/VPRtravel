﻿using System;
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
        MD5_encryption md5 = new MD5_encryption();
        GebruikersAccess access = new GebruikersAccess();
        
        String login = txtLogin.Text;
        String pass = md5.encryptPas(txtWachtwoord.Text);

         gebruiker = access.getPlayerByLogin(login);
         if (gebruiker == null)
         {
             Session["VPR_login"] = false;
             Response.Redirect("Home.aspx");
             
         }
         else
         {
             if (pass.Equals(gebruiker.wachtwoord))
             {
                 Session["VPR_login"] = true;
                 Session["VPR_id"] = gebruiker.ID;
                 Session["VPR_naam"] = gebruiker.naam + " " + gebruiker.voornaam;
                 Response.Redirect("LoginSucces.aspx");
             }
             else
             {
                 Session["VPR_login"] = false;
                 Response.Redirect("Home.aspx");
             }
         }

    }
    private void checkLogon()
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

    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        Session.Clear();
        btnLogRes.Visible = true;
        btnLogOut.Visible = false;
        btnProfile.Visible = false;
    }
}
