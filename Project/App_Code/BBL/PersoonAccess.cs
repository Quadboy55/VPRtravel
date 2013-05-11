using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PersoonAccess
/// </summary>
public class PersoonAccess
{
    private PersoonDAO DAO;

	public PersoonAccess()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int addPersoon(PersoonData t)
    {
        DAO = new PersoonDAO();
        return DAO.addPersoon(t);
    }
}