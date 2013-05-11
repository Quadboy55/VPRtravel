using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PersoonData
/// </summary>
public class PersoonData
{
    public int ID { get; set; }
    public int ticketID { get; set; }
    public String voornaam { get; set; }
    public String naam { get; set; }
    public String stoelnr { get; set; }
    
    public PersoonData()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}