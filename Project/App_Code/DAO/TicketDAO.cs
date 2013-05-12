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

    public DataSet getTicket(TicketData t)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> param.Add(new SqlParameter("@variabelenaam",variabele));
        param.Add(new SqlParameter("@gebruikerID", t.gebruikerID));
        param.Add(new SqlParameter("@totalePrijs", t.totalePrijs));
        param.Add(new SqlParameter("@aankomstdatum", t.aankomstdatum));
        param.Add(new SqlParameter("@vertrekdatum", t.vertrekdatum));
        param.Add(new SqlParameter("@typeID", t.typeID));
        param.Add(new SqlParameter("@treinID", t.treinID));

        SqlParameter[] sqlparam = param.ToArray();

        strSQL = "SELECT id FROM tblTicket WHERE( gebruikerID = @gebruikerID AND totalePrijs = @totalePrijs AND aankomstdatum = @aankomstdatum AND vertrekDatum = @vertrekdatum AND typeID = @typeID AND treinID = @treinID);";

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

    public DataSet getDatum(int TicketID)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 
        param.Add(new SqlParameter("@id", TicketID));

        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "SELECT vertrekDatum FROM tblTicket WHERE ID = @id;";

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

    public int addTicket(TicketData t)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 

        param.Add(new SqlParameter("@gebruikerID", t.gebruikerID));
        param.Add(new SqlParameter("@totalePrijs", t.totalePrijs));
        param.Add(new SqlParameter("@aankomstdatum", t.aankomstdatum));
        param.Add(new SqlParameter("@vertrekdatum", t.vertrekdatum));
        param.Add(new SqlParameter("@typeID", t.typeID));
        param.Add(new SqlParameter("@treinID", t.treinID));


        //SET IDENTITY_INSERT tblGebruikers ON;
        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "INSERT INTO tblTicket (gebruikerID, totalePrijs, aankomstdatum, vertrekDatum, typeID, treinID) VALUES(@gebruikerID, @totalePrijs, @aankomstdatum, @vertrekdatum, @typeID, @treinID);";

        return util.updaten(strSQL, sqlparam);
    }
}