using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;


/// <summary>
/// Summary description for Service_Access
/// </summary>
public class PlaatsenAccess
{
    private PlaatsenDAO DAO;

    public PlaatsenAccess()
    {

    }

    public DataTable getPlaatsById(string id)
    {
        DAO = new PlaatsenDAO();
        return DAO.getPlaatsById(id).Tables[0];
    }

    /*public DataTable getByAlcohol(String percent)
    {

        bierdao = new Landendao_Access();
        return bierdao.getByAlcohol(percent).Tables[0];
    }*/
}