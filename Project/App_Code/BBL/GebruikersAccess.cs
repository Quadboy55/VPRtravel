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

    /*public DataTable getByAlcohol(String percent)
    {

        bierdao = new Landendao_Access();
        return bierdao.getByAlcohol(percent).Tables[0];
    }*/
}