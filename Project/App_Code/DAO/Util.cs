using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Util
/// </summary>
public class Util
{

    private SqlConnection cnn;
    
	public Util()
	{
        cnn = new SqlConnection();
        cnn.ConnectionString = ConfigurationManager.ConnectionStrings["VPRtravel"].ConnectionString; ;
	}

    public DataSet ophalenStoredProcedure(string strSQL, SqlParameter[] parameter)
    {
        try
        {
            SqlCommand cmd = new SqlCommand(strSQL, cnn);
            cmd.Parameters.AddRange(parameter);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dtaAdapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dtaAdapter.Fill(ds);
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

    public DataSet ophalen(string strSQL,SqlParameter[] parameter)
    {
        try
        {
            SqlCommand cmd = new SqlCommand(strSQL, cnn);
            cmd.Parameters.AddRange(parameter);
            SqlDataAdapter dtaAdapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dtaAdapter.Fill(ds);
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

    public int updaten(string strSQL, SqlParameter[] parameters)
    {
        SqlCommand myCom = new SqlCommand(strSQL, cnn);
        myCom.Parameters.AddRange(parameters);

        try
        {
            cnn.Open();
            int result = myCom.ExecuteNonQuery();
            return result;
        }
        catch (Exception ex)
        {

        }
        finally
        {
            cnn.Close();
        }
        return -1;
    }

}