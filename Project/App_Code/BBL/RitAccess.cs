using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RitAccess
/// </summary>
public class RitAccess
{
    private RitDAO DAO;

    public RitAccess()
    {

    }

    //public DataTable getRittenTrein(int treinID)
    //{

    //}

    public void addRit(RitBag r)
    {
        DAO = new RitDAO();
        DAO.addRit(r);
    }

    public DataTable getRittenTrein(int r, int day)
    {
        DAO = new RitDAO();
        return DAO.getRittenTrein(r, day).Tables[0];
    }

    public int getRitCapaciteit(int r)
    {
        DAO = new RitDAO();
        DataTable d = DAO.getRitCapaciteit(r).Tables[0];
        return Convert.ToInt32(d.Rows[0].ItemArray[0].ToString());
    }

    public DataTable getRitById(int id)
    {
        DAO = new RitDAO();
        return DAO.getRitByID(id).Tables[0];
    }

    public DataTable getRit(int treinID, int day, TimeSpan tijd)
    {
        DAO = new RitDAO();
        return DAO.getRit(treinID, day, tijd).Tables[0];
    }

    public DataTable getHistoriek(int id)
    {
        DAO = new RitDAO();
        return DAO.getHistoriek(id).Tables[0];
    }

    public DataTable getFuture(int id)
    {
        DAO = new RitDAO();
        return DAO.getFuture(id).Tables[0];
    }
}
