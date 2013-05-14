using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CapaciteitData
/// </summary>
public class HotelData
{
    public int ID { get; set; }
    public PlaatsData plaats { get; set; }
    public string beschrijving { get; set; }
    public string foto { get; set; }
    public string website { get; set; }
    public double prijs { get; set; }


    public HotelData()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}