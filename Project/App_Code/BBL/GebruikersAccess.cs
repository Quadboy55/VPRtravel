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
        return DAO.getAllUsers().Tables[0];
    }

    public DataTable getPlayersByLogin(String login)
    {
        DAO = new GebruikersDAO();
        return DAO.getPlayersByLogin(login).Tables[0];
    }

    public GebruikerData getPlayerByLogin(String login)
    {
       DAO = new GebruikersDAO();
       if (getPlayersByLogin(login) != null)
       {
           DataTable t = DAO.getUserByLogin(login).Tables[0];
           if (t.Rows.Count != 0)
           {
               GebruikerData g = new GebruikerData();
               object[] inhoud = t.Rows[0].ItemArray;
               g.ID = (int)inhoud[0];
               g.gebruikersnaam = (String)inhoud[1];
               g.wachtwoord = (String)inhoud[2];
               g.voornaam = (String)inhoud[3];
               g.naam = (String)inhoud[4];
               g.mail = (String)inhoud[5];
               g.straat = (String)inhoud[6];
               g.huisnr = Int32.Parse(inhoud[7].ToString());
               g.postcode =  Int32.Parse(inhoud[8].ToString());
               g.geboortedatum = DateTime.Parse(inhoud[10].ToString());
               g.stad = (String)inhoud[11];

               return g;
           }
       }

            return null;
        
    }

    public int getIdByLogin(string login)
    {
        DAO = new GebruikersDAO();
        DataTable d =DAO.getIdByLogin(login).Tables[0];

        if (d.Rows.Count != 0)
        {
            object[] inhoud = d.Rows[0].ItemArray;
            return Int32.Parse(inhoud[0].ToString());
        }
        return -1;
    }

    public DataTable getPlayersByID(int id)
    {
        DAO = new GebruikersDAO();
        return DAO.getUserById(id).Tables[0];
    }

    public String getMailByID(int id)
    {
        DAO = new GebruikersDAO();
        DataTable d = (DataTable)DAO.getMailById(id).Tables[0];
        return d.Rows[0].ItemArray[0].ToString();
    }

    public void changeUserById(GebruikerData g)
    {
        DAO = new GebruikersDAO();
        DAO.changeUserById(g);
    }

    public int addUser(GebruikerData g)
    {
        DAO = new GebruikersDAO();
        return DAO.addUser(g);
    }

    public DataTable getLogins(String login)
    {
        DAO = new GebruikersDAO();
        return DAO.getLogins(login).Tables[0];
    }


    public GebruikerData login(String login, byte[] pass)
    {
        DAO = new GebruikersDAO();
        if(getPlayersByLogin(login) != null)
        {
            DataTable t = DAO.login(login).Tables[0];
            if (t.Rows.Count != 0)
            {
                GebruikerData g = new GebruikerData();
                object[] inhoud = t.Rows[0].ItemArray;
                g.ID = (int)inhoud[0];
                g.gebruikersnaam = (String)inhoud[1];
                g.wachtwoord = (String)inhoud[2];
                g.voornaam = (String)inhoud[3];
                g.naam = (String)inhoud[4];
                return g;
            }

            
        }
        return null;
    }
}