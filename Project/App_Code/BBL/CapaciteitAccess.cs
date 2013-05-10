using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CapaciteitAccess
/// </summary>
public class CapaciteitAccess
{
    private CapaciteitDAO DAO;

	public CapaciteitAccess()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable getCapa(DateTime d, int rit)
    {
        DAO = new CapaciteitDAO();
        return DAO.getCapa(d,rit).Tables[0];
    }
}