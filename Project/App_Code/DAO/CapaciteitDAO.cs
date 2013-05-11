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
        
        param.Add(new SqlParameter("@datum", d));
        param.Add(new SqlParameter("@rit", rit));
        SqlParameter[] sqlparam = param.ToArray();
        //strSQL = "SELECT capaciteit FROM tblCapaciteitRit WHERE datum = @datum AND ritID = @rit;";
        strSQL = "getCapa";

        return util.ophalenStoredProcedure(strSQL, sqlparam);
    }

    public int addCapa(CapaciteitData t)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 

        param.Add(new SqlParameter("@ritID", t.ritID));
        param.Add(new SqlParameter("@datum", t.datum));
        param.Add(new SqlParameter("@capaciteit", t.capaciteit));


        //SET IDENTITY_INSERT tblGebruikers ON;
        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "INSERT INTO tblCapaciteitRit (ritID, datum, capaciteit) VALUES(@ritID, @datum, @capaciteit);";

        return util.updaten(strSQL, sqlparam);
    }

    public int updateCapa(CapaciteitData t)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 

        param.Add(new SqlParameter("@ritID", t.ritID));
        param.Add(new SqlParameter("@datum", t.datum));
        param.Add(new SqlParameter("@capaciteit", t.capaciteit));


        //SET IDENTITY_INSERT tblGebruikers ON;
        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "UPDATE tblCapaciteitRit capaciteit = @capaciteit WHERE ritID = @ritID AND datum = @datum;";

        return util.updaten(strSQL, sqlparam);
    }
}