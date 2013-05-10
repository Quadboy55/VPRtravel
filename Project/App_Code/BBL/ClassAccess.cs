using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClassAccess
/// </summary>
public class ClassAccess
{
    private ClassDAO DAO;
	public ClassAccess()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public DataTable getAllClass()
    {
        DAO = new ClassDAO();
        return DAO.getAllClass().Tables[0];
    }
}