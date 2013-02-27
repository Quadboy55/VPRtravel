using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for Dao_Access
/// </summary>
public class Dao_Access
{
    private string strSQL;
    //private DataTable dttLanden;
    private Util util;

    public Dao_Access()
	{
		
	}

    public DataSet getAllFromLanden()
    {
        util = new Util();
        OleDbParameter param = new OleDbParameter();
        strSQL = "Select * from Landen;";
        return util.ophalen(strSQL, param);
    }

   /* public DataSet getByAlcohol(string percent)
    {
        util = new Util();
        OleDbParameter param = new OleDbParameter("@alcohol",percent);
        
        strSQL = "Select * from bieren where alcohol>= @alcohol;";
       
        return util.ophalen(strSQL, param);
    }*/
}