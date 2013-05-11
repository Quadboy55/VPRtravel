using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RitDAO
/// </summary>
public class RitDAO
{
    private string strSQL;
    private Util util;
    private List<SqlParameter> param;
    
    public RitDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int addRit(RitBag r)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 

        param.Add(new SqlParameter("@treinID", r.treinID));
        param.Add(new SqlParameter("@weekdag", r.weekdag));
        param.Add(new SqlParameter("@tijdstip", r.tijdstip));

        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "INSERT INTO tblRit(treinID, weekdag, tijdstip) VALUES(@treinID, @weekdag, @tijdstip);";

        return util.updaten(strSQL, sqlparam);
    }

    public DataSet getRittenTrein(int id, int day)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 
        param.Add(new SqlParameter("@id", id));
        param.Add(new SqlParameter("@day", day));


        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "SELECT tijdstip FROM tblRit WHERE treinID = @id AND weekdag = @day;";

        return util.ophalen(strSQL, sqlparam);
    }

    public DataSet getRit(int treinID, int day, TimeSpan tijd)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 
        param.Add(new SqlParameter("@trein", treinID));
        param.Add(new SqlParameter("@day", day));
        param.Add(new SqlParameter("@tijd", tijd));


        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "select tblRit.ID, treinID, vertrekUur, vertrekID, aankomstID, prijs, duur from tblRit, tblTrein where (treinID = @trein  AND treinID = tblTrein.ID AND vertrekUur = @tijd AND weekdag = @day) ;";

        return util.ophalen(strSQL, sqlparam);
    }

    public DataSet getRitByID(int i)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 
        param.Add(new SqlParameter("@id", i));


        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "select * from tblRit WHERE ID = @id ;";

        return util.ophalen(strSQL, sqlparam);
    }

    public DataSet getHistoriek(int gebruikersid)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 
        param.Add(new SqlParameter("@gebruikersid", gebruikersid));


        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "SELECT tblTicket.vertrekDatum AS Datum, tblTrein.vertrekID AS Vertrek, tblTrein.aankomstID AS Aankomst, tblTicket.totalePrijs AS Betaald, tblTicket.ID AS TicketID FROM tblTicket INNER JOIN tblTrein ON tblTicket.treinID = tblTrein.ID INNER JOIN tblGebruikers ON tblTicket.gebruikerID = tblGebruikers.ID WHERE  (tblGebruikers.ID = 1) AND (tblTicket.vertrekDatum < CURRENT_TIMESTAMP) ORDER BY Datum";
        
        
        
        
        return util.ophalen(strSQL, sqlparam);
    }

    public DataSet getFuture(int gebruikersid)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 
        param.Add(new SqlParameter("@gebruikersid", gebruikersid));


        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "SELECT tblTicket.vertrekDatum AS Datum, tblTrein.vertrekID AS Vertrek, tblTrein.aankomstID AS Aankomst, tblTicket.totalePrijs AS Betaald, tblTicket.ID AS TicketID FROM tblTicket INNER JOIN tblTrein ON tblTicket.treinID = tblTrein.ID INNER JOIN tblGebruikers ON tblTicket.gebruikerID = tblGebruikers.ID WHERE  (tblGebruikers.ID = 1) AND (tblTicket.vertrekDatum > CURRENT_TIMESTAMP) ORDER BY Datum";




        return util.ophalen(strSQL, sqlparam);
    }
}