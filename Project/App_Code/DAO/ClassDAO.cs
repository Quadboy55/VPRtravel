using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClassDAO
/// </summary>
public class ClassDAO
{
	private string strSQL;
    private Util util;
    private List<SqlParameter> param;
    
    public ClassDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public DataSet getAllClass()
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> param.Add(new SqlParameter("@variabelenaam",variabele));
        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "SELECT * FROM tblClass;";

        return util.ophalen(strSQL, sqlparam);
    }
}