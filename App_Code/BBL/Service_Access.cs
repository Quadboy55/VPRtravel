using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;


/// <summary>
/// Summary description for Service_Access
/// </summary>
public class Service_Access
{
    private Dao_Access DAO;

    public Service_Access()
	{

	}

    public DataTable getAll()
    {
        DAO = new Dao_Access();
        return DAO.getAllFromLanden().Tables[0];
    }

    /*public DataTable getByAlcohol(String percent)
    {

        bierdao = new Landendao_Access();
        return bierdao.getByAlcohol(percent).Tables[0];
    }*/
}