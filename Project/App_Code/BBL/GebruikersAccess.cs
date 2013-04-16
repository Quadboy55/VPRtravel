using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;


/// <summary>
/// Summary description for Service_Access
/// </summary>
public class GebruikersAccess
{
    private GebruikersDAO DAO;

    public GebruikersAccess()
	{

	}

    public DataTable getAllPlayers()
    {
        DAO = new GebruikersDAO();
        return DAO.getAllPlayers().Tables[0];
    }

    public DataTable getPlayersByLogin(String login)
    {
        DAO = new GebruikersDAO();
        return DAO.getPlayersByLogin(login).Tables[0];
    }

    public GebruikerData login(String login, String pass)
    {
        DAO = new GebruikersDAO();
        if(getPlayersByLogin(login) != null)
        {
            DataTable t = DAO.login(login, pass).Tables[0];
            if (t.Rows.Count != 0)
            {
                GebruikerData g = new GebruikerData();
                object[] inhoud = t.Rows[0].ItemArray;
                g.ID = (int)inhoud[0];
                g.gebruikersnaam = (String)inhoud[1];
                g.wachtwoord = (String)inhoud[2];
                g.voornaam = (String)inhoud[3];
                g.naam = (String)inhoud[4];
                //g.mail = (String)inhoud[5];
                //g.straat = (String)inhoud[6];
                //g.huisnr = (int)inhoud[7];
                //g.postcode = (int)inhoud[8];
                //g.lidSinds = (DateTime)inhoud[9];

                return g;
            }

            
        }
        return null;
    }
}