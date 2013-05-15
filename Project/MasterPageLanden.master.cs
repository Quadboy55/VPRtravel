using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;


public partial class MasterPageLanden : System.Web.UI.MasterPage
{

    private WS_Weather.GlobalWeather ws;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void setTemperatuur(String City, String Land)
    {
        try
        {
            ws = new WS_Weather.GlobalWeather();
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(ws.GetWeather(City, Land));
            XmlNodeList xnList = xml.SelectNodes("/CurrentWeather");
            foreach (XmlNode xn in xnList)
            {
                string s = xn["Temperature"].InnerText;
                int index1 = s.IndexOf("(");
                int index2 = s.IndexOf(")");

                lblTemp.Text = s.Substring(index1 + 1, index2 - index1 - 1);
            }
        }
        catch (Exception ex)
        {

        }

    }

    public void setHotel(List<HotelData> hotels)
    {
        lblHotel1Beschrijving.Text = hotels[0].beschrijving;
        lblHotel1Prijs.Text = Convert.ToString(hotels[0].prijs);
        imgHotel1.ImageUrl = hotels[0].foto;
        lblHotel1URL.Text = hotels[0].website;
        lblHotel1URL.Target = "_blank";
        lblHotel1URL.NavigateUrl = hotels[0].website;

        lblHotel2Beschrijving.Text = hotels[1].beschrijving;
        lblHotel2Prijs.Text = Convert.ToString(hotels[1].prijs);
        imgHotel2.ImageUrl = hotels[1].foto;
        lblHotel2URL.Text = hotels[1].website;
        lblHotel2URL.Target = "_blank";
        lblHotel2URL.NavigateUrl = hotels[1].website;

        lblHotel3Beschrijving.Text = hotels[2].beschrijving;
        lblHotel3Prijs.Text = Convert.ToString(hotels[2].prijs);
        imgHotel3.ImageUrl = hotels[2].foto;
        lblHotel3URL.Text = hotels[2].website;
        lblHotel3URL.Target = "_blank";
        lblHotel3URL.NavigateUrl = hotels[2].website;
    }

    public void setLandInfo(string info)
    {

    }
}
