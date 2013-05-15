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
        String City = "Paris-orly";
        String Land = "France";
        List<HotelData> lst = new List<HotelData>();
        HotelAccess bll = new HotelAccess();
        DataTable hotels = bll.getAllHotelsByPlaats("Parijs");
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
        Master.setLandInfo("Parijs (Frans: Paris) is de hoofdstad en regeringszetel van Frankrijk. Het is ook een departement. Met 2,25 miljoen inwoners in de gemeente Parijs zelf en ruim 11 miljoen in het hele stedelijke gebied, met inbegrip van de banlieues (voorsteden) en deforensensteden daaromheen, is het de grootste stad van Frankrijk en de negende stad van Europa (en het vierde stadsgebied van Europa, na Moskou, Istanboel en Londen). Volgens de schattingen van het Institut national de la statistique et des études économiques had de stad Parijs zonder de agglomeraties in 2009 2.257.981 inwoners (Parijzenaars, in het Frans Parisiens enParisiennes), terwijl dit er inclusief de agglomeraties in 1999 al 11.174.740 waren. ");
        Master.setTemperatuur(City, Land);
        Master.setHotel(lst);
    }
}