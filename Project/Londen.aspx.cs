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
        String City = "London";
        String Land = "";
        List<HotelData> lst = new List<HotelData>();
        HotelAccess bll = new HotelAccess();
        DataTable hotels = bll.getAllHotelsByPlaats("Londen");
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

        Master.setLandInfo("Londen (Engels: London) is de hoofdstad en grootste stad van zowel Engeland als het Verenigd Koninkrijk. In de regio Groot-Londen, waarvan de begrenzing tegenwoordig vaak gelijk wordt gesteld aan die van de stad Londen, wonen ongeveer 7,5 miljoen mensen. Hiermee is Londen de stad met de meeste inwoners van de Europese Unie. De hele regio van de metropool strekt zich evenwel nog ver uit buiten de grenzen van Groot-Londen. De grenzen hiervan zijn niet gemakkelijk aan te geven, het aantal inwoners ligt tussen de 12 en 14 miljoen. De stad is, behalve de hoofdstad en de grootste stad van het Verenigd Koninkrijk, ook het politieke, economische en culturele centrum van dat land. Ook in Europa en de wereld vervult ze een belangrijke functie op diverse gebieden: Londen wordt als een van de vier traditionele alfa-wereldsteden beschouwd, samen met Parijs, Tokio en New York City. Londen telt vier plaatsen die op de Werelderfgoedlijst van de UNESCO staan: de Tower of London, de historische nederzetting van Greenwich, de Kew Gardens, en een gezamenlijke inschrijving bestaande uit het Palace of Westminster, Westminster Abbey en Saint Margaret's Church.[3]");
        Master.setTemperatuur(City, Land);
        Master.setHotel(lst);
    }
}