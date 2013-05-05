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
        strSQL = "select tblRit.ID, treinID, tijdstip, vertrekID, aankomstID, prijs, duur from tblRit, tblTrein where (treinID = @trein  AND treinID = tblTrein.ID AND tijdstip = @tijd AND weekdag = @day) ;";

        return util.ophalen(strSQL, sqlparam);
    }
}