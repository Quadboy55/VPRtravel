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
        String City = "Roma";
        String Land = "Italy";
        List<HotelData> lst = new List<HotelData>();
        HotelAccess bll = new HotelAccess();
        DataTable hotels = bll.getAllHotelsByPlaats("Rome");
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

        Master.setLandInfo("Rome (Italiaans: Roma) is de hoofdstad van Italië en tevens hoofdstad van de regio Lazio en de provincie Rome. De stad Rome heeft ca. 2,7 miljoen inwoners, het inwonertal van de metropoolregio bedraagt 3,7 miljoen. Het is de grootste stad van Italië. Door de stad, gelegen in het midwesten van het Apennijns Schiereiland, stromen de rivieren de Tiber en de Aniene. De geschiedenis van Rome strekt zich uit over 2500 jaar en de stad heeft zich in de geschiedenis ontwikkeld als een van de belangrijkste steden van de Westerse cultuur. Het was de hoofdstad van het Romeinse Koninkrijk, de Romeinse Republiek en het Romeinse Keizerrijk. Sinds 1871 is Rome de hoofdstad van Italië. Rome is ook de zetel van de paus, die het gezag voert over de dwergstaat Vaticaanstad, een enclave binnen de stad Rome.");
        Master.setTemperatuur(City, Land);
        Master.setHotel(lst);
    }
}