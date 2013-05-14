using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;


/// <summary>
/// Summary description for Service_Access
/// </summary>
public class HotelAccess
{
    private HotelDAO DAO;

    public HotelAccess()
    {

    }

    public DataTable getAllHotelsByPlaats(string plaats)
    {
        DAO = new HotelDAO();
        return DAO.getAllHotelsByPlaats(plaats).Tables[0];
    }

    

}