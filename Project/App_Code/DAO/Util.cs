using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for Util
/// </summary>
public class Util
{

    private OleDbConnection cnn;
    private String DatabaseProvider = "Provider=Microsoft.ACE.OLEDB.12.0;";
    private String DatabaseLocatie = "Data Source=|DataDirectory|NAAMDATABASE.accdb";

	public Util()
	{
        cnn = new OleDbConnection();
        cnn.ConnectionString = DatabaseProvider + DatabaseLocatie;
	}

    public DataSet ophalen(string strSQL,OleDbParameter parameter)
    {
        try
        {
            OleDbCommand cmd = new OleDbCommand(strSQL, cnn);
            cmd.Parameters.Add(parameter);
            OleDbDataAdapter dtaAdapter = new OleDbDataAdapter(cmd);
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