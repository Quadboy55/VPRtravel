using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

using System.Data.SqlClient;
/// <summary>
/// Summary description for Dao_Access
/// </summary>
public class Dao_Access
{
    private string strSQL;
    //private DataTable dttLanden;
    private Util util;
    private List<SqlParameter> param;

    public Dao_Access()
	{
		
	}

    public DataSet getLanden()
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> param.Add(new SqlParameter("@variabelenaam",variabele));
        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "SELECT * FROM tblPlaatsen;";

        return util.ophalen(strSQL, sqlparam);














        //util = new Util();
        //SqlParameter param = new SqlParameter();
        //strSQL = "Select * from tblPlaatsen;";
        //return util.ophalen(strSQL, param);
    }

   /* public DataSet getByAlcohol(string percent)
    {
        util = new Util();
        OleDbParameter param = new OleDbParameter("@alcohol",percent);
        
        strSQL = "Select * from bieren where alcohol>= @alcohol;";
       
        return util.ophalen(strSQL, param);
    }*/
}