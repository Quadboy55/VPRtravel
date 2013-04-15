using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

using System.Data.SqlClient;
/// <summary>
/// Summary description for Dao_Access
/// </summary>
public class GebruikersDAO
{
    private string strSQL;
    //private DataTable dttLanden;
    private Util util;
    private List<SqlParameter> param;

    public GebruikersDAO()
	{
		
	}

    public DataSet getAllPlayers()
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> param.Add(new SqlParameter("@variabelenaam",variabele));
        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "SELECT * FROM tblGebruikers;";

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

    public DataSet login(String login, String pass)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 
        param.Add(new SqlParameter("@login", login));
        param.Add(new SqlParameter("@pass", pass));


        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "SELECT * FROM tblGebruikers WHERE gebruikersnaam = @login AND passwoord = @pass;";

        return util.ophalen(strSQL, sqlparam);
    }

    public DataSet getPlayersByLogin(String login)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 
        param.Add(new SqlParameter("@login", login));


        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "SELECT * FROM tblGebruikers WHERE gebruikersnaam=@login;";

        return util.ophalen(strSQL, sqlparam);
    }
}