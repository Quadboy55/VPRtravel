using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;

using System.Data.SqlClient;
/// <summary>
/// Summary description for TreinenDAO
/// </summary>
public class HotelDAO
{
    private string strSQL;
    private Util util;
    private List<SqlParameter> param;

    public HotelDAO()
	{
		
	}

    public DataSet getAllHotelsByPlaats(String plaats)
    {
        util = new Util();
        param = new List<SqlParameter>();
        //to add parameters=> 
        param.Add(new SqlParameter("@plaats",plaats));
        SqlParameter[] sqlparam = param.ToArray();
        strSQL = "SELECT tblHotel.* FROM tblHotel INNER JOIN tblPlaats ON tblHotel.plaatsID = tblPlaats.ID WHERE (tblPlaats.naam = @plaats);";

        return util.ophalen(strSQL, sqlparam);
    }

   
}