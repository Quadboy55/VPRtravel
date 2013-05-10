using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CapaciteitDAO
/// </summary>
public class CapaciteitDAO
{
    private string strSQL;
    private Util util;
    private List<SqlParameter> param;

	public CapaciteitDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet getCapa(DateTime d, int rit)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> param.Add(new SqlParameter("@variabelenaam",variabele));
        SqlParameter[] sqlparam = param.ToArray();
        param.Add(new SqlParameter("@datum", d.ToLocalTime()));
        param.Add(new SqlParameter("@rit", rit));

        strSQL = "SELECT capaciteit FROM tblCapaciteitRit WHERE datum = @datum AND ritID = @rit;";

        return util.ophalen(strSQL, sqlparam);
    }
}