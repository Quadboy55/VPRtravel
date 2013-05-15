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
        String City = "Bruxelles";
        String Land = "Belgium";
        List<HotelData> lst = new List<HotelData>();
        HotelAccess bll = new HotelAccess();
        DataTable hotels = bll.getAllHotelsByPlaats("Brussel");
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

        Master.setLandInfo("Het Brussels Hoofdstedelijk Gewest is een van de drie gewesten van België, al heeft het niet dezelfde juridische status als het Vlaamse en Waalse gewest.[1] Het omvat de 19 gemeenten van het arrondissement Brussel-Hoofdstad, en vormt zo de kern van het stedelijk gebied van Brussel. Het Brussels Gewest heeft een totale oppervlakte van 161 km² en ruim 1,2 miljoen inwoners. De bevolkingsdichtheid bedraagt zo 7.056 inwoners per km².");
        Master.setTemperatuur(City, Land);
        Master.setHotel(lst);
    }
}