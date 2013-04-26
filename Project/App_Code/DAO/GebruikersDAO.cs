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

    public DataSet getLogins()
    {
        util = new Util();
        param = new List<SqlParameter>();

        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "SELECT gebruikersnaam FROM tblGebruikers;";

        return util.ophalen(strSQL, sqlparam);
    }

    public DataSet login(String login)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 
        param.Add(new SqlParameter("@login", login));


        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "SELECT * FROM tblGebruikers WHERE gebruikersnaam = @login;";

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

    public DataSet getPlayerByLogin(String login)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 
        param.Add(new SqlParameter("@login", login));


        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "SELECT * FROM tblGebruikers WHERE gebruikersnaam=@login;";

        return util.ophalen(strSQL, sqlparam);
    }

    public int addPlayer(GebruikerData g)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 
        
        param.Add(new SqlParameter("@id", g.ID));
        param.Add(new SqlParameter("@gebruikersnaam", g.gebruikersnaam));
        param.Add(new SqlParameter("@passwoord", g.wachtwoord));
        param.Add(new SqlParameter("@voornaam", g.voornaam));
        param.Add(new SqlParameter("@naam", g.naam));
        param.Add(new SqlParameter("@email", g.mail));
        param.Add(new SqlParameter("@straat", g.straat));
        param.Add(new SqlParameter("@huisnr", g.huisnr));
        param.Add(new SqlParameter("@postcode", g.postcode));
        param.Add(new SqlParameter("@stad", g.stad));
        param.Add(new SqlParameter("@geboortedatum", g.geboortedatum));


        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "SET IDENTITY_INSERT tblGebruikers ON; INSERT INTO tblGebruikers (id, gebruikersnaam, passwoord, voornaam, naam, email, straat, huisnr, postcode, stad, geboortedatum) VALUES(@id, @gebruikersnaam, @passwoord, @voornaam, @naam, @email, @straat, @huisnr, @postcode, @stad, @geboortedatum);";

        return util.updaten(strSQL, sqlparam);
    }


}