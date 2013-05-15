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
    private Util util;
    private List<SqlParameter> param;

    public GebruikersDAO()
	{
		
	}

    public DataSet getAllUsers()
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> param.Add(new SqlParameter("@variabelenaam",variabele));
        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "SELECT * FROM tblGebruikers;";

        return util.ophalen(strSQL, sqlparam);
    }

    public DataSet getUserById(int id){
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 
        param.Add(new SqlParameter("@id",id));


        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "SELECT * FROM tblGebruikers WHERE ID=@id;";

        return util.ophalen(strSQL, sqlparam);
    }

    public DataSet getMailById(int id)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 
        param.Add(new SqlParameter("@id", id));


        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "SELECT email FROM tblGebruikers WHERE ID=@id;";

        return util.ophalen(strSQL, sqlparam);
    }

    public DataSet getLogins(String login)
    {
        util = new Util();
        param = new List<SqlParameter>();
        param.Add(new SqlParameter("@login", login));

        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "SELECT gebruikersnaam FROM tblGebruikers where gebruikersnaam = @login;";

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

    public DataSet getUserByLogin(String login)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 
        param.Add(new SqlParameter("@login", login));


        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "SELECT * FROM tblGebruikers WHERE gebruikersnaam=@login;";

        return util.ophalen(strSQL, sqlparam);
    }

    public int addUser(GebruikerData g)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 
        
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



        //SET IDENTITY_INSERT tblGebruikers ON;
        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "INSERT INTO tblGebruikers (gebruikersnaam, passwoord, voornaam, naam, email, straat, huisnr, postcode, Gemeente, geboortedatum) VALUES(@gebruikersnaam, @passwoord, @voornaam, @naam, @email, @straat, @huisnr, @postcode, @stad, @geboortedatum);";

        return util.updaten(strSQL, sqlparam);
    }



    public void changeUserById(GebruikerData g)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 

        param.Add(new SqlParameter("@id", g.ID));
        param.Add(new SqlParameter("@voornaam", g.voornaam));
        param.Add(new SqlParameter("@naam", g.naam));
        param.Add(new SqlParameter("@email", g.mail));
        param.Add(new SqlParameter("@straat", g.straat));
        param.Add(new SqlParameter("@huisnr", g.huisnr));
        param.Add(new SqlParameter("@postcode", g.postcode));
        param.Add(new SqlParameter("@stad", g.stad));



        //SET IDENTITY_INSERT tblGebruikers ON;
        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "Update tblGebruikers set voornaam = @voornaam, naam = @naam, email = @email, straat = @straat, huisnr = @huisnr, postcode = @postcode, Geemente = @stad where id=@id;";

        util.updaten(strSQL, sqlparam);
    }

    public DataSet getIdByLogin(string login)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 
        param.Add(new SqlParameter("@login", login));


        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "SELECT id FROM tblGebruikers WHERE gebruikersnaam=@login;";

        return util.ophalen(strSQL, sqlparam);
    }

    internal void changePass(int id,string pass)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 

        param.Add(new SqlParameter("@id", id));
        param.Add(new SqlParameter("@pass", pass));



        //SET IDENTITY_INSERT tblGebruikers ON;
        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "Update tblGebruikers set passwoord=@pass where id=@id;";

        util.updaten(strSQL, sqlparam);
    }
}