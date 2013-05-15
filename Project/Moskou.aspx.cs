using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String City = "Moscow";
        String Land = "Russia";
        List<HotelData> lst = new List<HotelData>();
        HotelAccess bll = new HotelAccess();
        DataTable hotels = bll.getAllHotelsByPlaats("Moskou");
        for (int r = 0; r < hotels.Rows.Count; r++)
        {
            HotelData pl = new HotelData();
            object[] inhoud = hotels.Rows[r].ItemArray;
            pl.ID = (int)inhoud[0];
            pl.beschrijving = Convert.ToString(inhoud[2]);
            pl.foto = Convert.ToString(inhoud[3]);
            pl.website = Convert.ToString(inhoud[4]);
            pl.prijs = Convert.ToDouble(inhoud[5]);
            lst.Add(pl);
        }

        Master.setLandInfo("Moskou ligt op een hoogte van 156 meter boven de zeespiegel in het hoogland tussen de Oka en de Wolga. De rivier de Moskva doorkruist de stad van noordwest tot zuidoost over een lengte van ongeveer 80 kilometer. De breedte van de rivier binnen Moskou bedraagt 120 tot 200 meter. Daarnaast stromen er ongeveer 120 kleinere rivieren door de stad. De stadsgrenzen lopen ongeveer gelijk aan de in 1962 aangelegde ringweg om de stad (MKAD). Het stedelijk gebied heeft een oppervlakte van ruim 2511 km². Ongeveer een derde daarvan bestaat uit groengebied. Er zijn circa 100 parken in de stad. Moskou had op 1 januari 2013 11.979.529 inwoners. Hierbij dient worden opgemerkt dat dit alleen de inwoners met een officiële vergunning (om in Moskou te mogen wonen) betreft. Schattingen over het werkelijke inwoneraantal van Moskou variëren van 12 tot ong. 18 miljoen.");
        Master.setTemperatuur(City, Land);
        Master.setHotel(lst);
    }
}