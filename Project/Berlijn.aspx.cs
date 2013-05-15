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
        String City = "Berlin";
        String Land = "Germany";
        List<HotelData> lst = new List<HotelData>();
        HotelAccess bll = new HotelAccess();
        DataTable hotels = bll.getAllHotelsByPlaats("Berlijn");
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
        Master.setLandInfo("Berlijn (Duits: Berlin) is de hoofdstad van Duitsland en als stadstaat een deelstaat van dat land. Met 3.479.740 inwoners[1] is Berlijn tevens de grootste stad van het land en de op één na grootste stad in de Europese Unie. De stad ligt in het noordoosten van Duitsland, aan de rivier de Spree en wordt omsloten door de deelstaat Brandenburg, waarvan ze sinds 1920 geen deel meer uitmaakt. In zijn geschiedenis, die teruggaat tot de dertiende eeuw, was Berlijn de hoofdstad van Pruisen (1701–1918), het Duitse Keizerrijk (1871–1918), de Weimarrepubliek (1919–1933) en nazi-Duitsland (1933–1945). Na de Tweede Wereldoorlog was Berlijn gedurende meer dan veertig jaar een verdeelde stad, waarbij het oostelijke deel als hoofdstad fungeerde van de Duitse Democratische Republiek en West-Berlijn een de facto exclave van West-Duitsland was. Na de Duitse hereniging in 1990 werd Berlijn de hoofdstad van de Bondsrepubliek Duitsland en de zetel van het parlement, de deelstaatvertegenwoordiging en het staatshoofd. Berlijn is een metropool en geldt in Europa als één van de grootste culturele, politieke en wetenschappelijke centra.[2][3] De stad is ook bekend vanwege het hoog-ontwikkelde culturele leven (festivals, nachtleven, musea, kunsttentoonstellingen enz.) en de liberale levensstijl, moderne Zeitgeist en de lage kosten. Bovendien is Berlijn één van de groenste steden van Europa: 22% van Berlijn bestaat uit natuur en parken en 6% uit meren, rivieren en kanalen.");
        
        Master.setTemperatuur(City,Land);
        Master.setHotel(lst);
    }
}