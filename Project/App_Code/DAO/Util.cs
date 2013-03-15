using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.OleDb;

using System.Data.SqlClient;

/// <summary>
/// Summary description for Util
/// </summary>
public class Util
{

    private SqlConnection cnn;
    private String DatabaseLocatie = "Data Source=VPRtravel.mssql.somee.com;Initial Catalog=VPRTravel;Persist Security Info=True;User ID=1004224752_SQLLogin_1;Password=gwfgkafvio";

	public Util()
	{
        cnn = new SqlConnection();
        cnn.ConnectionString = DatabaseLocatie;
	}

    public DataSet ophalen(string strSQL,SqlParameter[] parameter)
    {
        try
        {
            SqlCommand cmd = new SqlCommand(strSQL, cnn);
            cmd.Parameters.AddRange(parameter);
            SqlDataAdapter dtaAdapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dtaAdapter.Fill(ds, "ds_landen");
            return ds;
        }
        catch (System.Exception ex)
        {
            return null;
        }
        finally
        {
            cnn.Close();
        }
    }

}