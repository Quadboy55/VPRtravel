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
        return DAO.getRittenTrein(r,day).Tables[0];
    }
}