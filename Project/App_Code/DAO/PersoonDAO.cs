using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PersoonDAO
/// </summary>
public class PersoonDAO
{
    private string strSQL;
    private Util util;
    private List<SqlParameter> param;

	public PersoonDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int addPersoon(PersoonData t)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 

        param.Add(new SqlParameter("@TicketID", t.ticketID));
        param.Add(new SqlParameter("@voornaam", t.voornaam));
        param.Add(new SqlParameter("@naam", t.naam));
        param.Add(new SqlParameter("@stoelnr", t.stoelnr));


        //SET IDENTITY_INSERT tblGebruikers ON;
        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "INSERT INTO tblPersonenPerTicket (TicketID, voornaam, naam, stoelnr) VALUES(@TicketID, @voornaam, @naam, @stoelnr);";

        return util.updaten(strSQL, sqlparam);
    }
}