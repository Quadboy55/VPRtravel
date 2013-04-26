using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GebruikerData
/// </summary>
public class GebruikerData
{
    public int ID { get; set; }
    public String gebruikersnaam { get; set; }
    public String wachtwoord { get; set; }
    public String naam { get; set; }
    public String voornaam { get; set; }
    public String mail { get; set; }
    public String straat { get; set; }
    public String stad { get; set; }
    public int huisnr { get; set; }
    public int postcode { get; set; }
    public DateTime lidSinds { get; set; }
    public DateTime geboortedatum { get; set; }
    
    public GebruikerData()
	{
		

	}
}