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

    public DataSet getPlayerById(int id){
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 
        param.Add(new SqlParameter("@id",id));


        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "SELECT * FROM tblGebruikers WHERE ID=@id;";

        return util.ophalen(strSQL, sqlparam);
    }
}