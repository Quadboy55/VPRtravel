using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class _Default : System.Web.UI.Page
{
    private WS_Weather.GlobalWeather ws;

    protected void Page_Load(object sender, EventArgs e)
    {
        ws = new WS_Weather.GlobalWeather();
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(ws.GetWeather("Bruxelles", "Belgium"));
        XmlNodeList xnList = xml.SelectNodes("/CurrentWeather");
        foreach (XmlNode xn in xnList)
        {
            string s =  xn["Temperature"].InnerText;
            int index1 = s.IndexOf("(");
            int index2 = s.IndexOf(")");

            lblShit.Text = s.Substring(index1 + 1, index2 - index1-1);
        }
    }
}