using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

using System.Data.SqlClient;
/// <summary>
/// Summary description for TreinenDAO
/// </summary>
public class TreinenDAO
{
    private string strSQL;
    private Util util;
    private List<SqlParameter> param;

    public TreinenDAO()
	{
		
	}

    public DataSet getAllTrains()
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> param.Add(new SqlParameter("@variabelenaam",variabele));
        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "SELECT * FROM tblTrein;";

        return util.ophalen(strSQL, sqlparam);
    }

    public DataSet getTrainsFromTo(int from, int to)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 
        param.Add(new SqlParameter("@from", from));
        param.Add(new SqlParameter("@to", to));


        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "SELECT * FROM tblTrein WHERE (vertrekID = @from AND aankomstID = @to);";

        return util.ophalen(strSQL, sqlparam);
    }
    public DataSet getTrainsFrom(int from)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 
        param.Add(new SqlParameter("@from", from));


        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "SELECT * FROM tblTrein WHERE vertrekID = @from;";

        return util.ophalen(strSQL, sqlparam);
    }
    public DataSet getTrainsTo(int to)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 
        param.Add(new SqlParameter("@to", to));


        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "SELECT * FROM tblTrein WHERE aankomstID = @to;";

        return util.ophalen(strSQL, sqlparam);
    }
}