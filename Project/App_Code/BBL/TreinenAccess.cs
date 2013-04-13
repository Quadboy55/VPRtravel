using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;


/// <summary>
/// Summary description for Service_Access
/// </summary>
public class TreinenAccess
{
    private TreinenDAO DAO;

    public TreinenAccess()
    {

    }

    public DataTable getAllTrains()
    {
        DAO = new TreinenDAO();
        return DAO.getAllTrains().Tables[0];
    }

    public DataTable getTrainsFromTo(int from, int to)
    {
        DAO = new TreinenDAO();
        return DAO.getTrainsFromTo(from, to).Tables[0];
    }
    public DataTable getTrainsFrom(int from)
    {
        DAO = new TreinenDAO();
        return DAO.getTrainsFrom(from).Tables[0];
    }
    public DataTable getTrainsTo(int to)
    {
        DAO = new TreinenDAO();
        return DAO.getTrainsTo(to).Tables[0];
    }

    /*public DataTable getByAlcohol(String percent)
    {

        bierdao = new Landendao_Access();
        return bierdao.getByAlcohol(percent).Tables[0];
    }*/
}