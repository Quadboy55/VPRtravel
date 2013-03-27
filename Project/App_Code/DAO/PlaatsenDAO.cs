using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

using System.Data.SqlClient;
/// <summary>
/// Summary description for TreinenDAO
/// </summary>
public class PlaatsenDAO
{
    private string strSQL;
    private Util util;
    private List<SqlParameter> param;

    public PlaatsenDAO()
    {

    }

    public DataSet getAllPlaatsen()
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> param.Add(new SqlParameter("@variabelenaam",variabele));
        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "SELECT * FROM tblPlaats;";

        return util.ophalen(strSQL, sqlparam);
    }

    public DataSet getPlaatsById(string id)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 
        param.Add(new SqlParameter("@id", id));


        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "SELECT * FROM tblPlaats WHERE ID=@id;";

        return util.ophalen(strSQL, sqlparam);
    }
}