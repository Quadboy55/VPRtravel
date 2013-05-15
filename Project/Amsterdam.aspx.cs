using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String City = "amsterdam";
        String Land = "Netherland";
        List<HotelData> lst = new List<HotelData>();
        HotelAccess bll = new HotelAccess();
        DataTable hotels = bll.getAllHotelsByPlaats("Amsterdam");
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
        Master.setLandInfo("Amsterdam is de (titulaire) hoofdstad en, qua inwoners, grootste gemeente van Nederland. De stad, in het Amsterdams ook Mokum genoemd (afkomstig uit het Jiddisch),[2] ligt in de provincie Noord-Holland, aan de monding van de Amstel en aan het IJ. Amsterdam dankt zijn naam aan de ligging bij een in de 13e eeuw aangelegde dam in de Amstel. De plaats kreeg stadsrechten rond 1300 en groeide in de Gouden Eeuw uit tot een van de grootste handelssteden ter wereld. Bevolkingsgroei leidde vanaf het eind van de 16e eeuw tot stadsuitbreidingen, waaronder de grachtengordel, die op de UNESCO-Werelderfgoedlijst staat en tot dé bezienswaardigheden van de stad behoort. Andere attracties zijn musea, zoals het Rijksmuseum, het Stedelijk Museum en het Van Gogh Museum, het Anne Frank Huis, de Wallen en de coffeeshops. Amsterdam heeft twee universiteiten en telt de meeste nationaliteiten ter wereld. Op 1 Maart 2013 telde de gemeente Amsterdam 801.200 inwoners. Op 1 december 2012 haalde de gemeente voor het eerst sinds de jaren zeventig het inwoneraantal van 800.000.[5] De grootstedelijke agglomeratie telde in januari 2012 ongeveer 1,5 miljoen inwoners[6] en is daarmee qua inwoneraantal de grootste agglomeratie in Nederland. De Metropoolregio Amsterdam, waartoe onder andere Almere, Het Gooi, Haarlem, Zaanstad en Purmerend worden gerekend, heeft ongeveer 2,4 miljoen inwoners.[7] Amsterdam is verder een van de steden in de Randstad. De stad is bestuurlijk onderverdeeld in zeven stadsdelen die weer zijn onderverdeeld in buurten en wijken.");
        Master.setTemperatuur(City, Land);
        Master.setHotel(lst);
    }
}