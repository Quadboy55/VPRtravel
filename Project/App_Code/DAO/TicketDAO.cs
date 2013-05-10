using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

using System.Data.SqlClient;
/// <summary>
/// Summary description for TreinenDAO
/// </summary>
public class TicketDAO
{
    private string strSQL;
    private Util util;
    private List<SqlParameter> param;

    public TicketDAO()
	{
		
	}

    public DataSet getAllTickets()
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> param.Add(new SqlParameter("@variabelenaam",variabele));
        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "SELECT * FROM tblTicket;";

        return util.ophalen(strSQL, sqlparam);
    }

    public DataSet getTicketById(int tr)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 
        param.Add(new SqlParameter("@id", tr));

        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "SELECT * FROM tblTicket WHERE ID = @id;";

        return util.ophalen(strSQL, sqlparam);
    }

    public DataSet getPersonenPerTicket(int tr)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 
        param.Add(new SqlParameter("@id", tr));

        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "SELECT * FROM tblPersonenPerTicket WHERE TicketID = @id;";

        return util.ophalen(strSQL, sqlparam);
    }

    public void VerwijderPersonen(int TicketID)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 
        param.Add(new SqlParameter("@id", TicketID));

        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "DELETE FROM tblPersonenPerTicket WHERE TicketID = @id;";
        util.updaten(strSQL, sqlparam);
    }

    public void AnnuleerTicket(int TicketID)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 
        param.Add(new SqlParameter("@id", TicketID));

        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "DELETE FROM tblTicket WHERE ID = @id;";
        util.updaten(strSQL, sqlparam);
    }
}